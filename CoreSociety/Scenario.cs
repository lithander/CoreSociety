using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CoreSociety
{
    class Scenario
    {
        XDocument _xml = null;

        public Scenario(XDocument xdoc)
        {
            _xml = xdoc;
        }

        public string MissionStatement
        {
            get 
            { 
                
                XElement ms = _xml.Descendants("mission").FirstOrDefault();
                return ms != null ? ms.Value : "No Mission Statement provided!";  
            }
        }

        public int Width
        {
            get { return _xml.Descendants("grid").Attributes("width").Select(attr => int.Parse(attr.Value)).FirstOrDefault(); }
        }

        public int Height
        {
            get { return _xml.Descendants("grid").Attributes("height").Select(attr => int.Parse(attr.Value)).FirstOrDefault(); }
        }

        public int EnergyBudget 
        {
            get { return _xml.Descendants("budget").Select(node => int.Parse(node.Value)).FirstOrDefault(); }
        }

        public IEnumerable<Listing> Deck
        {
            get
            {
                return CreateDeck();
            }
        }

        public Grid Grid
        {
            get
            {
                return CreateGrid();
            }
        }               

        public void Save(string filePath)
        {
            _xml.Save(filePath);
        }

        public static Scenario Load(string filePath)
        {
            return new Scenario(XDocument.Load(filePath));
        }

        private IEnumerable<Listing> CreateDeck()
        {
            foreach (XElement node in _xml.Descendants("deck").Descendants("listing"))
            {
                Listing listing = new Listing();
                string[] lines = node.Value
                    .Split(new string[] { "\n" }, StringSplitOptions.None)
                    .Select(line => line.Trim())
                    .ToArray();
                listing.Parse(lines);
                if (node.Attribute("color") != null)
                    listing.Color = ColorFromHex(node.Attribute("color").Value);

                if (node.Attribute("idrange") != null)
                {
                    string[] range = node.Attribute("idrange").Value.Split('-');
                    listing.Identity = new Listing.IdRange(ByteFromHex(range[0]), ByteFromHex(range[1]));
                }

                yield return listing;
            }
        }

        private CoreSociety.Grid CreateGrid()
        {
            Grid grid = new Grid(Width, Height);
            int i = 0;
            foreach (XElement node in _xml.Descendants("grid").Descendants("core"))
            {
                Grid.Entry entry = grid.ListOfEntries[i++];
                if (node.Value != "")
                    entry.Core.Decode(node.Value);
                if (node.Attribute("color") != null)
                    entry.Color = ColorFromHex(node.Attribute("color").Value);
                if (node.Attribute("listing") != null)
                    entry.ListingID = int.Parse(node.Attribute("listing").Value);
            }
            return grid;
        }

        /*
         * STATIC
         */

        public static Scenario Create(Grid grid, int budget, IEnumerable<Listing> listings, string mission, bool writeCoreState)
        {
            XDocument xdoc = new XDocument(
                new XElement("scenario",
                    new XElement("mission", new XText(mission)),
                    new XElement("budget", new XText(budget.ToString())),
                    new XElement("deck"),
                    new XElement("grid", new XAttribute("width", grid.Width.ToString()), new XAttribute("height", grid.Height.ToString()))
                )
            );
            XElement deckNode = xdoc.Descendants("deck").First();
            foreach (Listing listing in listings)
            {
                XElement listingNode = new XElement("listing");
                listingNode.Value = listing.Lines.Aggregate((agg, token) => agg + "\n" + token);
                listingNode.SetAttributeValue("color", ColorToHex(listing.Color));
                if(listing.Identity.IsValid)
                {
                    string range = ByteToHex(listing.Identity.Min)+"-"+ByteToHex(listing.Identity.Max);
                    listingNode.SetAttributeValue("idrange", range);
                }
                deckNode.Add(listingNode);
            }

            XElement gridNode = xdoc.Descendants("grid").First();
            foreach (Grid.Entry entry in grid.ListOfEntries)
            {
                XElement coreNode = new XElement("core");
                if (writeCoreState)
                    coreNode.Value = entry.Core.Encode();
                coreNode.SetAttributeValue("listing", entry.ListingID);
                coreNode.SetAttributeValue("color", ColorToHex(entry.Color));
                gridNode.Add(coreNode);
            }
            return new Scenario(xdoc);
        }

        public static byte ByteFromHex(string hex)
        {
            return byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }

        public static string ByteToHex(byte value)
        {
            return value.ToString("X2");
        }

        public static Color ColorFromHex(string hexNotation)
        {
            uint color = uint.Parse(hexNotation, System.Globalization.NumberStyles.HexNumber);
            byte red = (byte)((0xFF0000 & color) >> 16);
            byte green = (byte)((0xFF00 & color) >> 8);
            byte blue = (byte)(0xFF & color);
            return Color.FromArgb(red, green, blue);
        }

        public static string ColorToHex(Color color)
        {
            string result = "";
            result += color.R.ToString("X2");
            result += color.G.ToString("X2");
            result += color.B.ToString("X2");
            return result;
        }
    }

}

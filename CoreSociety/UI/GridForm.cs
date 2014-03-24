using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Xml;
using CoreSociety.Properties;

namespace CoreSociety.UI
{
    public partial class GridForm : Form
    {
        private bool _playing = false;
        private bool _started = false;
        private bool _loaded = false;
        private int _energyPerTick = 1;

        private Scenario _scenario = null;
        private Grid _grid = null;
        private List<Listing> _deck = null;
        private GridAuthority _ga = null;
        private SaveFileDialog _saveFileDlg = new SaveFileDialog();
        private OpenFileDialog _openFileDlg = new OpenFileDialog();

        public GridForm()
        {
            InitializeComponent();
            UpdateButtonStates();

            _ga = new GridAuthority();
            _ga.Ticked += OnCoresChanged;
            _saveFileDlg.DefaultExt = "xml";
            _saveFileDlg.FileName = "NewScenario";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (_openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _scenario = Scenario.Load(_openFileDlg.FileName);
                LoadScenario(_scenario, true);
                _loaded = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_saveFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _scenario = Scenario.Create(_grid, _ga.Energy, _deck, false);
                _scenario.Save(_saveFileDlg.FileName);
            }
        }

        private void LoadScenario(Scenario scenario, bool loadListings)
        {
            _grid = scenario.Grid;
            _ga.Init(scenario.EnergyBudget, _grid);
            gridView.Data = _grid;
            if (loadListings)
            {
                _deck = _scenario.Deck.ToList();
                deckView.Data = _deck;
                UpdateContextMenue();
            }
            foreach (Grid.Entry entry in _grid.ListOfEntries.Where(entry => entry.ListingID >= 0 && entry.ListingID < _deck.Count))
            {
                entry.Core.ClearMemory();
                _deck[entry.ListingID].Compile(entry.Core);
                Draw(entry.Core);
            }
            _loaded = true;
            UpdateView();
        }

        private void UpdateContextMenue()
        {
            ToolStripMenuItem deckEntry = gridContextMenu.Items["deckToolStripMenuItem"] as ToolStripMenuItem;
            deckEntry.DropDownItems.Clear();
            int i = 0;
            foreach(Listing listing in _deck)
            {
                ToolStripMenuItem slotEntry = new ToolStripMenuItem("Slot " + i++, null, deckSlotPaste_Click);
                slotEntry.ForeColor = listing.Color;
                slotEntry.Tag = listing;
                deckEntry.DropDownItems.Add(slotEntry);
            };
        }

        private void deckSlotPaste_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem slotEntry = sender as ToolStripMenuItem;
            Core core = gridContextMenu.Tag as Core;
            Listing listing = slotEntry.Tag as Listing;
            if (core == null || listing == null)
                return;

            int index = _deck.IndexOf(listing);

            Grid.Entry coreEntry = _grid.ListOfEntries.Where(entry => entry.Core == core).FirstOrDefault();
            coreEntry.ListingID = index;
            coreEntry.Color = listing.Color;

            core.ClearMemory();
            listing.Compile(core);
            Draw(core);

            //update scenario
            _scenario = Scenario.Create(_grid, _ga.Energy, _deck, true);
        }

        private void UpdateView()
        {
            UpdateButtonStates();
            txtEnergy.Text = _ga.Energy.ToString();
            txtScore.Text = _ga.Score.ToString();
        }

        private void OnCoresChanged(IEnumerable<Core> cores)
        {
            foreach(Core core in cores)
                Draw(core);

            UpdateView();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _started = false;
            _playing = false;
            LoadScenario(_scenario, false);
            UpdateButtonStates();
        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            _started = true;
            _playing = !_playing;
            //_scenario = Scenario.Create(_grid, _ga.Energy, false);
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            btnLoad.Enabled = !_started;
            btnSave.Enabled = _loaded && !_started;
            btnStartPause.Enabled = _loaded;
            btnStartPause.Image = _playing ? (Image)Resources.PauseIcon : (Image)Resources.PlayIcon;
            btnStop.Enabled = _started;
        }

        private bool _isScrolling = false;
        private Point _scrollPos = new Point();

        private void gridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isScrolling)
            {
                gridView.OffsetX += e.Location.X - _scrollPos.X;
                gridView.OffsetY += e.Location.Y - _scrollPos.Y;
                _scrollPos = e.Location;
            }
        }

        private void gridView_MouseLeave(object sender, EventArgs e)
        {
            _isScrolling = false;
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            _scrollPos = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                _isScrolling = true;
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            _isScrolling = false;
        }

        private void gridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && _loaded)
            {
                Grid.Entry entry = gridView.Pick(e.Location);
                if (entry != null)
                {
                    //show context menu!
                    gridContextMenu.Tag = entry.Core;
                    gridContextMenu.Show(gridView.PointToScreen(e.Location));
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core core = gridContextMenu.Tag as Core;
            if (core != null)
                Clipboard.SetText(core.Encode());
        }
               

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core core = gridContextMenu.Tag as Core;
            if (core != null)
            {
                try
                {
                    core.Decode(Clipboard.GetText());
                    Draw(core);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Draw(Core core)
        {
            gridView.Render(core, _ga.GetStatusFlags(core));
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core core = gridContextMenu.Tag as Core;
            if (core != null)
            {
                Grid.Entry coreEntry = _grid.ListOfEntries.Where(entry => entry.Core == core).FirstOrDefault();
                coreEntry.ListingID = -1;
                coreEntry.Color = Color.Black;
                core.ClearMemory();
                Draw(core);
            }
        }

        private void autoRunSpeed_ValueChanged(object sender, EventArgs e)
        {
            int speedVal = autoRunSpeed.Value;
            txtTicksPerSecond.Text = "T:"+autoRunSpeed.Value;
            runClock.Interval = 1000 / speedVal;
        }

        private void batchSize_Scroll(object sender, EventArgs e)
        {
            int batchVal = batchSize.Value;
            _energyPerTick = (batchVal > 0) ? (int)Math.Pow(2, (batchSize.Value - 1)) : 0;
            txtEnergyPerTick.Text = "E:" + _energyPerTick; 
        }

        private void runClock_Tick(object sender, EventArgs e)
        {
            if (_loaded && _playing)
                _ga.Tick(_energyPerTick);
        }

        private void deckView_MouseClick(object sender, MouseEventArgs e)
        {
            Listing listing = deckView.Pick(e.Location);
            if (listing != null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    AssemblyForm assembly = _assembyForms.FirstOrDefault(af => af.Listing == listing);
                    if (assembly == null)
                    {
                        listing.Changed += OnListingChanged;
                        assembly = new AssemblyForm();
                        assembly.Listing = listing;
                        assembly.FormClosing += OnAssemblyClosing;
                        _assembyForms.Add(assembly);
                        assembly.Show();
                    }
                    else
                        assembly.BringToFront();
                }
            };
        }

        private void OnListingChanged(Listing sender)
        {
            if(_started)
                return;

            int index = _deck.IndexOf(sender);
            foreach (Core core in _grid.ListOfEntries.Where(e => e.ListingID == index).Select(e => e.Core))
            {
                core.ClearMemory();
                sender.Compile(core);
                Draw(core);
            }
        }

        private void OnAssemblyClosing(object sender, FormClosingEventArgs e)
        {
            AssemblyForm form = sender as AssemblyForm;
            form.FormClosing -= OnAssemblyClosing;
            _assembyForms.Remove(form as AssemblyForm);
        }

        List<AssemblyForm> _assembyForms = new List<AssemblyForm>();     
    }
}

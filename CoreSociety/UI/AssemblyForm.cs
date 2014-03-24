using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CoreSociety.Properties;

namespace CoreSociety.UI
{
    public partial class AssemblyForm : Form
    {
        public AssemblyForm()
        {
            InitializeComponent();
            Setup();
            UpdateView();
        }
        const int MAIN_CORE_SCALE = 4;

        private bool _autoUpdate = true;
        private Grid _grid = new Grid(2, 2);
        private Grid.Entry _focus = null;
        private int _focusAddress = -1;


        public Core SelectedCore
        {
            get { return _focus.Core; }   
        }

        public Core SelectedCoreTarget
        {
            get { return _grid.GetTargetOf(SelectedCore); }
        }

        public void Select(Grid.Entry entry)
        {
            if (_focus != null)
                _focus.Color = Color.Black;
            _focus = entry;
            _focus.Color = Color.DarkSlateBlue;
            UpdateView();
        }

        private ExecutionContext _interpreter = new ExecutionContext();
        private Listing _listing = new Listing();
        private CoreView _coreView = new CoreView();
        private Bitmap _upscaledCoreBmp;
        private Graphics _upscaledCoreGfx = null;

        private int _batchSize = 1;

        public Listing Listing
        {
            get { return _listing; }
            set { SetListing(value); }
        }

        private void SetListing(Listing listing)
        {
            if(_listing != null)
                _listing.Unload(SelectedCore);

            _listing = listing;
            listingBox.SelectionBackColor = Color.FromArgb(34, 26, 55);
            listingBox.Lines = listing.Lines.ToArray();
            _listing.Parse(listingBox.Lines);
            _listing.Compile(SelectedCore);
            UpdateView(false);
        }

        private void Setup()
        {
            gridView.Data = _grid;
            //Grid & Focus
            _focus = _grid.Entries[0];
            _focus.Color = Color.DarkSlateBlue;
            //Rendering
            int w = _coreView.Width * MAIN_CORE_SCALE;
            int h = _coreView.Height * MAIN_CORE_SCALE;
            _upscaledCoreBmp = new Bitmap(w, h);
            _upscaledCoreGfx = Graphics.FromImage(_upscaledCoreBmp);
            _upscaledCoreGfx.PixelOffsetMode = PixelOffsetMode.Half;
            _upscaledCoreGfx.InterpolationMode = InterpolationMode.NearestNeighbor;
            //Target List
            coreTarget.Items.AddRange(Enum.GetNames(typeof(Core.Focus)));
            coreTarget.SelectedIndex = (int)Core.Focus.Self;
        }

        private void OnListingChanged(object sender, EventArgs e)
        {
            if (_autoUpdate)
            {
                ParseListing();
                UpdateView(false);
            }
        }

        private void UpdateView(bool updateFocusWord = true)
        {
            numIP.Value = SelectedCore.InstructionPointer;
            unboundEnergy.Value = SelectedCore.Energy;
            shieldEnergy.Value = SelectedCore.Shield;
            chargedEnergy.Value = SelectedCore.Charge;
            coreTarget.SelectedIndex = Math.Min((int)SelectedCore.Target, 5);
            UpdateMemBox();
            RenderCores();
            if(updateFocusWord)
                SetFocusWord(SelectedCore.InstructionPointer);
        }

        private void RenderFocusCore()
        {
            //Focus Core
            _coreView.Render(_focus.Core, _interpreter.GetNextInstructionCost(_focus.Core), StatusFlags.Blue, Color.Black);
            _upscaledCoreGfx.DrawImage(_coreView.Image, 0, 0, _coreView.Width * MAIN_CORE_SCALE, _coreView.Height * MAIN_CORE_SCALE);
        }

        private void RenderCores()
        {
            gridView.RebuildBuffer();
            RenderFocusCore();
            coreRenderView.Image = _upscaledCoreBmp;
        }

        private void ParseListing()
        {
            _listing.Unload(SelectedCore);
            _listing.Parse(listingBox.Lines);
            _listing.Compile(SelectedCore);       
        }
               
        private void ExecuteNext()
        {
            if (cbEnergy.Checked)
                _interpreter.ConsumeOneEnergy(SelectedCore, SelectedCoreTarget);
            else
                _interpreter.Execute(SelectedCore, SelectedCoreTarget);
            UpdateView();
        }

        private void ExecuteBatch(int i)
        {
            if (cbEnergy.Checked)
            {
                while (SelectedCore.Energy > 0 && i-- > 0)
                    _interpreter.ConsumeEnergyUntilExecute(SelectedCore, SelectedCoreTarget);
            }
            else
                _interpreter.ExecuteMultiple(SelectedCore, SelectedCoreTarget, i);

            UpdateView();
        }

        private void stepBtn_Click(object sender, EventArgs e)
        {
            ExecuteNext();
        }

        private void runClock_Tick(object sender, EventArgs e)
        {
            ExecuteBatch(_batchSize);
        }

        private void OnRunSpeedChanged(object sender, EventArgs e)
        {
            UpdateAutoRun();
        }

        private void UpdateAutoRun()
        {
            int speedVal = autoRunSpeed.Value;
            int batchVal = batchSize.Value;

            if (speedVal == 0 || !cbAutoStep.Checked)
                runClock.Enabled = false;
            else
            {
                runClock.Interval = 1000 / speedVal;
                runClock.Enabled = true;
            }
            _batchSize = (batchVal > 0) ? (int)Math.Pow(2, (batchSize.Value - 1)) : 0;
            txtAutoRun.Text = autoRunSpeed.Value + " X " + _batchSize.ToString();           
        }

        private void OnBatchSizeChanged(object sender, EventArgs e)
        {
            UpdateAutoRun();
        }

        private void OnIpValueChanged(object sender, EventArgs e)
        {
            SelectedCore.InstructionPointer = (byte)numIP.Value;
            UpdateView();
        }

        private void OnUnboundEnergyChanged(object sender, EventArgs e)
        {
            SelectedCore.Energy = (byte)unboundEnergy.Value;
            RenderCores();
        }

        private void OnShieldEnergyChanged(object sender, EventArgs e)
        {
            SelectedCore.Shield = (byte)shieldEnergy.Value;
            RenderCores();
        }

        private void OnChargeLevelChanged(object sender, EventArgs e)
        {
            SelectedCore.Charge = (byte)chargedEnergy.Value;
            RenderCores();
        }
        
        private void OnCoreFocusTargetChanged(object sender, EventArgs e)
        {
            SelectedCore.Target = (Core.Focus)coreTarget.SelectedIndex;
        }

        private void OnCoreRenderViewClick(object sender, MouseEventArgs e)
        {
            int addr = _coreView.PixelToAdress(ImageToFocusCore(e.Location));
            if (addr >= 0)
                numIP.Value = addr;
        }

        private Point ImageToFocusCore(Point pt)
        {
            pt.X /= MAIN_CORE_SCALE;
            pt.Y /= MAIN_CORE_SCALE;
            return pt;
        }

        private void OnRenderViewMouseMove(object sender, MouseEventArgs e)
        {
            int addr = _coreView.PixelToAdress(ImageToFocusCore(e.Location));
            if (addr >= 0)
                SetFocusWord(addr);
            else
                SetFocusWord(SelectedCore.InstructionPointer);
        }

        private void SetFocusWord(int addr)
        {
            Instruction instr = _listing.GetInstructionAt((byte)addr);
            if (_focusAddress != addr)
            {
                _focusAddress = addr;
                if (instr != null)
                {

                    txtOpCode.Text = Instruction.GetMnemonic(instr.OpCode);
                    txtAddress.Text = addr.ToString("X2");
                }
                else
                {
                    txtAddress.Text = "--";
                    txtOpCode.Text = "---";
                }
                SelectListingLine(instr);
                SelectMemoryBlock(addr);
            }
        }

        private void SelectListingLine(Instruction instr)
        {
            int lines = listingBox.Lines.Count();
            //the select magic can't deal with the listingBox having the focus currently
            txtOpCode.Focus();
            //also prevent triggering auto updating temporarily
            bool oldAutoUpdate = _autoUpdate;
            _autoUpdate = false;
            //..finally: the magic
            listingBox.SuspendLayout();
            listingBox.SelectAll();
            listingBox.SelectionBackColor = Color.FromArgb(34, 26, 55);
            if (instr != null && instr.LineNumber < lines)
            {
                listingBox.Select(listingBox.GetFirstCharIndexFromLine(instr.LineNumber), listingBox.Lines[instr.LineNumber].Length);
                listingBox.SelectionBackColor = Color.SlateBlue;
            }
            listingBox.ResumeLayout();
            //restore
            _autoUpdate = oldAutoUpdate;
        }
            
        private void btnToggleAutoUpdate_Click(object sender, EventArgs e)
        {
            _autoUpdate = btnToggleAutoUpdate.Checked;
            btnToggleAutoUpdate.Image = _autoUpdate ? (Image)Resources.AutoUpdateInv : (Image)Resources.AutoUpdate; 
        }

        private void btnClearListing_Click(object sender, EventArgs e)
        {
            listingBox.Text = "";
        }

        private void btnLoadListing_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.OpenFile());
                listingBox.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void btnSaveListing_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.OpenFile());
                writer.Write(listingBox.Text);
                writer.Close();
            }
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            ParseListing();
            UpdateView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SelectedCore.ClearMemory();
            UpdateView();
        }

        private void OnAutoStepCheckedChanged(object sender, EventArgs e)
        {
            UpdateAutoRun();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core core = coreContextMenu.Tag as Core;
            if (core != null)
                Clipboard.SetText(core.Encode());
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core core = coreContextMenu.Tag as Core;
            if (core != null)
            {
                try
                {
                    core.Decode(Clipboard.GetText());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateView();
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            GridForm gridForm = new GridForm();
            gridForm.Show();
        }

        private void memoryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            char c = e.KeyChar;
            if (IsHex(c))
            {
                memoryBox.SuspendLayout();
                memoryBox.SelectionBackColor = Color.FromArgb(34, 26, 55);
                int idx = memoryBox.SelectionStart;
                string txt = memoryBox.Text;
                while(idx < txt.Length && !IsHex(txt[idx]))
                    idx++;
                txt = txt.Remove(idx, 1);
                txt = txt.Insert(idx, c.ToString().ToUpper());
                memoryBox.Text = txt;
                memoryBox.SelectionStart = idx + 1;
                memoryBox.ResumeLayout();
                ParseMemBox();
                RenderCores();
            }
        }

        private static bool IsHex(char c)
        {
            bool isHex = (c >= '0' && c <= '9') ||
                   (c >= 'a' && c <= 'f') ||
                   (c >= 'A' && c <= 'F');
            return isHex;
        }

        private void UpdateMemBox()
        {
            string text = "";
            for (short y = 0; y < 16; y++)
            {
                string line = "";
                for (short x = 0; x < 16; x++)
                    line += String.Format("{0:X4} ", SelectedCore.Memory[y, x]);
                if (y < 15)
                    line += '\n';
                text += line;
            }
            memoryBox.SelectionBackColor = Color.FromArgb(34, 26, 55);
            memoryBox.Text = text;
        }

        private void SelectMemoryBlock(int address)
        {
            int lines = memoryBox.Lines.Count();
            memoryBox.SelectAll();
            memoryBox.SelectionBackColor = Color.FromArgb(34, 26, 55);
            memoryBox.Select(address * 5 + address / lines, 4);
            memoryBox.SelectionBackColor = Color.SlateBlue;
            memoryBox.ResumeLayout();
        }

        private void ParseMemBox()
        {
            string text = memoryBox.Text;
            int i = 0;
            foreach (string token in text.Split(' '))
            {
                if (token.Length < 4)
                    continue;
                string word = token;
                if(word[0] == '\n')
                    word = token.Remove(0,1);
                ushort num = ushort.Parse(word, System.Globalization.NumberStyles.HexNumber);
                SelectedCore.Memory[i++] = num;
            }
        }

        private void gridView_MouseClick(object sender, MouseEventArgs e)
        {
            Grid.Entry entry = gridView.Pick(e.Location);
            if (e.Button == MouseButtons.Left && entry != null && _focus != entry)
            {
                Select(entry);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                //show context menu!
                coreContextMenu.Tag = entry.Core;
                coreContextMenu.Show(gridView.PointToScreen(e.Location));
            }
        }


        
    }
}

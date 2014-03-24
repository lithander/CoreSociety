using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using CoreSociety.Properties;

namespace CoreSociety
{
    [Flags]
    public enum StatusFlags
    {
        None = 0,
        Green = 1,
        Yellow = 2,
        Red = 4,
        Blue = 8,
        All = 15
    }
    
    public class CoreView
    {  
        private Bitmap _bitmap;
        private Bitmap _highSrc;
        private Bitmap _lowSrc;
        private Bitmap _baseSrc;

        const int K = 3;

        public int Width
        {
            get { return _bitmap.Width; }
        }

        public int Height
        {
            get { return _bitmap.Height; }
        }

        public Image Image
        {
            get { return _bitmap; }
        }

        public Color BackgroundColor = Color.FromArgb(0, 0, 0);
        public Color InstructionFrameColor = Color.FromArgb(120, 100, 160);

        public Color[] Palette = new Color[]
        {            
            Color.FromArgb(34, 26, 55),

            Color.FromArgb(120, 45, 0),
            Color.FromArgb(245, 140, 85),
            
            Color.FromArgb(120, 0, 35),
            Color.FromArgb(240, 110, 125),
            
            Color.FromArgb(70, 15, 95),
            Color.FromArgb(168, 100, 168),
            
            Color.FromArgb(20, 35, 100),            
            Color.FromArgb(90, 125, 230), 
            
            Color.FromArgb(0, 85, 90),
            Color.FromArgb(90, 185, 190),
            
            Color.FromArgb(5, 95, 0),
            Color.FromArgb(124, 198, 118),

            Color.FromArgb(110, 110, 0),
            Color.FromArgb(210, 205, 95),

            Color.FromArgb(220, 230, 240),
        };

        public CoreView()
        {
            _highSrc = Resources.CoreFrameHigh as Bitmap;
            _lowSrc = Resources.CoreFrameLow as Bitmap;
            _baseSrc = Resources.CoreFrameBasic as Bitmap;
            _bitmap = new Bitmap(_lowSrc);
        }

        public int PixelToAdress(Point point)
        {
            point.X -= 5;
            point.Y -= 7;
            point.X /= K;
            point.Y /= K;
            if (point.X >= 0 && point.X <= 15 && point.Y >= 0 && point.Y <= 15)
                return point.X + point.Y * 16;
            else
                return -1;
        }

        public void RenderBasic(Core core, Color color)
        {
            //Clear
            Graphics gfx = Graphics.FromImage(_bitmap);
            gfx.Clear(Color.Transparent);
            Rectangle r = new Rectangle(0, 0, _baseSrc.Width, _baseSrc.Height);
            Rectangle r2 = r;
            r2.Inflate(-2, -2);
            gfx.FillRectangle(new SolidBrush(color), r2);
            gfx.DrawImage(_baseSrc, r, r, GraphicsUnit.Pixel);
            //Render Memory
            int i = 0;
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                {
                    int data = core.Memory[i++];
                    _bitmap.SetPixel(5 + x * K, y * K + 5, Palette[(data & 0xF000) >> 12]);
                    _bitmap.SetPixel(6 + x * K, y * K + 5, Palette[(data & 0xF00) >> 8]);
                    _bitmap.SetPixel(5 + x * K, y * K + 6, Palette[(data & 0xF0) >> 4]);
                    _bitmap.SetPixel(6 + x * K, y * K + 6, Palette[data & 0xF]);
                }
        }

        public void Render(Core core, int chargeGoal, StatusFlags status, Color gridColor)
        {
            //Clear
            Graphics gfx = Graphics.FromImage(_bitmap);
            gfx.Clear(Color.Transparent);
            Rectangle r = new Rectangle(0, 0, _lowSrc.Width, _lowSrc.Height);
            Rectangle r2 = r;
            r2.Inflate(-2, -2);
            gfx.FillRectangle(new SolidBrush(gridColor), r2);
            gfx.DrawImage(_lowSrc, r, r, GraphicsUnit.Pixel);
            //Render Memory
            int i = 0;
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                {
                    int data = core.Memory[i++];
                    _bitmap.SetPixel(5 + x * K, y * K + 7, Palette[(data & 0xF000) >> 12]);
                    _bitmap.SetPixel(6 + x * K, y * K + 7, Palette[(data & 0xF00) >> 8]);
                    _bitmap.SetPixel(5 + x * K, y * K + 8, Palette[(data & 0xF0) >> 4]);
                    _bitmap.SetPixel(6 + x * K, y * K + 8, Palette[data & 0xF]);
                }
            //Render Energy-Levels
            RenderVEnergyBar(core.Energy, 0);
            RenderVEnergyBar(core.Shield, 52);
            RenderHEnergyBar(core.Charge, chargeGoal, 53);
            //Render IP
            int px = 5 + K * (core.InstructionPointer % 16);
            int py = 7 + K * (core.InstructionPointer / 16);
            //Color instrColor = Palette[(core.Memory[core.InstructionPointer] & 0xF000) >> 12];
            //Pen pen = new Pen(instrColor);
            Pen pen = new Pen(InstructionFrameColor);
            gfx.DrawRectangle(pen, new Rectangle(px - 1, py - 1, 3, 3));
            //pen = new Pen(Color.FromArgb(32, Color.White));
            //Graphics.FromImage(_bitmap).DrawRectangle(pen, new Rectangle(px - 2, py - 2, 5, 5));
            RenderStatus(status);
        }

        private void RenderStatus(StatusFlags status)
        {
            if ((status & StatusFlags.Green) > 0)
                Blit(new Rectangle(5, 0, 9, 6));
            if ((status & StatusFlags.Yellow) > 0)
                Blit(new Rectangle(18, 0, 9, 6));
            if ((status & StatusFlags.Red) > 0)
                Blit(new Rectangle(31, 0, 9, 6));
            if ((status & StatusFlags.Blue) > 0)
                Blit(new Rectangle(44, 0, 9, 6));
        }

        private void RenderVEnergyBar(int energy, int posX)
        {
            int barHeight = (energy == 0) ? 0 : 1 + (energy * 51) / 255;
            int remainder = energy % 5;
            Blit(new Rectangle(posX, 56 - barHeight, posX + 5, barHeight));
            for (int px = posX + 4; px > posX + 4 - remainder; px--)
                _bitmap.SetPixel(px, 55 - barHeight, _highSrc.GetPixel(px, 55 - barHeight));
        }

        private void RenderHEnergyBar(int energy, int max, int posY)
        {
            if (energy == 0)
                return;
            energy = Math.Min(energy, max);
            int remainder = energy % 6;
            int offset = (int)(43 * (1 - (max / 255.0f)) * ((float)(energy) / max));
            int barWidth = (energy * 42) / 252;
            Blit(new Rectangle(7 + offset, posY, barWidth, posY + 5));
            for (int py = posY + 4; py > posY + 4 - remainder; py--)
                _bitmap.SetPixel(7 + offset + barWidth, py, _highSrc.GetPixel(7 + offset + barWidth, py));
        }

        private void Blit(Rectangle rect)
        {
            Graphics gfx = Graphics.FromImage(_bitmap);
            gfx.DrawImage(_highSrc, rect, rect, GraphicsUnit.Pixel);
        }
    }
}

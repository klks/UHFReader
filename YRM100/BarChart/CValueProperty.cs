using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CValueProperty
    {
        public enum ValueMode
        {
            Digit,
            Percent
        }

        private float fFontDefaultSize;

        private bool bVisible;

        private Font font;

        private Color color;

        private ValueMode mode;

        [Browsable(false)]
        public float FontDefaultSize
        {
            get
            {
                return fFontDefaultSize;
            }
            set
            {
                fFontDefaultSize = value;
            }
        }

        public bool Visible
        {
            get
            {
                return bVisible;
            }
            set
            {
                bVisible = value;
            }
        }

        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                FontSet(value);
                if (font != null)
                {
                    fFontDefaultSize = font.Size;
                }
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public ValueMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }

        public CValueProperty()
        {
            Mode = ValueMode.Digit;
            FontDefaultSize = 7f;
            Font = new Font("Tahoma", FontDefaultSize);
            Color = Color.FromArgb(255, 255, 255, 255);
            Visible = true;
        }

        public void FontSet(Font font)
        {
            if (this.font != null)
            {
                this.font.Dispose();
                this.font = null;
            }
            this.font = new Font(font, font.Style);
        }

        public void FontSetSize(float fNewSize)
        {
            if (this.font == null)
            {
                this.font = new Font("Tahoma", fNewSize, FontStyle.Bold);
            }
            else if (this.font.Size != fNewSize)
            {
                Font font = this.font;
                this.font = new Font(font.FontFamily, fNewSize, font.Style);
                font.Dispose();
                font = null;
            }
        }

        public void FontReset()
        {
            string text = "Tahoma";
            FontStyle fontStyle = FontStyle.Bold;
            if (font != null)
            {
                if (font.Size == fFontDefaultSize)
                {
                    return;
                }
                if (font.Name != text)
                {
                    text = font.Name;
                }
                if (font.Style != fontStyle)
                {
                    fontStyle = font.Style;
                }
                font.Dispose();
                font = null;
            }
            if (FontDefaultSize <= 0f)
            {
                font = null;
            }
            else
            {
                font = new Font(text, FontDefaultSize, fontStyle);
            }
        }
    }
}

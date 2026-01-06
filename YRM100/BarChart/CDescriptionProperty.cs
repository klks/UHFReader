using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CDescriptionProperty
    {
        private string text;

        private bool bVisible;

        private Font font;

        private Color color;

        private float fFontDefaultSize;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
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

        public CDescriptionProperty()
        {
            fFontDefaultSize = 14f;
            Font = new Font("Tahoma", fFontDefaultSize, FontStyle.Bold);
            Color = Color.FromArgb(255, 255, 255, 255);
            Text = string.Empty;
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

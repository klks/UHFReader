using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CShadowProperty
    {
        public enum Modes
        {
            None,
            Inner,
            Outer,
            Both
        }

        private int nSizeOuter;

        private int nSizeInner;

        private Color colorOuter;

        private Color colorInner;

        private Pen pen;

        private Pen penBack;

        private Modes mode;

        private RectangleF rectOuter;

        private RectangleF rectInner;

        [Browsable(true)]
        public Color ColorOuter
        {
            get
            {
                return colorOuter;
            }
            set
            {
                colorOuter = value;
            }
        }

        [Browsable(true)]
        public Color ColorInner
        {
            get
            {
                return colorInner;
            }
            set
            {
                colorInner = value;
            }
        }

        [Browsable(true)]
        public int WidthOuter
        {
            get
            {
                return nSizeOuter;
            }
            set
            {
                nSizeOuter = value;
            }
        }

        [Browsable(true)]
        public int WidthInner
        {
            get
            {
                return nSizeInner;
            }
            set
            {
                nSizeInner = value;
            }
        }

        [Browsable(true)]
        public Modes Mode
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

        public CShadowProperty()
        {
            pen = null;
            colorInner = Color.FromArgb(100, 0, 0, 0);
            colorOuter = Color.FromArgb(100, 0, 0, 0);
            nSizeInner = 5;
            nSizeOuter = 5;
            rectInner = RectangleF.Empty;
            rectOuter = RectangleF.Empty;
            mode = Modes.Inner;
        }

        public void SetRect(RectangleF rect, int nIndex)
        {
            SetRect(rect.X, rect.Y, rect.Width, rect.Height, nIndex);
        }

        public void SetRect(float x, float y, float width, float height, int nIndex)
        {
            if (nIndex == 0)
            {
                rectInner.X = x;
                rectInner.Y = y;
                rectInner.Width = width;
                rectInner.Height = height;
            }
            else
            {
                rectOuter.X = x;
                rectOuter.Y = y;
                rectOuter.Width = width;
                rectOuter.Height = height;
            }
        }

        public void Draw(Graphics gr, Color colorBK)
        {
            if (mode == Modes.None)
            {
                return;
            }
            if (mode == Modes.Outer || mode == Modes.Both)
            {
                if (nSizeOuter <= 0 || nSizeOuter > colorOuter.A)
                {
                    return;
                }
                DrawOuterShadow(gr, colorBK);
            }
            if ((mode == Modes.Inner || mode == Modes.Both) && nSizeInner > 0 && nSizeInner <= colorInner.A)
            {
                DrawInnerShadow(gr);
            }
        }

        private void DrawInnerShadow(Graphics gr)
        {
            _ = rectInner;
            if (!(rectInner == Rectangle.Empty))
            {
                if (pen == null)
                {
                    pen = new Pen(colorInner);
                }
                if (pen.Color != colorInner)
                {
                    pen.Color = colorInner;
                }
                Rectangle rect = new Rectangle((int)(rectInner.X + pen.Width / 2f), (int)(rectInner.Y + pen.Width / 2f), (int)(rectInner.Width - pen.Width), (int)(rectInner.Height - pen.Width));
                int num = colorInner.A / nSizeInner;
                if (num <= 0)
                {
                    num = 1;
                }
                for (int num2 = colorInner.A; num2 > 0; num2 -= num)
                {
                    pen.Color = Color.FromArgb(num2, pen.Color);
                    gr.DrawRectangle(pen, rect);
                    rect.Inflate(-1, -1);
                }
            }
        }

        private void DrawOuterShadow(Graphics gr, Color colorBK)
        {
            _ = rectOuter;
            if (!(rectOuter == Rectangle.Empty))
            {
                if (penBack == null || penBack.Width != (float)nSizeOuter || penBack.Color != colorBK)
                {
                    penBack = new Pen(colorBK, nSizeOuter);
                }
                gr.DrawRectangle(penBack, new Rectangle((int)(rectOuter.X + penBack.Width / 2f), (int)(rectOuter.Y + penBack.Width / 2f), (int)(rectOuter.Width - penBack.Width), (int)(rectOuter.Height - penBack.Width)));
                if (pen == null)
                {
                    pen = new Pen(colorOuter, 1f);
                }
                if (pen.Color != colorOuter)
                {
                    pen.Color = colorOuter;
                }
                Rectangle rect = new Rectangle((int)(rectOuter.X + pen.Width / 2f), (int)(rectOuter.Y + pen.Width / 2f), (int)(rectOuter.Width - pen.Width), (int)(rectOuter.Height - pen.Width));
                int num = colorOuter.A / nSizeOuter;
                if (num <= 0)
                {
                    num = 1;
                }
                for (int i = 0; i < colorOuter.A; i += num)
                {
                    pen.Color = Color.FromArgb(i, pen.Color);
                    gr.DrawRectangle(pen, rect);
                    rect.Inflate(-1, -1);
                }
            }
        }
    }
}

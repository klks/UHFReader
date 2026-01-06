using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CBorderProperty
    {
        private int nSize;

        private Color color;

        private bool bVisible;

        private Pen pen;

        private RectangleF rectBound;

        [Browsable(true)]
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

        [Browsable(true)]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                ResetPen();
            }
        }

        [Browsable(true)]
        public int Width
        {
            get
            {
                return nSize;
            }
            set
            {
                nSize = value;
                ResetPen();
            }
        }

        [Browsable(false)]
        public RectangleF BoundRect
        {
            get
            {
                return rectBound;
            }
            set
            {
                rectBound = value;
            }
        }

        public CBorderProperty()
        {
            pen = null;
            BoundRect = new RectangleF(0f, 0f, 0f, 0f);
            Visible = true;
            Color = Color.White;
            Width = 1;
        }

        private void ResetPen()
        {
            if (pen != null)
            {
                pen.Dispose();
                pen = null;
            }
            if (nSize > 0)
            {
                pen = new Pen(color, nSize);
            }
        }

        public void Draw(Graphics gr)
        {
            _ = rectBound;
            if (rectBound == RectangleF.Empty)
            {
                rectBound = gr.VisibleClipBounds;
            }
            if (bVisible)
            {
                if (pen == null)
                {
                    ResetPen();
                }
                if (pen != null)
                {
                    gr.DrawRectangle(pen, rectBound.X + (float)(Width / 2), rectBound.Y + (float)(Width / 2), rectBound.Width - (float)Width, rectBound.Height - (float)Width);
                }
            }
        }

        internal void SetRect(Rectangle rect)
        {
            rectBound.X = rect.X;
            rectBound.Y = rect.Y;
            rectBound.Width = rect.Width;
            rectBound.Height = rect.Height;
        }
    }
}

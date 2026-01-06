using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace YRM100.BarChart
{
    public class HBarItem : ICloneable
    {
        private HBarItems parent;

        protected RectangleF rectBar;

        public RectangleF BoundRect;

        public RectangleF ValueRect;

        public RectangleF LabelRect;

        protected Color colorBar;

        protected string strLabel;

        protected double dValue;

        protected double dOffset;

        private bool bShowBorder;

        private Color ColorBacklightEnd;

        private Color ColorGlowStart;

        private Color ColorGlowEnd;

        private Color ColorFillBK;

        private Color ColorBorder;

        private SolidBrush brushFill;

        private RectangleF rectGradient;

        private GraphicsPath pathGradient;

        private PathGradientBrush brushGradient;

        private Color[] ColorGradientSurround;

        private LinearGradientBrush brushGlow;

        private RectangleF rectGlow;

        private PointF gradientCenterPoint;

        public HBarItems Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public RectangleF BarRect
        {
            get
            {
                return rectBar;
            }
            set
            {
                rectBar = value;
                CreateGlowBrush();
            }
        }

        public Color Color
        {
            get
            {
                return colorBar;
            }
            set
            {
                colorBar = value;
                ColorFillBK = GetDarkerColor(Color, 85);
                ColorBorder = GetDarkerColor(Color, 100);
                if (brushFill != null)
                {
                    brushFill.Dispose();
                    brushFill = null;
                }
                brushFill = new SolidBrush(ColorFillBK);
            }
        }

        [Localizable(true)]
        public string Label
        {
            get
            {
                return strLabel;
            }
            set
            {
                strLabel = value;
            }
        }

        public double Value
        {
            get
            {
                return dValue;
            }
            set
            {
                dValue = value;
                if (Parent != null)
                {
                    Parent.ShouldReCalculate = true;
                }
            }
        }

        public double Offset
        {
            get
            {
                return dOffset;
            }
            set
            {
                dOffset = value;
                if (Parent != null)
                {
                    Parent.ShouldReCalculate = true;
                }
            }
        }

        public bool ShowBorder
        {
            get
            {
                return bShowBorder;
            }
            set
            {
                bShowBorder = value;
            }
        }

        public HBarItem(double dValue, string strLabel, Color colorBar, RectangleF rectfBar, RectangleF rectfBound, HBarItems Parent)
            : this(dValue, strLabel, colorBar, rectfBar, rectfBound)
        {
            this.Parent = Parent;
        }

        public HBarItem(double dValue, string strLabel, Color colorBar, RectangleF rectfBar, RectangleF rectfBound)
            : this(dValue, strLabel, colorBar, rectfBar)
        {
            BarRect = rectfBound;
        }

        public HBarItem(double dValue, string strLabel, Color colorBar, RectangleF barRect)
            : this(dValue, strLabel, colorBar)
        {
            rectBar = barRect;
        }

        public HBarItem(double dValue, double dOffset, string strLabel, Color colorBar)
            : this(dValue, strLabel, colorBar)
        {
            Offset = dOffset;
        }

        public HBarItem(double dValue, string strLabel, Color colorBar)
            : this()
        {
            Value = dValue;
            Label = strLabel;
            Color = colorBar;
        }

        public HBarItem()
        {
            colorBar = Color.Empty;
            Value = 0.0;
            Label = string.Empty;
            Parent = null;
            ColorBacklightEnd = Color.FromArgb(80, 0, 0, 0);
            ColorGradientSurround = new Color[1] { ColorBacklightEnd };
            ShowBorder = true;
            BarRect = RectangleF.Empty;
            BoundRect = new RectangleF(0f, 0f, 0f, 0f);
        }

        object ICloneable.Clone()
        {
            return new HBarItem(Value, Label, Color, BarRect, BoundRect);
        }

        public object Clone()
        {
            return new HBarItem(Value, Label, Color, BarRect, BoundRect);
        }

        private void CreateGradientBrush()
        {
            if (pathGradient == null)
            {
                pathGradient = new GraphicsPath();
            }
            if (brushGradient != null)
            {
                brushGradient.Dispose();
                brushGradient = null;
            }
            rectGradient.X = rectBar.Left - rectBar.Width / 8f;
            rectGradient.Y = rectBar.Top - rectBar.Height / 2f;
            rectGradient.Width = rectBar.Width * 2f;
            rectGradient.Height = rectBar.Height * 2f;
            gradientCenterPoint.X = rectBar.Right;
            gradientCenterPoint.Y = rectBar.Top + rectBar.Height / 2f;
            pathGradient.Reset();
            pathGradient.AddEllipse(rectGradient);
            brushGradient = new PathGradientBrush(pathGradient);
            brushGradient.CenterPoint = gradientCenterPoint;
            brushGradient.CenterColor = Color;
            brushGradient.SurroundColors = ColorGradientSurround;
        }

        private void CreateGlowBrush()
        {
            if (rectBar.Height <= 0f)
            {
                rectBar.Height = 1f;
            }
            int num = (int)(185f + 5f * BarRect.Width / 24f);
            int num2 = (int)(10f + 4f * BarRect.Width / 24f);
            if (num > 255)
            {
                num = 255;
            }
            else if (num < 0)
            {
                num = 0;
            }
            if (num2 > 255)
            {
                num2 = 255;
            }
            else if (num2 < 0)
            {
                num2 = 0;
            }
            ColorGlowStart = Color.FromArgb(num2, 255, 255, 255);
            ColorGlowEnd = Color.FromArgb(num, 255, 255, 255);
            if (brushGlow != null)
            {
                brushGlow.Dispose();
                brushGlow = null;
            }
            rectGlow = new RectangleF(rectBar.Left, rectBar.Top, rectBar.Width / 2f, rectBar.Height);
            brushGlow = new LinearGradientBrush(new PointF(rectGlow.Right + 1f, rectGlow.Top), new PointF(rectGlow.Left - 1f, rectGlow.Top), ColorGlowStart, ColorGlowEnd);
        }

        public void Draw(Graphics gr)
        {
            if (!(BarRect.Width <= 0f) && !(BarRect.Height <= 0f))
            {
                if (parent.DrawingMode == HBarItems.DrawingModes.Solid)
                {
                    gr.FillRectangle(new SolidBrush(Color), BarRect);
                }
                else
                {
                    gr.FillRectangle(brushFill, BarRect);
                }
                if (parent.DrawingMode == HBarItems.DrawingModes.Glass || parent.DrawingMode == HBarItems.DrawingModes.Rubber)
                {
                    CreateGradientBrush();
                    gr.FillRectangle(brushGradient, BarRect);
                }
                if (parent.DrawingMode == HBarItems.DrawingModes.Glass)
                {
                    gr.FillRectangle(brushGlow, rectGlow);
                }
                if (ShowBorder)
                {
                    gr.DrawRectangle(new Pen(ColorBorder, 1f), rectBar.Left, rectBar.Top, rectBar.Width, rectBar.Height);
                }
            }
        }

        private Color GetDarkerColor(Color color, byte intensity)
        {
            int num = color.R - intensity;
            int num2 = color.G - intensity;
            int num3 = color.B - intensity;
            if (num > 255 || num < 0)
            {
                num *= -1;
            }
            if (num2 > 255 || num2 < 0)
            {
                num2 *= -1;
            }
            if (num3 > 255 || num3 < 0)
            {
                num3 *= -1;
            }
            return Color.FromArgb(255, (byte)num, (byte)num2, (byte)num3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CBackgroundProperty
    {
        public enum PaintingModes
        {
            SolidColor,
            LinearGradient,
            RadialGradient
        }

        private Color gradientColor1;

        private Color gradientColor2;

        private Color solidColor;

        private PaintingModes paintingMode;

        private Brush brush;

        private RectangleF rectBound;

        [Browsable(false)]
        private RectangleF rectGradient;

        [Browsable(false)]
        private GraphicsPath pathGradient;

        [Browsable(false)]
        private PointF radialCenterPoint;

        [Browsable(true)]
        public PaintingModes PaintingMode
        {
            get
            {
                return paintingMode;
            }
            set
            {
                if (value != paintingMode)
                {
                    paintingMode = value;
                    ResetBrush();
                }
            }
        }

        [Browsable(true)]
        public Color SolidColor
        {
            get
            {
                return solidColor;
            }
            set
            {
                solidColor = value;
                ResetBrush();
            }
        }

        [Browsable(true)]
        public Color GradientColor2
        {
            get
            {
                return gradientColor2;
            }
            set
            {
                gradientColor2 = value;
                ResetBrush();
            }
        }

        [Browsable(true)]
        public Color GradientColor1
        {
            get
            {
                return gradientColor1;
            }
            set
            {
                gradientColor1 = value;
                ResetBrush();
            }
        }

        [Browsable(false)]
        public RectangleF BoundRect => rectBound;

        public void SetBoundRect(RectangleF boundRect)
        {
            rectBound.X = boundRect.X;
            rectBound.Y = boundRect.Y;
            rectBound.Width = boundRect.Width;
            rectBound.Height = boundRect.Height;
        }

        public CBackgroundProperty()
        {
            brush = null;
            paintingMode = PaintingModes.RadialGradient;
            gradientColor1 = Color.FromArgb(255, 140, 210, 245);
            gradientColor2 = Color.FromArgb(255, 0, 30, 90);
            solidColor = gradientColor2;
            rectGradient = RectangleF.Empty;
            pathGradient = new GraphicsPath();
        }

        private void ResetBrush()
        {
            if (brush != null)
            {
                brush.Dispose();
                brush = null;
            }
            if (PaintingMode == PaintingModes.LinearGradient)
            {
                if (!(BoundRect.Height <= 0f))
                {
                    brush = new LinearGradientBrush(new Point((int)BoundRect.X, (int)BoundRect.Y), new Point((int)BoundRect.X, (int)BoundRect.Bottom), GradientColor1, GradientColor2);
                }
            }
            else if (PaintingMode == PaintingModes.RadialGradient)
            {
                CreateGradientBrush();
            }
            else
            {
                brush = new SolidBrush(SolidColor);
            }
        }

        private void CreateGradientBrush()
        {
            _ = rectBound;
            if (!(rectBound.Width < 1f) && !(rectBound.Height < 1f))
            {
                rectGradient.X = rectBound.Left - rectBound.Width / 2f;
                rectGradient.Y = rectBound.Top - rectBound.Height / 3f;
                rectGradient.Width = rectBound.Width * 2f;
                rectGradient.Height = rectBound.Height + rectBound.Height / 2f;
                radialCenterPoint.X = rectBound.Left + rectBound.Width / 2f;
                radialCenterPoint.Y = rectBound.Top + rectBound.Height / 2f;
                pathGradient.Reset();
                pathGradient.AddEllipse(rectGradient);
                PathGradientBrush pathGradientBrush = new PathGradientBrush(pathGradient);
                pathGradientBrush.CenterPoint = radialCenterPoint;
                pathGradientBrush.CenterColor = gradientColor1;
                pathGradientBrush.SurroundColors = new Color[1] { gradientColor2 };
                brush = pathGradientBrush;
                pathGradientBrush = null;
            }
        }

        public void Draw(Graphics gr, RectangleF rectBound)
        {
            SetBoundRect(rectBound);
            ResetBrush();
            if (brush != null)
            {
                gr.FillRectangle(brush, rectBound);
            }
        }
    }
}

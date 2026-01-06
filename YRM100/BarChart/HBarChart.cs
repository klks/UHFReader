using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace YRM100.BarChart
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    [ToolboxBitmap(typeof(HBarChart), "BarChart.bmp")]
    public class HBarChart : UserControl
    {
        public enum BarSizingMode
        {
            Normal,
            AutoScale
        }

        public delegate void OnBarEvent(object sender, BarEventArgs e);

        private CDescriptionProperty description;

        private CLabelProperty label;

        private CValueProperty values;

        private CBackgroundProperty background;

        private BarSizingMode sizingMode;

        private CBorderProperty border;

        private CShadowProperty shadow;

        private int nBarWidth;

        private int nBarsGap;

        private CDataSourceManager dataSourceManager;

        private Rectangle rectBK;

        private Rectangle bounds;

        private RectangleF rectDesc;

        protected HBarItems bars;

        protected ToolTip tooltip;

        private Bitmap bmpBackBuffer;

        [Browsable(false)]
        private int nLastVisitedBarIndex;

        [Browsable(false)]
        private Point ptLastTooltipMouseLoction;

        private IContainer components;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("A collection of chart items. A bar for each item will be drawn.")]
        public HBarItems Items
        {
            get
            {
                return bars;
            }
            set
            {
                bars = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Look and feel of the description line at the bottom of the chart.")]
        public CDescriptionProperty Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Settings of the border around the chart.")]
        public CBorderProperty Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Settings of the shadows around the chart.")]
        public CShadowProperty Shadow
        {
            get
            {
                return shadow;
            }
            set
            {
                shadow = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Look and feel of the label at the bottom of each bar.")]
        public CLabelProperty Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Look and feel of the Value/Percent presented at the top of each bar.")]
        public CValueProperty Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Chart background style and colors.")]
        public CBackgroundProperty Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public int BarWidth
        {
            get
            {
                return nBarWidth;
            }
            set
            {
                nBarWidth = value;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public int BarsGap
        {
            get
            {
                return nBarsGap;
            }
            set
            {
                nBarsGap = value;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public ToolTip BarTooltip
        {
            get
            {
                return tooltip;
            }
            set
            {
                tooltip = value;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public BarSizingMode SizingMode
        {
            get
            {
                return sizingMode;
            }
            set
            {
                sizingMode = value;
            }
        }

        [Browsable(false)]
        [Category("Bar Chart")]
        public int Count => bars.Count;

        [DefaultValue("")]
        [Category("Bar Chart")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [Description("Defines data member of the connected data source. Chart reads data of this data member.")]
        public string DataMember
        {
            get
            {
                if (dataSourceManager == null)
                {
                    return string.Empty;
                }
                return dataSourceManager.DataMember;
            }
            set
            {
                if (value != DataMember)
                {
                    if (dataSourceManager == null)
                    {
                        CreateChartForEachRow dataEventHandler = new CreateChartForEachRow();
                        dataSourceManager = new CDataSourceManager(this);
                        dataSourceManager.DataEventHandler = dataEventHandler;
                    }
                    dataSourceManager.ConnectTo(DataSource, value);
                }
            }
        }

        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        [Category("Bar Chart")]
        [Description("Defines Data Source to connected to.")]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        public object DataSource
        {
            get
            {
                if (dataSourceManager == null)
                {
                    return null;
                }
                return dataSourceManager.DataSource;
            }
            set
            {
                if (value == DataSource)
                {
                    return;
                }
                if (dataSourceManager == null)
                {
                    CreateChartForEachRow dataEventHandler = new CreateChartForEachRow();
                    dataSourceManager = new CDataSourceManager(this);
                    dataSourceManager.DataEventHandler = dataEventHandler;
                    dataSourceManager.ConnectTo(value, DataMember);
                }
                else
                {
                    dataSourceManager.ConnectTo(value, DataMember);
                    if (value == null)
                    {
                        dataSourceManager = null;
                    }
                }
            }
        }

        [Browsable(false)]
        public CDataSourceManager DataSourceManager => dataSourceManager;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Mouse is now over a bar rectangle starting from top of the chart, left of the bar and ending right of the bar and bottom of the chart.")]
        public event OnBarEvent BarMouseEnter;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Mouse just hovered out a bar.")]
        public event OnBarEvent BarMouseLeave;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Mouse click event occurd while mouse is over a bar.")]
        public event OnBarEvent BarClicked;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Bar Chart")]
        [Description("Mouse double click event occurd while mouse is over a bar")]
        public event OnBarEvent BarDoubleClicked;

        private void RaiseClickEvent(HBarItem bar, int nIndex)
        {
            if (this.BarClicked != null)
            {
                this.BarClicked(this, new BarEventArgs(bar, nIndex));
            }
        }

        private void RaiseDoubleClickEvent(HBarItem bar, int nIndex)
        {
            if (this.BarDoubleClicked != null)
            {
                this.BarDoubleClicked(this, new BarEventArgs(bar, nIndex));
            }
        }

        private void RaiseHoverInEvent(HBarItem bar, int nIndex)
        {
            if (this.BarMouseEnter != null)
            {
                this.BarMouseEnter(this, new BarEventArgs(bar, nIndex));
            }
        }

        private void RaiseHoverOutEvent(HBarItem bar, int nIndex)
        {
            if (this.BarMouseLeave != null)
            {
                this.BarMouseLeave(this, new BarEventArgs(bar, nIndex));
            }
        }

        public void RedrawChart()
        {
            if (bmpBackBuffer != null)
            {
                bmpBackBuffer.Dispose();
                bmpBackBuffer = null;
            }
            Refresh();
        }

        public void Add(double dValue, string strLabel, Color colorBar)
        {
            bars.Add(new HBarItem(dValue, strLabel, colorBar));
        }

        public bool RemoveAt(int nIndex)
        {
            if (nIndex < 0 || nIndex >= bars.Count)
            {
                return false;
            }
            bars.RemoveAt(nIndex);
            return true;
        }

        public bool GetAt(int nIndex, out HBarItem bar)
        {
            bar = null;
            if (nIndex < 0 || nIndex >= bars.Count)
            {
                return false;
            }
            bar = bars[nIndex];
            return true;
        }

        public bool ModifyAt(int nIndex, double dNewValue)
        {
            if (nIndex < 0 || nIndex >= bars.Count)
            {
                return false;
            }
            bars[nIndex].Value = dNewValue;
            return true;
        }

        public bool ModifyAt(int nIndex, HBarItem barNew)
        {
            if (nIndex < 0 || nIndex >= bars.Count)
            {
                return false;
            }
            bars.RemoveAt(nIndex);
            bars.Insert(nIndex, barNew);
            return true;
        }

        public bool InsertAt(int nIndex, double dValue, string strLabel, Color colorBar)
        {
            if (nIndex < 0 || nIndex >= bars.Count)
            {
                return false;
            }
            bars.Insert(nIndex, new HBarItem(dValue, strLabel, colorBar));
            return true;
        }

        public bool Print(bool bFitToPaper, string strDocName)
        {
            CPrinter cPrinter = new CPrinter();
            cPrinter.ShowOptions();
            cPrinter.Document.DocumentName = strDocName;
            cPrinter.FitToPaper = bFitToPaper;
            Bitmap bmp = ((!bFitToPaper) ? ((Bitmap)bmpBackBuffer.Clone()) : new Bitmap(cPrinter.Document.DefaultPageSettings.Bounds.Width, cPrinter.Document.DefaultPageSettings.Bounds.Height));
            DrawChart(ref bmp);
            cPrinter.BmpBuffer = bmp;
            bool result = cPrinter.Print();
            bmp.Dispose();
            bmp = null;
            return result;
        }

        private void OnSize(object sender, EventArgs e)
        {
            RedrawChart();
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            if (dataSourceManager != null)
            {
                try
                {
                    dataSourceManager.ConnectTo(DataSource, DataMember);
                    return;
                }
                catch (ArgumentException)
                {
                    if (base.DesignMode)
                    {
                        DataMember = string.Empty;
                        return;
                    }
                    throw;
                }
            }
            base.OnBindingContextChanged(e);
        }

        internal void Add(object nullObject)
        {
            Add(0.0, "N/A", Color.Black);
        }

        public HBarChart()
        {
            bounds = new Rectangle(0, 0, 0, 0);
            border = new CBorderProperty();
            shadow = new CShadowProperty();
            rectDesc = new RectangleF(0f, 0f, 0f, 0f);
            SetStyle(ControlStyles.UserPaint, value: true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            SetStyle(ControlStyles.ResizeRedraw, value: true);
            InitializeComponent();
            description = new CDescriptionProperty();
            label = new CLabelProperty();
            values = new CValueProperty();
            background = new CBackgroundProperty();
            nBarWidth = 24;
            nBarsGap = 4;
            SizingMode = BarSizingMode.Normal;
            bars = new HBarItems();
            bmpBackBuffer = null;
            ptLastTooltipMouseLoction = new Point(0, 0);
            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.InitialDelay = 100;
            tooltip.ReshowDelay = 100;
            nLastVisitedBarIndex = -1;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (bmpBackBuffer == null)
            {
                DrawChart(ref bmpBackBuffer);
            }
            if (bmpBackBuffer != null)
            {
                e.Graphics.DrawImage(bmpBackBuffer, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        private void DrawChart(ref Bitmap bmp)
        {
            if (bmp == null)
            {
                bmp = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
            }
            using Graphics gr = Graphics.FromImage(bmp);
            CalculateBound(bmp.Size);
            Background.Draw(gr, rectBK);
            DrawBars(gr, bmp.Size);
        }

        private void CalculateBound(Size sizeClient)
        {
            bounds = new Rectangle(0, 0, sizeClient.Width, sizeClient.Height);
            if (shadow.Mode == CShadowProperty.Modes.Outer || shadow.Mode == CShadowProperty.Modes.Both)
            {
                shadow.SetRect(bounds, 1);
                bounds.X += shadow.WidthOuter;
                bounds.Y += shadow.WidthOuter;
                bounds.Width -= 2 * shadow.WidthOuter;
                bounds.Height -= 2 * shadow.WidthOuter;
            }
            rectBK = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            if (border != null && Border.Visible)
            {
                border.SetRect(bounds);
                bounds.X += Border.Width;
                bounds.Y += Border.Width;
                bounds.Width -= 2 * Border.Width;
                bounds.Height -= 2 * Border.Width;
            }
            if (shadow.Mode == CShadowProperty.Modes.Inner || shadow.Mode == CShadowProperty.Modes.Both)
            {
                shadow.SetRect(bounds, 0);
            }
        }

        private void DrawBars(Graphics gr, Size sizeChart)
        {
            if (description == null || label == null || values == null)
            {
                return;
            }
            int num = nBarsGap;
            if (SizingMode == BarSizingMode.AutoScale)
            {
                int num2 = nBarWidth;
                if (bars.Count > 0)
                {
                    nBarsGap = 4 + 12 * bounds.Width / (345 * bars.Count * 7);
                    if (nBarsGap > 50)
                    {
                        nBarsGap = 50;
                    }
                    nBarWidth = (bounds.Width - (bars.Count + 1) * nBarsGap) / bars.Count;
                    if (nBarWidth <= 0)
                    {
                        nBarWidth = 24;
                    }
                }
                CreateLabelFont(gr, new Size(nBarWidth, 0));
                CreateValueFont(gr, new Size(nBarWidth, 0));
                CreateDescFont(gr, bounds.Size);
                CalculatePositions(gr);
                nBarWidth = num2;
            }
            else
            {
                if (values.Font == null || values.Font.Size != values.FontDefaultSize)
                {
                    Values.FontReset();
                }
                if (Label.Font == null || Label.Font.Size != Label.FontDefaultSize)
                {
                    Label.FontReset();
                }
                if (Description.Font == null || Description.Font.Size != Description.FontDefaultSize)
                {
                    Description.FontReset();
                }
                CalculatePositions(gr);
            }
            shadow.Draw(gr, BackColor);
            if (Description.Visible && Description.Font != null)
            {
                StringFormat genericDefault = StringFormat.GenericDefault;
                genericDefault.LineAlignment = StringAlignment.Center;
                genericDefault.Alignment = StringAlignment.Center;
                genericDefault.Trimming = StringTrimming.None;
                genericDefault.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                gr.DrawString(description.Text, description.Font, new SolidBrush(description.Color), rectDesc, genericDefault);
            }
            foreach (HBarItem bar in bars)
            {
                bar.Draw(gr);
                if (Label.Visible)
                {
                    gr.DrawString(bar.Label, Label.Font, new SolidBrush(Label.Color), bar.LabelRect);
                }
                if (Values.Visible)
                {
                    string s = string.Empty;
                    if (Values.Mode == CValueProperty.ValueMode.Digit)
                    {
                        s = bar.Value.ToString("F1");
                    }
                    else if (Values.Mode == CValueProperty.ValueMode.Percent && bars.ABSTotal != 0.0)
                    {
                        s = (bar.Value / bars.ABSTotal).ToString("P1", CultureInfo.CurrentCulture);
                    }
                    gr.DrawString(s, Values.Font, new SolidBrush(Values.Color), bar.ValueRect);
                }
            }
            border.Draw(gr);
            nBarsGap = num;
        }

        private void CalculatePositions(Graphics gr)
        {
            int num = 0;
            bool flag = bars.Maximum < 0.0 || bars.Minimum < 0.0;
            bool flag2 = bars.Maximum < 0.0 && bars.Minimum < 0.0;
            float num2 = 0f;
            float num3 = 0f;
            int num4 = bounds.X + (bounds.Width - bars.Count * nBarWidth - (bars.Count + 1) * nBarsGap) / 2;
            if (Description != null && Description.Visible && Description.Font != null && gr != null)
            {
                rectDesc.X = bounds.X + nBarsGap;
                rectDesc.Y = (float)(bounds.Bottom - 2 * nBarsGap) - Description.Font.GetHeight(gr);
                rectDesc.Width = bounds.Size.Width - 2 * nBarsGap;
                rectDesc.Height = description.Font.GetHeight(gr) + (float)(2 * nBarsGap);
            }
            else
            {
                rectDesc = RectangleF.Empty;
            }
            foreach (HBarItem bar in bars)
            {
                if (flag)
                {
                    bar.BoundRect.X = num4 + num * nBarWidth + (num + 1) * nBarsGap;
                    bar.BoundRect.Width = nBarWidth;
                    if (flag2)
                    {
                        bar.BoundRect.Height = (float)bounds.Height - rectDesc.Height;
                        bar.BoundRect.Y = bounds.Y + nBarsGap;
                    }
                    else
                    {
                        bar.BoundRect.Height = ((float)bounds.Height - rectDesc.Height) / 2f + Label.Font.GetHeight(gr) + (float)(nBarsGap / 2);
                        if (bar.Value > 0.0)
                        {
                            bar.BoundRect.Y = bounds.Y + nBarsGap;
                        }
                        else
                        {
                            bar.BoundRect.Y = ((float)bounds.Height - rectDesc.Height) / 2f - Label.Font.GetHeight(gr) - (float)(nBarsGap / 2);
                        }
                    }
                    bar.LabelRect.X = bar.BoundRect.X;
                    bar.LabelRect.Width = bar.BoundRect.Width + (float)nBarsGap;
                    bar.LabelRect.Height = Label.Font.GetHeight(gr);
                    if (flag2)
                    {
                        bar.LabelRect.Y = nBarsGap;
                    }
                    else if (bar.Value >= 0.0)
                    {
                        bar.LabelRect.Y = bar.BoundRect.Bottom - (float)(nBarsGap / 2) - bar.LabelRect.Height;
                    }
                    else
                    {
                        bar.LabelRect.Y = (float)bounds.Y + bar.BoundRect.Top;
                    }
                    num2 = bar.BoundRect.Height - (float)(2 * nBarsGap) - bar.LabelRect.Height - values.Font.GetHeight(gr);
                    num3 = (float)(Math.Abs(bar.Value) * (double)num2 / bars.ABSMaximum);
                    if (!(num3 >= 0f))
                    {
                        num3 = 0f;
                    }
                    if (flag2)
                    {
                        bar.BarRect = new RectangleF(bar.BoundRect.X, bar.LabelRect.Bottom + (float)nBarsGap, bar.BoundRect.Width, num3);
                        bar.ValueRect.X = bar.BoundRect.X;
                        bar.ValueRect.Y = bar.BarRect.Bottom + (float)nBarsGap;
                        bar.ValueRect.Width = bar.BoundRect.Width;
                        bar.ValueRect.Height = values.Font.GetHeight(gr);
                    }
                    else
                    {
                        bar.BarRect = new RectangleF(bar.BoundRect.X, (float)bounds.Y + ((bar.Value > 0.0) ? (((float)bounds.Height - rectDesc.Height) / 2f - num3) : (((float)bounds.Height - rectDesc.Height) / 2f)), bar.BoundRect.Width, num3);
                        bar.ValueRect.X = bar.BoundRect.X;
                        bar.ValueRect.Y = ((bar.Value > 0.0) ? (bar.BarRect.Top - values.Font.GetHeight(gr)) : (bar.BarRect.Bottom + (float)(nBarsGap / 2)));
                        bar.ValueRect.Width = bar.BoundRect.Width + (float)nBarsGap;
                        bar.ValueRect.Height = values.Font.GetHeight(gr);
                    }
                }
                else
                {
                    bar.BoundRect.X = num4 + num * nBarWidth + (num + 1) * nBarsGap;
                    bar.BoundRect.Y = bounds.Y + nBarsGap;
                    bar.BoundRect.Width = nBarWidth;
                    bar.BoundRect.Height = (float)bounds.Height - rectDesc.Height;
                    if (Label.Visible)
                    {
                        bar.LabelRect.X = bar.BoundRect.X;
                        bar.LabelRect.Y = (float)bounds.Bottom - rectDesc.Height - Label.Font.GetHeight(gr);
                        bar.LabelRect.Width = bar.BoundRect.Width + (float)nBarsGap;
                        bar.LabelRect.Height = Label.Font.GetHeight(gr);
                    }
                    else
                    {
                        bar.LabelRect = RectangleF.Empty;
                    }
                    num2 = bar.BoundRect.Height - (float)(2 * nBarsGap) - bar.LabelRect.Height - (values.Visible ? values.Font.GetHeight(gr) : 0f);
                    num3 = (float)(Math.Abs(bar.Value) * (double)num2 / bars.ABSMaximum);
                    if (!(num3 >= 0f))
                    {
                        num3 = 0f;
                    }
                    bar.BarRect = new RectangleF(bar.BoundRect.X, bar.BoundRect.Y + num2 - num3 + (values.Visible ? values.Font.GetHeight(gr) : 0f), bar.BoundRect.Width, num3);
                    if (Values.Visible)
                    {
                        bar.ValueRect.X = bar.BoundRect.X;
                        bar.ValueRect.Y = bar.BarRect.Top - values.Font.GetHeight(gr) - (float)(nBarsGap / 2);
                        bar.ValueRect.Width = bar.BoundRect.Width + (float)(2 * nBarsGap);
                        bar.ValueRect.Height = values.Font.GetHeight(gr);
                    }
                    else
                    {
                        bar.ValueRect = RectangleF.Empty;
                    }
                }
                num++;
            }
        }

        private void CreateValueFont(Graphics gr, SizeF sizeBar)
        {
            float num = 100f + sizeBar.Width / 24f;
            float num2 = 0f;
            string text = string.Empty;
            float num3;
            for (int i = 0; i < bars.Count; i++)
            {
                if (Values.Mode == CValueProperty.ValueMode.Digit)
                {
                    text = $"{bars[i].Value:F1}";
                }
                else if (Values.Mode == CValueProperty.ValueMode.Percent && bars.ABSTotal > 0.0)
                {
                    text = (bars[i].Value / bars.ABSTotal).ToString("P1", CultureInfo.CurrentCulture);
                }
                num3 = gr.MeasureString(text, Values.Font).Width;
                if (num3 > num2)
                {
                    num2 = num3;
                }
            }
            num3 = Values.Font.Size * (sizeBar.Width / num2);
            if (!(num <= 0f) || !(num3 <= 0f))
            {
                if (num <= 0f)
                {
                    Values.FontSetSize(num3);
                }
                else if (num3 <= 0f)
                {
                    Values.FontSetSize(num);
                }
                else
                {
                    Values.FontSetSize((num > num3) ? num3 : num);
                }
            }
        }

        private void CreateLabelFont(Graphics gr, SizeF sizeBar)
        {
            float num = 100f + sizeBar.Width / 24f;
            float num2 = 0f;
            float num3;
            for (int i = 0; i < bars.Count; i++)
            {
                num3 = gr.MeasureString(bars[i].Label, Label.Font).Width;
                if (num3 > num2)
                {
                    num2 = num3;
                }
            }
            float num4 = sizeBar.Width / num2;
            num3 = Label.Font.Size * num4;
            if (!(num <= 0f) || !(num3 <= 0f))
            {
                if (num <= 0f)
                {
                    Label.FontSetSize(num3);
                }
                else if (num3 <= 0f)
                {
                    Label.FontSetSize(num);
                }
                else
                {
                    Label.FontSetSize((num > num3) ? num3 : num);
                }
            }
        }

        private void CreateDescFont(Graphics gr, SizeF sizeBound)
        {
            float num = sizeBound.Height / 15f;
            float num2 = (sizeBound.Width - (float)(2 * nBarsGap)) / gr.MeasureString(description.Text, description.Font).Width;
            float num3 = description.Font.Size * num2;
            if (!(num <= 0f) || !(num3 <= 0f))
            {
                if (num <= 0f)
                {
                    description.FontSetSize(num3);
                }
                else if (num3 <= 0f)
                {
                    description.FontSetSize(num);
                }
                else
                {
                    description.FontSetSize((num > num3) ? num3 : num);
                }
            }
        }

        private void DrawBar(Graphics gr, HBarItem bar)
        {
            bar.Draw(gr);
            if (Label.Visible)
            {
                float num = Label.Font.GetHeight(gr);
                gr.DrawString(bar.Label, Label.Font, new SolidBrush(Label.Color), new RectangleF(bar.BarRect.X, bar.BarRect.Bottom + (float)nBarsGap, bar.BarRect.Width, num));
            }
            if (Values.Visible)
            {
                string s = string.Empty;
                if (Values.Mode == CValueProperty.ValueMode.Digit)
                {
                    s = bar.Value.ToString("F1");
                }
                else if (Values.Mode == CValueProperty.ValueMode.Percent && bars.Total > 0.0)
                {
                    s = (bar.Value / bars.Total).ToString("P1", CultureInfo.CurrentCulture);
                }
                float num2 = Values.Font.GetHeight(gr);
                gr.DrawString(s, Values.Font, new SolidBrush(Values.Color), new RectangleF(bar.BarRect.X, bar.BarRect.Top - num2 - 1f, bar.BarRect.Width + (float)(2 * nBarsGap), num2));
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        private void SetCurrTooltip(HBarItem bar)
        {
            if (bar == null)
            {
                tooltip.Hide(this);
                tooltip.RemoveAll();
                return;
            }
            string empty = string.Empty;
            _ = string.Empty;
            empty = $"{bar.Value - bar.Offset}dBm";
            if (Environment.OSVersion.Version.Major != 6)
            {
                tooltip.Hide(this);
                tooltip.RemoveAll();
            }
            tooltip.Dispose();
            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.InitialDelay = 100;
            tooltip.ReshowDelay = 100;
            tooltip.ToolTipTitle = bar.Label;
            tooltip.SetToolTip(this, empty.ToString());
        }

        private HBarItem HitTest(Point MousePoint, out int nIndex)
        {
            nIndex = -1;
            for (int i = 0; i < bars.Count; i++)
            {
                if (bars[i].BoundRect.Contains(MousePoint))
                {
                    nIndex = i;
                    return bars[i];
                }
            }
            return null;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!(ptLastTooltipMouseLoction != e.Location))
            {
                return;
            }
            ptLastTooltipMouseLoction = e.Location;
            int nIndex;
            HBarItem hBarItem = HitTest(e.Location, out nIndex);
            if (hBarItem != null)
            {
                if (nLastVisitedBarIndex >= 0)
                {
                    if (nIndex != nLastVisitedBarIndex)
                    {
                        OnBarEnter(hBarItem, nIndex);
                    }
                    else
                    {
                        SetCurrTooltip(null);
                    }
                }
                else
                {
                    OnBarEnter(hBarItem, nIndex);
                }
                SetCurrTooltip(hBarItem);
            }
            else
            {
                OnBarLeave();
            }
        }

        private void OnBarEnter(HBarItem bar, int nIndex)
        {
            nLastVisitedBarIndex = nIndex;
            RaiseHoverInEvent(bar, nIndex);
            SetCurrTooltip(bar);
        }

        private void OnBarLeave()
        {
            if (nLastVisitedBarIndex >= 0)
            {
                SetCurrTooltip(null);
                RaiseHoverOutEvent(bars[nLastVisitedBarIndex], nLastVisitedBarIndex);
                nLastVisitedBarIndex = -1;
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!RectangleToScreen(base.ClientRectangle).Contains(Cursor.Position))
            {
                SetCurrTooltip(null);
                OnBarLeave();
            }
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            int nIndex;
            HBarItem hBarItem = HitTest(e.Location, out nIndex);
            if (hBarItem != null)
            {
                RaiseClickEvent(hBarItem, nIndex);
            }
        }

        private void OnDoubleClick(object sender, MouseEventArgs e)
        {
            int nIndex;
            HBarItem hBarItem = HitTest(e.Location, out nIndex);
            if (hBarItem != null)
            {
                RaiseDoubleClickEvent(hBarItem, nIndex);
            }
        }

        private void HBarChart_BackColorChanged(object sender, EventArgs e)
        {
            if (shadow != null && (shadow.Mode == CShadowProperty.Modes.Both || shadow.Mode == CShadowProperty.Modes.Outer))
            {
                RedrawChart();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Name = "HBarChart";
            base.MouseLeave += new System.EventHandler(OnMouseLeave);
            base.Paint += new System.Windows.Forms.PaintEventHandler(OnPaint);
            base.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            base.BackColorChanged += new System.EventHandler(HBarChart_BackColorChanged);
            base.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(OnDoubleClick);
            base.MouseClick += new System.Windows.Forms.MouseEventHandler(OnClick);
            base.Resize += new System.EventHandler(OnSize);
            base.ResumeLayout(false);
        }
    }
}

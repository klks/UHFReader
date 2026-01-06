using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CPrinter
    {
        private Bitmap bmpBuffer;

        private int nPageCount;

        private int nPagesPrinted;

        private PrintDocument document;

        private bool bFitToPaper;

        public Bitmap BmpBuffer
        {
            get
            {
                return bmpBuffer;
            }
            set
            {
                bmpBuffer = value;
            }
        }

        public int PageCount
        {
            get
            {
                return nPageCount;
            }
            set
            {
                nPageCount = value;
            }
        }

        public int PagesPrinted
        {
            get
            {
                return nPagesPrinted;
            }
            set
            {
                nPagesPrinted = value;
            }
        }

        public PrintDocument Document
        {
            get
            {
                return document;
            }
            set
            {
            }
        }

        public bool FitToPaper
        {
            get
            {
                return bFitToPaper;
            }
            set
            {
                bFitToPaper = value;
            }
        }

        public CPrinter()
        {
            bmpBuffer = null;
            document = new PrintDocument();
            document.PrintPage += OnPrintPage;
        }

        public bool ShowOptions()
        {
            bool result = false;
            PrintDialog obj = new PrintDialog
            {
                Document = document,
                UseEXDialog = true
            };
            DialogResult dialogResult = obj.ShowDialog();
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
            {
                result = true;
            }
            obj.Dispose();
            return result;
        }

        public bool Print()
        {
            if (BmpBuffer == null)
            {
                return false;
            }
            PageCount = 0;
            document.Print();
            return true;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (FitToPaper)
            {
                e.Graphics.DrawImage(BmpBuffer, e.PageBounds, new Rectangle(0, 0, BmpBuffer.Width, BmpBuffer.Height), GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImageUnscaled(BmpBuffer, e.PageBounds.Left, e.PageBounds.Top);
            }
            e.HasMorePages = false;
        }
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdlcFromDdl
{
    public static class WpfProcAccess
    {
        public static void ViewReportInWindow(LocalReport rpt1, string WindowTitle1 = "Report Preview", string RptDisplayMode = "PrintLayout",
       string RenderFileName1 = "", bool OpenFile1 = true, bool IsTopMost = false, ZoomMode RptZoomMode = ZoomMode.PageWidth, int RptZoomPercent = 150)
        {
            if (RptDisplayMode == "PDF")
            {
                Rdlc2FilePrint.PrintPDFView(rpt1: rpt1, RenderFileName1: RenderFileName1, OpenFile1: OpenFile1);
                return;
            }


            var window1 = new General.AppReportWindow(Rpt1: rpt1, RptDisplayMode: RptDisplayMode, RptZoomMode: RptZoomMode, RptZoomPercent: RptZoomPercent);
            window1.Title = WindowTitle1;
            window1.Show();
            //////window1.Owner = Application.Current.MainWindow;
            ////switch (ShowAs.Substring(0, 1).ToUpper())
            ////{
            ////    case "D":  // "Dialog"
            ////        window1 = new HmsReportViewer1(rpt1, RptDisplayMode);
            ////        window1.Title = WindowTitle1;
            ////        window1.ShowDialog();
            ////        break;
            ////    case "N": // "Normal"
            ////        window1 = new HmsReportViewer2(Rpt1: rpt1, RptDisplayMode: RptDisplayMode, RptZoomMode: RptZoomMode, RptZoomPercent: RptZoomPercent);
            ////        window1.Title = WindowTitle1;
            ////        window1.Show();
            ////        break;
            ////    default:
            ////        window1 = new HmsReportViewer2(Rpt1: rpt1, RptDisplayMode: RptDisplayMode, RptZoomMode: RptZoomMode, RptZoomPercent: RptZoomPercent);
            ////        window1.Title = WindowTitle1;
            ////        window1.Show();
            ////        break;
            ////}
            window1.Topmost = IsTopMost;
        }
    }
}

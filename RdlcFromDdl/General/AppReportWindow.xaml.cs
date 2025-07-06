using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RdlcFromDdl.General
{
    /// <summary>
    /// Interaction logic for AppReportWindow.xaml
    /// </summary>
    public partial class AppReportWindow : Window
    {
        public AppReportWindow(LocalReport Rpt1, string RptDisplayMode = "PrintLayout", ZoomMode RptZoomMode = ZoomMode.PageWidth, int RptZoomPercent = 150)
        {
            InitializeComponent();
            //this.rptViewer1.ProcessingMode = ProcessingMode.Local;
            var currentReportProperty = this.rptViewer1.GetType().GetProperty("CurrentReport", BindingFlags.NonPublic | BindingFlags.Instance);
            if (currentReportProperty != null)
            {
                var currentReport = currentReportProperty.GetValue(this.rptViewer1, null);
                var localReportField = currentReport.GetType().GetField("m_localReport", BindingFlags.NonPublic | BindingFlags.Instance);
                if (localReportField != null)
                {
                    localReportField.SetValue(currentReport, Rpt1);
                }
            }

            //double ScreenWidth1 = System.Windows.SystemParameters.VirtualScreenWidth;
            //double ScreenHeight1 = System.Windows.SystemParameters.VirtualScreenHeight;

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenhight = System.Windows.SystemParameters.PrimaryScreenHeight;

            if (RptDisplayMode == "Normal")
                this.rptViewer1.SetDisplayMode(DisplayMode.Normal);
            else
                this.rptViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            //this.rptViewer1.ZoomMode = ZoomMode.PageWidth;

            this.rptViewer1.ZoomPercent = RptZoomPercent;// (screenWidth <1600 ? 100 : 150);
            this.rptViewer1.ZoomMode = RptZoomMode;// ZoomMode.Percent;
            this.rptViewer1.RefreshReport();
        }

        public AppReportWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.rptViewer1.RefreshReport();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

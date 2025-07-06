using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportLib
{
    public static class ReportConfig00
    {
        public static LocalReport GetLocalReport(string RptName, Object RptDataSet, Object RptDataSet2, Object UserDataset)
        {
            Assembly assembly1 = Assembly.LoadFrom("ReportLib.dll");

            //accessing the rdlc file from the rptlib
            Stream stream1 = assembly1.GetManifestResourceStream("ReportLib." + RptName + ".rdlc");
            LocalReport Rpt1a = new LocalReport() { DisplayName = RptName };
            Rpt1a.LoadReportDefinition(stream1);
            Rpt1a.DataSources.Clear();


            if (UserDataset != null)
            {
                var list3 = (List<string>)UserDataset;
                Rpt1a.SetParameters(new ReportParameter("ParmHeader1", list3[0].RptEntName));
                Rpt1a.SetParameters(new ReportParameter("ParmFooter1", list3[0].RptFooter1));
            }

            switch (Rpt1a.DisplayName.Trim())
            {
                //case "RptSetup.RptLocInfo1": Rpt1a = RptSetup_RptLocInfo1(Rpt1a, RptDataSet, RptDataSet2, UserDataset); break;
                //case "RptSetup.RptAccInfo1": Rpt1a = RptSetup_RptAccInfo1(Rpt1a, RptDataSet, RptDataSet2, UserDataset); break;
                case "RptSetup.RptResInfo1": Rpt1a = RptSetup_RptResInfo1(Rpt1a, RptDataSet, RptDataSet2, UserDataset); break;
            }
            return Rpt1a;


        }

    }
}

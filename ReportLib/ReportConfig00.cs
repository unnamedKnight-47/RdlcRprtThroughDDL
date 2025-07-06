using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models;

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
                List<EntityGen.ReportGeneralInfo> list3 = (List<EntityGen.ReportGeneralInfo>)UserDataset;
                Rpt1a.SetParameters(new ReportParameter("ParmHeader1", list3[0].RptEntName));
                Rpt1a.SetParameters(new ReportParameter("ParmFooter1", list3[0].RptFooter1));
            }


            switch (Rpt1a.DisplayName.Trim())
            {
                case "RptSetup.SalesRptInfo1": Rpt1a = RptSetup_RptResInfo1(Rpt1a, RptDataSet, RptDataSet2, UserDataset); break;
            }
            return Rpt1a;
        }

        private static LocalReport RptSetup_RptResInfo1(LocalReport Rpt1a, object RptDataSet, object RptDataSet2, object UserDataset)
        {
            var list0 = ((List<RptEntityGen.RptResourceInfo>)RptDataSet);
            var list3 = (List<EntityGen.ReportGeneralInfo>)UserDataset;

            Rpt1a.DataSources.Add(new ReportDataSource("RptDataSet1", list0));
            Rpt1a.SetParameters(new ReportParameter("ParamTitle1", list3[0].RptHeader1));

            return Rpt1a;
        }


    }
}

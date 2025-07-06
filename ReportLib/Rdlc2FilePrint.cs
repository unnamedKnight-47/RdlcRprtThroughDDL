using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportLib
{
    public static class Rdlc2FilePrint
    {
        public static void PrintPDFView(LocalReport rpt1 = null, string RenderFileName1 = "", bool OpenFile1 = true)
        {
            try
            {
                PrintToFile(rpt1, "PDF", RenderFileName1, OpenFile1);

                //Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string extension;
                //int rnd1 = new Random().Next(10000, 99999);
                //byte[] bytes = rpt1.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //string FilePath = Environment.GetEnvironmentVariable("TEMP") + "\\R" + rnd1 + ".pdf";
                //FileStream fs = new FileStream(FilePath, FileMode.Create);  //(FPath + "\\test.pdf", FileMode.Create);//(@"C:\Temps\test.pdf", FileMode.Create);
                //fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
                //Process myProcess = new Process();
                ////myProcess.StartInfo.FileName = "AcroRd32"; //"AcroRd32.exe";//not the full application path
                //myProcess.StartInfo.FileName = "chrome"; //"chrome.exe";//not the full application path
                ////myProcess.StartInfo.FileName = "firefox"; //"firefox.exe";//not the full application path
                //myProcess.StartInfo.Arguments = fs.Name;// ToString();// @"C:\Temps\test.pdf"; //"/A \"page=2=OpenActions\" C:\\example.pdf";
                //myProcess.Start();
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void PrintWordView(LocalReport rpt1 = null, string RenderFileName1 = "", bool OpenFile1 = true)
        {
            try
            {
                PrintToFile(rpt1, "Word", RenderFileName1, OpenFile1);

                //Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string extension;
                //int rnd1 = new Random().Next(10000, 99999);
                //byte[] bytes = rpt1.Render("Word", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //string FilePath = Environment.GetEnvironmentVariable("TEMP") + "\\R" + rnd1 + ".doc";
                //FileStream fs = new FileStream(FilePath, FileMode.Create);
                //fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
                //Process myProcess = new Process();
                //myProcess.StartInfo.FileName = "winword";
                //myProcess.StartInfo.Arguments = fs.Name;
                //myProcess.Start();
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void PrintExcelView(LocalReport rpt1 = null, string RenderFileName1 = "", bool OpenFile1 = true)
        {
            try
            {
                PrintToFile(rpt1, "Excel", RenderFileName1, OpenFile1);

                //Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string extension;
                //int rnd1 = new Random().Next(10000, 99999);
                //byte[] bytes = rpt1.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //string FilePath = Environment.GetEnvironmentVariable("TEMP") + "\\R" + rnd1 + ".xls";
                //FileStream fs = new FileStream(FilePath, FileMode.Create);  //(FPath + "\\test.pdf", FileMode.Create);//(@"C:\Temps\test.pdf", FileMode.Create);
                //fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
                //Process myProcess = new Process();
                ////myProcess.StartInfo.FileName = "AcroRd32"; //"AcroRd32.exe";//not the full application path
                //myProcess.StartInfo.FileName = "excel"; //"chrome.exe";//not the full application path
                ////myProcess.StartInfo.FileName = "firefox"; //"firefox.exe";//not the full application path
                //myProcess.StartInfo.Arguments = fs.Name;// ToString();// @"C:\Temps\test.pdf"; //"/A \"page=2=OpenActions\" C:\\example.pdf";
                //myProcess.Start();
            }
            catch (Exception)
            {
                return;
            }
        }
        public static void ReportDataExportToExcelFile<T>(List<T> list1 = null, string RenderFileName1 = "", bool OpenFile1 = true)
        {
            try
            {

                //var json = JsonConvert.SerializeObject(list1);
                int rnd1 = new Random().Next(10000, 99999);
                string fileExt = ".csv";// ".xls";
                string FilePath = Environment.GetEnvironmentVariable("TEMP") + "\\R" + rnd1 + fileExt;// ".xls";
                if (RenderFileName1.Length > 0)
                    FilePath = RenderFileName1 + "-" + rnd1 + fileExt;
                //var serializer = new XmlSerializer(typeof(List<T>),  new XmlRootAttribute("T"));
                SaveToCsv<T>(list1, FilePath);

                //using (StreamWriter sw = new StreamWriter(FilePath))
                //{
                //    CreateHeader(list1, sw);
                //    CreateRows(list1, sw);
                //}

                Process myProcess = new Process();
                string ProcessfileName = "excel";
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = ProcessfileName;// "excel"; //"chrome.exe";//not the full application path
                //myProcess.StartInfo.FileName = "firefox"; //"firefox.exe";//not the full application path
                myProcess.StartInfo.Arguments = FilePath;// ToString();// @"C:\Temps\test.pdf"; //"/A \"page=2=OpenActions\" C:\\example.pdf";
                myProcess.Start();

            }
            catch (Exception exp)
            {
                return;
            }
        }
        public static void SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
        }

        public static void CreateCSV<T>(List<T> list, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                CreateHeader(list, sw);
                CreateRows(list, sw);
            }
        }
        private static void CreateHeader<T>(List<T> list, StreamWriter sw)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length - 1; i++)
            {
                sw.Write(properties[i].Name + ",");
            }
            var lastProp = properties[properties.Length - 1].Name;
            sw.Write(lastProp + sw.NewLine);
        }
        private static void CreateRows<T>(List<T> list, StreamWriter sw)
        {
            foreach (var item in list)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var prop = properties[i];
                    sw.Write(prop.GetValue(item) + ",");
                }
                var lastProp = properties[properties.Length - 1];
                sw.Write(lastProp.GetValue(item) + sw.NewLine);
            }
        }

        private static void PrintToFile(LocalReport rpt1 = null, string RenderFormat1 = "PDF", string RenderFileName1 = "", bool OpeFile1 = true)
        {
            try
            {
                if (rpt1 == null)
                    return;

                if (!(RenderFormat1 == "PDF" || RenderFormat1 == "Word" || RenderFormat1 == "Excel"))
                    return;

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                int rnd1 = new Random().Next(10000, 99999);
                byte[] bytes = rpt1.Render(RenderFormat1, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                string fileExt = (RenderFormat1 == "PDF" ? ".pdf" : (RenderFormat1 == "Word" ? ".doc" : (RenderFormat1 == "Excel" ? ".xls" : ".xxx")));
                string FilePath = Environment.GetEnvironmentVariable("TEMP") + "\\R" + rnd1 + fileExt;// ".xls";
                if (RenderFileName1.Length > 0)
                    FilePath = RenderFileName1 + "-" + rnd1 + fileExt;

                FileStream fs = new FileStream(FilePath, FileMode.Create);  //(FPath + "\\test.pdf", FileMode.Create);//(@"C:\Temps\test.pdf", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                if (OpeFile1 == false)
                    return;

                Process myProcess = new Process();
                //myProcess.StartInfo.FileName = "AcroRd32"; //"AcroRd32.exe";//not the full application path
                string ProcessfileName = (RenderFormat1 == "PDF" ? "chrome" : (RenderFormat1 == "Word" ? "winword" : (RenderFormat1 == "Excel" ? "excel" : "xxxxx")));
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = ProcessfileName;// "excel"; //"chrome.exe";//not the full application path
                //myProcess.StartInfo.FileName = "firefox"; //"firefox.exe";//not the full application path
                myProcess.StartInfo.Arguments = fs.Name;// ToString();// @"C:\Temps\test.pdf"; //"/A \"page=2=OpenActions\" C:\\example.pdf";
                myProcess.Start();
            }
            catch (Exception exp)
            {
                return;
            }
        }




        //---------- Following are Extra Inactive Code ---------------------------------
        //public static Boolean PrintPDFs(string pdfFileName)
        //{
        //    try
        //    {
        //        Process proc = new Process();
        //        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //        proc.StartInfo.Verb = "print";

        //        //Define location of adobe reader/command line
        //        //switches to launch adobe in "print" mode
        //        //proc.StartInfo.FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe";

        //        string ii = System.IO.Path.Combine(Environment.CurrentDirectory, Application.ProductName + ".EXE");
        //        Configuration Config1 = ConfigurationManager.OpenExeConfiguration(ii);
        //        ii = Config1.AppSettings.Settings["PDFReader"].Value.ToString().Trim();

        //        proc.StartInfo.FileName = ii;// @"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe";
        //        proc.StartInfo.Arguments = String.Format(@"/p /h {0}", pdfFileName);
        //        proc.StartInfo.UseShellExecute = false;
        //        proc.StartInfo.CreateNoWindow = true;

        //        proc.Start();
        //        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //        if (proc.HasExited == false)
        //        {
        //            proc.WaitForExit(10000);
        //        }

        //        proc.EnableRaisingEvents = true;

        //        proc.Close();
        //        KillAdobe("AcroRd32");
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //For whatever reason, sometimes adobe likes to be a stage 5 clinger.
        //So here we kill it with fire.
        private static bool KillAdobe(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses().Where(
                            clsProcess => clsProcess.ProcessName.StartsWith(name)))
            {
                clsProcess.Kill();
                return true;
            }
            return false;
        }


    }
}

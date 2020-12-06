using GroupDocs.Redaction;
using GroupDocs.Redaction.Redactions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        public static string LicenseDir { get; private set; }
        public static string AssemblyDir { get; private set; }

        static void Main(string[] args)
        {


            LicenseDir= "C:\\TCIT\\RemovePDFMetaData\\TEST";
                AssemblyDir = "C:\\TCIT\\RemovePDFMetaData\\TEST";
            // We can set the license for Aspose.Words
            // bypassing the full local file system filename of an existing and valid license file.
            string licenseFileName = Path.Combine(LicenseDir, "GroupDocs.Redaction.NET.lic");

            License license = new License();
            license.SetLicense(licenseFileName);

            // Create a copy of our license file in the binaries folder of our application.
            string licenseCopyFileName = Path.Combine(AssemblyDir, "GroupDocs.Redaction.NET.lic");
            //File.Copy(licenseFileName, licenseCopyFileName);

            // If we pass the name of a file without a path,
            // the SetLicense will search several local file system locations for this file.
            // One of those locations will be the "bin" folder, where we copied the license file.
            //license.SetLicense("GroupDocs.Redaction.NET.lic");


            string[] filePaths = Directory.GetFiles(@"D:\Dir1", "*.pdf", SearchOption.AllDirectories);


            foreach (string filename in filePaths)
            {


                Redactor redactor = new Redactor(filename);
                redactor.Apply(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)));
                redactor.Save();

                //string filename1 = filename.Replace("_redacted.pdf",".pdf" );
                string filename1 = filename.Replace(".pdf","_redacted.pdf" );

                File.Delete(filename);
                File.Copy(filename1, filename);
                File.Delete(filename1);





            }


        }
    }
}
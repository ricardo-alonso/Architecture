using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exams
{
    class Program
    {
        public class HasarEvaluation
        {
            public string Description { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            var json = "{\"Description\":\"evaluacion de conocimiento\",\"Name\":\"hasar-mx\"}";
            var hasar = JsonSerializer.Deserialize<HasarEvaluation>(json);
            hasar.Description = "Evaluación realizada";
            hasar.Name = "Ricardo";

            var serialized = JsonSerializer.Serialize<HasarEvaluation>(hasar);
            Console.WriteLine(serialized);
        

            //DateTime birth = new DateTime(1992, 4, 3);
            DateTime birth = new DateTime(1958, 6, 28);
            var edad = CalculaEdad(birth);

            char[] element2 = "petabyte".ToCharArray();
            int x = 1, y;
            y = x++ + ++x;
            Console.WriteLine(element2[++y]);
            var tt = test(1);



            ThreeNums2();

            var ff = GetRFC("Ricardo", "SAnchez", "Alonso", new DateTime(2001, 04, 03, 0, 0, 0));

            string objXml = string.Empty;
            //DocumentIdentificationGroup obj = new DocumentIdentificationGroup() {documentIdentification = new DocumentIdentification { DocumentID = "MSJLD132132" } };
            AlternateDocumentIndentification obj = new AlternateDocumentIndentification() { DocumentID = "17432" };
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, obj, emptyNamespaces);
                objXml = stream.ToString();
            }

            StreamWriter WriteReportFile = File.AppendText(@"C:\Users\Ricardo\Desktop\jeje.txt");
            WriteReportFile.WriteLine(objXml);
            WriteReportFile.Close();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(objXml);


            //XmlElement element = doc.SelectSingleNode("/DocumentIdentificationGroup/documentIdentification/DocumentID") as XmlElement;
            XmlElement element = doc.SelectSingleNode("/AlternateDocumentIndentification/DocumentID") as XmlElement;
            var valor = element.InnerText;
        }

        //private static int CalculaEdad(int anioNacimiento) => DateTime.Now.Year - anioNacimiento;
        private static string CalculaEdad(DateTime fechaNacimiento) {
            var now = DateTime.Now;

            int year = now.Year - fechaNacimiento.Year;
            int month = now.Month - fechaNacimiento.Month;

            if (now.Month - fechaNacimiento.Month < 0)
            {
                year = year - 1;
                month = 12 - (month * -1);
            }

            return $"Usted tiene {year} años, {month} meses";
        }


        private static int test(int v)
        {
            char[] a = new char[4] { '0', '2', '3', '4' };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == v)
                {
                    return i;
                }
            }

            return -1;
        }

        private static string GetRFC(string name, string patSurname, string matSurname, DateTime dateBirth)
        {
            string RFC = string.Empty;

            if (name == string.Empty
                || patSurname == string.Empty
                || matSurname == string.Empty
                || dateBirth.Year < 1900
                || dateBirth.Year >= 2003)
            {
                throw new ArgumentNullException();
            }

            RFC = $"{patSurname.Substring(0, 2).ToUpper()}{matSurname.Substring(0, 1).ToUpper()}{name.Substring(0, 1).ToUpper()}{FormatDate(dateBirth)}{GetHomoclave()}";

            return RFC;
        }
        private static string GetHomoclave()
        {

            Random rnd = new Random();
            char randomChar = (char)rnd.Next('a', 'z');
            var randomNum = rnd.Next(10);
            return $"H{randomNum}{randomChar.ToString().ToUpper()}";
        }

        private static string FormatDate(DateTime date)
        {
            return $"{date.ToString("yy")}{date.Month.ToString("00")}{date.Day.ToString("00")}";
        }



        public static void ThreeNums()
        {
            int A = 52;
            int B = 60;
            int C = 1;

            List<int> nums = new List<int> { A, B, C };
            nums.Sort();
            int menor = nums.First();
            int mayor = nums.Last();

            Console.WriteLine($"Menor: {menor}, mayor: {mayor}");
        }


        public static void ThreeNums2()
        {
            int A = 1;
            int B = 60;
            int C = 2;


            string mayor = (A > B && A > C) ? "A" : (B > A && B > C) ? "B" : "C";
            string menor = (A < B && A < C) ? "A" : (B < A && B < C) ? "B" : "C";

            Console.WriteLine($"Menor: {menor}, mayor: {mayor}");
        }


    }
}

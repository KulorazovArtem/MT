using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MT
{
    public abstract class Serializer
    {
        public string FolderPath { get; private set; }
        public string FilePath { get; private set; }
        public abstract string Extension { get; }
        //public void SelectFolder(string path)
        //{
        //    if (path == null) return;
        //    if (Directory.Exists(path) == false)
        //    {
        //        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        //    }
        //    FolderPath = path;
        //}
        public void SelectFile(string name)
        {
            var name_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{name}.{Extension}");
            if (File.Exists(name_file) == false)
            {
                File.Create(name_file).Close();
            }
            FilePath = name_file;
        }
    }

    public class XML_SerializerList : Serializer
    {
        public override string Extension
        {
            get
            {
                return "xml";
            }
        }
        public int[] Deserialize(string fileName)
        {
            SelectFile(fileName);
            XmlSerializer top_10 = new XmlSerializer(typeof(Top));
            Top top;
            using (StreamReader writer = new StreamReader(FilePath)) 
            {
                top = (Top)top_10.Deserialize(writer);
            }
            int[] top_top = top.Top_10;
            return top_top;
        }
        public void Serializer_top_10(string fileName, int[] top_10)
        {
            SelectFile(fileName);
            Top top = new Top(top_10);
            XmlSerializer xml_ser = new XmlSerializer(typeof(Top));
            using (StreamWriter writ = new StreamWriter(FilePath)) 
            {
                xml_ser.Serialize(writ, top);
            }
        }
        public class Top
        {
            public int[] Top_10 { get; set; }
            public Top() { }
            public Top(int[] top_10) 
            {
                Top_10 = top_10;
            }
        }
    }
    public class JSON_SerializerList : Serializer
    {
        public override string Extension
        {
            get
            {
                return "json";
            }
        }
        public int[] Deserialize(string fileName)
        {

            SelectFile(fileName);
            var text = File.ReadAllText(FilePath);
            var top = JsonConvert.DeserializeObject<Top>(text);
            int[] top_top = top.Top_10;
            return top_top;
        }
        public void Serialize(string fileName, int[] top_10) 
        {
            SelectFile(fileName);
            Top top = new Top
            {
                Top_10 = top_10
            };
            string js = System.Text.Json.JsonSerializer.Serialize(top);
            File.WriteAllText(FilePath, js);
        }
        private class Top
        {
            public int[] Top_10 { get; set; }
        }

    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace MT
{
    delegate string MathOperation(string fileName);
    public interface ISerializer
    {
        string FolderPath { get; }
        string FilePath { get; }
        string SelectFile(string name);
    }
    public abstract class Serializer : ISerializer
    {
        public string FolderPath { get; private set; }
        public string FilePath { get; private set; }
        public abstract string Extension { get; }
       
        public string SelectFile(string name)
        {
            var name_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{name}.{Extension}");
            if (File.Exists(name_file) == false)
            {
                File.Create(name_file).Close();
            }
            FilePath = name_file;
            return FilePath;
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
        public int[] Deserialize()
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
            XmlSerializer top_10 = new XmlSerializer(typeof(Top));
            Top top;
            using (StreamReader writer = new StreamReader(FilePath)) 
            {
                top = (Top)top_10.Deserialize(writer);
            }
            int[] top_top = top.Top_10;
            return top_top;
        }
        public void Serializer_top_10(int top_1)
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
            int[] text = Deserialize();
            Array.Resize(ref text, text.Length + 1);
            text[text.Length - 1] = top_1;
            int[] new_top = text;

            for (int j = 0; j < new_top.Length; j++)
            {
                for (int i = 0; i < new_top.Length - 1; i++)
                {
                    if (new_top[i] < new_top[i + 1])
                    {
                        int x = new_top[i];
                        new_top[i] = new_top[i + 1];
                        new_top[i + 1] = x;
                    }
                }
            }
            new_top = new_top.Take(10).ToArray();
            var json = new JSON_SerializerList();
            json.Serialize(new_top);
            Top top = new Top(new_top);
            XmlSerializer xml_ser = new XmlSerializer(typeof(Top));
            using (StreamWriter writ = new StreamWriter(FilePath)) 
            {
                xml_ser.Serialize(writ, top);
            }
        }
        public void Serializer_top_10(int[] top_10)
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
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
        public int[] Deserialize()
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
            var text = File.ReadAllText(FilePath);
            var top = JsonConvert.DeserializeObject<Top>(text);

            if (top == null) return new int[0]; 

            int[] top_top = top.Top_10;
            return top_top;
        }
        
        public void Serialize(int top_1)
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top"); 
            int[] text = Deserialize();
            Array.Resize(ref text, text.Length + 1);
            text[text.Length - 1] = top_1;
            int[] new_top = text;
            
            for(int j = 0; j < new_top.Length; j++)
            {
                for(int i = 0; i < new_top.Length - 1; i++)
                {
                    if (new_top[i] < new_top[i + 1])
                    {
                        int x = new_top[i];
                        new_top[i] = new_top[i + 1];
                        new_top[i + 1] = x;
                    }
                }
            }
            new_top = new_top.Take(10).ToArray();
            var xml = new XML_SerializerList();
            xml.Serializer_top_10(new_top);
            Top top = new Top
            {
                Top_10 = new_top

            };
            string js = System.Text.Json.JsonSerializer.Serialize(top);

            File.WriteAllText(FilePath, js);
        }
        public void Serialize(int[] top_10)
        {
            MathOperation operation = SelectFile;
            string FilePath = operation($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
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
            public int Top_1 { get; set; }
        }

    }

}

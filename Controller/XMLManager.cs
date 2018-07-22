using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//...
using System.Xml;
using System.Xml.Serialization;
using System.IO;
//...ref
using Model;

namespace Controller
{
    public class XMLManager
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(PatternClass));

        public static PatternClass readListXML(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            XmlReader reader = XmlReader.Create(fileName);
            PatternClass pattern = (PatternClass)serializer.Deserialize(reader);
            reader.Close();
            return pattern;
        }

        public static PatternClass readXML(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            //XmlReader reader = XmlReader.Create(fileName);
            ////WORKS WITH TESTING
            //PatternClass pattern = (PatternClass)serializer.Deserialize(reader);
            //reader.Close();
            //return pattern;

            
            //XmlReader reader = XmlReader.Create(fileName);
            //PatternClass pattern;
            //try
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(PatternClass));
            //    pattern = (PatternClass)serializer.Deserialize(reader);
            //}
            //catch (Exception)
            //{
            //    bool test;
            //    while (reader.Read())
            //    {
            //        if (reader.NodeType == XmlNodeType.Element)
            //        {
            //            reader.Read();
            //        }
            //    }
            //}
            //reader.Close();
            //return pattern;
            return null;
        }

        public static void writeToXML(string fileName, PatternClass pattern)
        {
            XmlWriter writer = XmlWriter.Create(fileName);
            serializer.Serialize(writer, pattern);
            writer.Close();
        }
    }
}

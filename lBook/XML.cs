using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace lBook
{
    public class XML
    {
        private static XML instance;
        private XML()
        {

        }
        public static XML Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new XML();
                }
                return instance;
            }
        }


        public  void Serialize<T>(List<T> obj, string path)
        {
            var writer = new XmlSerializer(obj.GetType());
            using (var file = new StreamWriter(path))
            {
                writer.Serialize(file, obj);
            }
        }
        public List<T> Deserialize<T>(List<T> s, string path)
        {
            if (File.Exists(path))
            {

                using (TextReader reader = new StreamReader(path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                    s = ser.Deserialize(reader) as List<T>;

                    return s;
                }

            }
            return null;
        }
    }


}

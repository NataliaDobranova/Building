using System.IO;
using System.Xml.Serialization;

namespace Building.XmlHelper
{
    public static class XmlHelper
    {
        public static void Serialize<T>(T obj, string fileName) 
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var fileStream = new StreamWriter(fileName))
            {
                serializer.Serialize(fileStream, obj);
                fileStream.Close();
            }
        }

        public static T Deserialize<T>(string fileName) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T obj = null;
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = (T)serializer.Deserialize(fileStream);
                fileStream.Close();
            }
            
            return obj;
        }

    }
}

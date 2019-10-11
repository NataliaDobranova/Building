using System.IO;
using System.Xml.Serialization;

namespace Building.XmlHelper
{
    /// <summary>
    /// XmlSerializer helper class
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Default XmlSerializer file writer
        /// Serialization rules can be modified with serialization type attributes
        /// </summary>
        /// <typeparam name="T">Serializable class type to save</typeparam>
        /// <param name="obj">Object to save</param>
        /// <param name="fileName">File path to save</param>
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

        /// <summary>
        /// Default XmlSerializer file reader
        /// Serialization rules can be modified with serialization type attributes
        /// </summary>
        /// <typeparam name="T">Serializable class type to read</typeparam>
        /// <param name="fileName">File path to read</param>
        /// <returns></returns>
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

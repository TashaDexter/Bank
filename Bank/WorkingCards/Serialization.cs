using System.IO;
using System.Xml.Serialization;

namespace Bank.WorkingCards
{
    /// <summary>
    /// класс для сохранения и изьятия данныых карты с файла
    /// </summary>
    public class Serialization
    {
        public void Serialize<T>(T t, string folder) where T : class
        {
            var writer = new XmlSerializer(t.GetType());
            using (var file = File.Create(folder))
            {
                writer.Serialize(file, t);
            }
        }

        public T Deserialize<T>(T t, string folder) where T : class
        {
            var xmlSerializer = new XmlSerializer(t.GetType());
            using (var file = File.OpenRead(folder))
            {
                return (T)xmlSerializer.Deserialize(file);
            }
        }
    }
}

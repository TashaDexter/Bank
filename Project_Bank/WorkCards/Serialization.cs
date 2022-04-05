using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project_Bank.WorkCards
{
    public class Serialization   //класс для сохранения и изьятия данныых карты с файла
    {

        public void Seriaze<T>(T t, string Folder) where T : class
        {           
            XmlSerializer writer =new XmlSerializer(t.GetType()); 
            using (System.IO.FileStream file = System.IO.File.Create(Folder))
            {
                writer.Serialize(file, t);
            }
        }

        public T Deseriaze<T>(T t,string Folder) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            using (System.IO.FileStream file = System.IO.File.OpenRead(Folder))
            {
                return (T)xmlSerializer.Deserialize(file);
            }
        }
    }
}

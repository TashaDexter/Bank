using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkCards
{
    [Serializable]
    public class Card  : ICard      //класс для хранения информации карты в файл
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }

        public string Code { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }

    }
}

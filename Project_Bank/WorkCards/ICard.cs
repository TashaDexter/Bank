using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bank.WorkCards
{
    public interface ICard         //интерфейс для передачи номера карты 
    {
        int ID { get; set; }
    }
}

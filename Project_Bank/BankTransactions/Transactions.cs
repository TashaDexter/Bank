using Project_Bank.WorkCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Bank.BankTransactions
{
    public abstract  class Transactions 
    {

        public delegate void DMoney(Money money);     //делегат для создания события    
        public event DMoney Emoney;    //создание события
        protected void SendMoney(Money money)
        {
            Emoney?.Invoke(money);     //вызов события
        }
      
        
        protected ICard card;
        protected Money money;
     
  
    }
}

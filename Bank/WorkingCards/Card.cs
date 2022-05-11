using System;

namespace Bank.WorkingCards
{
    /// <summary>
    /// класс для хранения информации карты в файл
    /// </summary>
    [Serializable]
    public class Card : IIdentification
    {
        public long Id { get; set; }

        public Client Client { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }
}

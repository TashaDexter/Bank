namespace Bank.WorkingCards
{
    public class Client : IIdentification
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
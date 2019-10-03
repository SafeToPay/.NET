namespace Safe2Pay.Models
{
    public class TransferStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TransferStatus() { }

        public TransferStatus(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
    }

}

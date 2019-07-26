namespace Safe2Pay.Models
{
    public class DebitAccountReturn
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public Payment Payment { get; set; }
    }
}
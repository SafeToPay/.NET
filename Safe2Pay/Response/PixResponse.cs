namespace Safe2Pay.Response
{
    public class PixResponse
    {
        public int IdTransaction { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string QrCode { get; set; }
        public string Key { get; set; }
    }
}

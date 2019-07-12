namespace Safe2Pay
{
    public class Filter<T> where T : new()
    {
        public T Object { get; set; }
       
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }
}
using System.Collections.Generic;

namespace Safe2Pay
{
    public class ListObject<T> where T : new()
    {
        public List<T> Objects { get; set; }
        public int TotalItems { get; set; }
    }
}
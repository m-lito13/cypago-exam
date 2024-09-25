namespace DAL
{
    public class DALQueryParams
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> FilterParams { get; }

        public DALQueryParams()
        {
            FilterParams = new Dictionary<string, string>();
        }

        public bool UsePagination()
        {
            bool result = (PageNum > 0 && PageSize > 0);
            return result;
        }
    }
}

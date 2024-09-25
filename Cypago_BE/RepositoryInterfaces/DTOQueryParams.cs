namespace RepositoryInterfaces
{
    public class DTOQueryParams
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> FilterParams { get; }

        public DTOQueryParams()
        {
            FilterParams = new Dictionary<string, string>();
        }
    }
}

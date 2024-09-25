namespace RepositoryInterfaces.DTO
{
    public class ResourceDTO
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public int ScanID { get; set; }
        public string Urn { get; set; }
        public ResourceType ResourceType { get; set; }
        public byte[] DataHash { get; set; }
    }
}

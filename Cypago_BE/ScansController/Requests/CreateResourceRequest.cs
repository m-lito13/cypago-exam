namespace CypagoApp.Requests
{
    public class CreateResourceRequest
    {
        public int ScanId { get; set; }
        public string Urn { get; set; }
        public string Data { get; set; }
        public string ResourceType { get; set; }
        public string Name { get; set; }
    }
}

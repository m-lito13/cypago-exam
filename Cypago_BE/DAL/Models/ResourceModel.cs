using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("resources")]
    [PrimaryKey(nameof(URN), nameof(DataHash))]
    public class ResourceModel
    {
        public string URN { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string ResourceType { get; set; }
        public int ScanID { get; set; }
        public byte[] DataHash { get; set; }
    }
}

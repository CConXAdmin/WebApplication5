using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class OtherBase
    {
        public int Id { get; set; }
        public string? Name1 { get; set; }
        public string Name2 { get; set; }
        public virtual ICollection<OtherSub> OtherSub { get; set; }
    }
    public class OtherSub
    {
        public int Id { get; set; }
        public string? Name1 { get; set; }
        public string Name2 { get; set; }
        public int OtherBaseId { get; set; }
        [ForeignKey("OtherBaseId")]
        public virtual OtherBase OtherBase { get; set; }
    }
}

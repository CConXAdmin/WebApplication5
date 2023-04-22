using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Base
    {
        public int Id { get; set; }
        public string? Name1 { get; set; }
        public string Name2 { get; set; }
        public virtual ICollection<Sub> Subs { get; set; }
    }
    public class Sub
    {
        public int Id { get; set; }
        public string? Name1 { get; set; }
        public string Name2 { get; set; }
        public int BaseId { get; set; }
        [ForeignKey("BaseId")]
        public virtual Base Base { get; set;}
    }
}

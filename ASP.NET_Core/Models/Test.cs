using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core.Models
{
    public class Test
    {
        [Key]
        public Guid NewsId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Docker { get; set; }

    }
}

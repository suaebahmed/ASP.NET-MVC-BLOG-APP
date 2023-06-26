using System.ComponentModel.DataAnnotations;

namespace C_Sharp_CRUD.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

    }
}

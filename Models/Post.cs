using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }
        public string Content { get; set; }

        public Post(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }

    public class PostInputDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public PostInputDTO(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}

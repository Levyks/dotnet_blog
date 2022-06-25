namespace DotNetBlog.Models
{
    public class Post
    {
        private static int nextId = 1;
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Post(string title, string content)
        {
            Id = nextId++;
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

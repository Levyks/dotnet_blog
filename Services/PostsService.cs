using DotNetBlog.Models; 

namespace DotNetBlog.Services
{
    public class PostsService: IPostsService
    {
        static private List<Post> _posts = new List<Post>();

        public async Task<List<Post>> GetPosts()
        {
            return _posts;
        }

        public async Task<Post?> GetPost(int id)
        {
            var post = _posts.Find(_post => _post.Id == id);

            return post;
        }

        public async Task<Post> AddPost(PostInputDTO dto)
        {
            var post = new Post(
                title: dto.Title, 
                content: dto.Content
            );

            _posts.Add(post);

            return post;
        }

        public async Task<Post> UpdatePost(Post post, PostInputDTO dto)
        {
            post.Title = dto.Title;
            post.Content = dto.Content;

            return post;
        }
    }
} 

using DotNetBlog.Models;

namespace DotNetBlog.Services
{
    public interface IPostsService
    {
        public Task<List<Post>> GetPosts();

        public Task<Post?> GetPost(int id);

        public Task<Post> AddPost(PostInputDTO dto);

        public Task<Post> UpdatePost(Post post, PostInputDTO dto);
        
        public Task DeletePost(Post post);
    }
}

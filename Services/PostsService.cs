using DotNetBlog.Models;
using DotNetBlog.Data;

namespace DotNetBlog.Services
{
    public class PostsService: IPostsService
    {
        private readonly DataContext _context;

        public PostsService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPost(int id)
        {
            return await _context.Posts.FindAsync(id);;
        }

        public async Task<Post> AddPost(PostInputDTO dto)
        {
            var post = new Post(
                title: dto.Title, 
                content: dto.Content
            );

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> UpdatePost(Post post, PostInputDTO dto)
        {
            post.Title = dto.Title;
            post.Content = dto.Content;

            await _context.SaveChangesAsync();

            return post;
        }

        public async Task DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
} 

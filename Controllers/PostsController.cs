﻿using Microsoft.AspNetCore.Mvc;
using DotNetBlog.Services;
using DotNetBlog.Models;

namespace DotNetBlog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        
        public PostsController(IPostsService postsServices)
        {
            _postsService = postsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            var posts = await _postsService.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postsService.GetPost(id);
            return post != null ?
                Ok(post) :
                NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(PostInputDTO dto)
        {
            var post = await _postsService.AddPost(dto);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, PostInputDTO dto)
        {
            var post = await _postsService.GetPost(id);
            if (post == null) return NotFound();
            await _postsService.UpdatePost(post, dto);
            return Ok(post);
        }

    }
}

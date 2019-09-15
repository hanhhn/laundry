using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Post;
using Cf.Libs.Service.Posts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cf.Laundry.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _service;

        public PostsController(IPostService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("get/{url}")]
        public PostDto GetByUrl(string url)
        {
            return _service.GetByUrl(url);
        }


        [HttpGet]
        [Route("detail/{id}")]
        public PostDto Get(string id)
        {
            return _service.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<PostDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _service.GetAll(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("unique/{url}")]
        public bool IsUniqueUrl(string url)
        {
            return _service.IsUniqueUrl(url);
        }

        [HttpPost]
        [Route("save")]
        public bool SavePost(PostRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            return _service.Save(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(string id)
        {
            return _service.Delete(id);
        }

        [HttpPost]
        [Route("published/{id}")]
        public bool Published(string id)
        {
            return _service.Published(id);
        }

        [HttpPost]
        [Route("upublished/{id}")]
        public bool UnPublished(string id)
        {
            return _service.UnPublished(id);
        }

        [HttpGet]
        [Route("process")]
        public IEnumerable<PostDto> GetProcessPost(int pageIndex = 0, int pageSize = 10)
        {
            return _service.GetProcessPost(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("guide")]
        public GuidePost GetGuidePost(int pageIndex = 0, int pageSize = 10)
        {
            return _service.GetGuidePost(pageIndex, pageSize);
        }
    }
}
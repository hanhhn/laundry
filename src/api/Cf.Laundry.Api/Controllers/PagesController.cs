using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Page;
using Cf.Libs.Service.Pages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Api.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _service;

        public PagesController(IPageService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get/{url}")]
        public PageDto GetByUrl(string url)
        {
            return _service.GetByUrl(url);
        }

        [HttpGet]
        [Route("detail/{id}")]
        public PageDto Get(string id)
        {
            return _service.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<PageDto> GetAll(int pageIndex = 0, int pageSize = 10)
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
        public bool SavePost(PageRequest request)
        {
            return _service.Save(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(string id)
        {
            return _service.Delete(id);
        }
    }
}
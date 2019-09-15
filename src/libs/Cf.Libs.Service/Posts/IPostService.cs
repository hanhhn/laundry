using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Post;
using System.Collections.Generic;

namespace Cf.Libs.Service.Posts
{
    public interface IPostService : IBaseService
    {
        PostDto Get(string id);
        PostDto GetByUrl(string uniqueUrl);
        IPagedList<PostDto> GetAll(int pageIndex, int pageSize);
        bool IsUniqueUrl(string url);
        bool Save(PostRequest request);
        bool Delete(string id);
        bool Published(string id);
        bool UnPublished(string id);
        IEnumerable<PostDto> GetHomePost(int pageIndex, int pageSize);
    }
}
using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.News;
using Cf.Libs.DataAccess.Repository.Posts;
using Cf.Libs.DataAccess.Repository.Tags;
using Cf.Libs.Service.Dtos.Post;
using System;
using System.Linq;

namespace Cf.Libs.Service.Posts
{
    public class PostService : BaseService, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;

        public PostService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPostRepository postRepository,
            ITagRepository tagRepository) : base(unitOfWork, mapper)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public PostDto Get(string id)
        {
            var record = _postRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var result = _mapper.Map<PostDto>(record);
            result.Tags = _tagRepository.GetByPost(id).Select(x => x.Name);

            return result;
        }

        public PostDto GetByUrl(string uniqueUrl)
        {
            var record = _postRepository.GetByUrl(uniqueUrl);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var result = _mapper.Map<PostDto>(record);
            result.Tags = _tagRepository.GetByPost(record.Id).Select(x => x.Name);

            return result;
        }

        public IPagedList<PostDto> GetAll(int pageIndex, int pageSize)
        {
            var query = from post in _postRepository.GetQuery()
                        orderby post.CreateDate descending
                        orderby post.PublishedDate descending
                        where !post.IsDeleted
                        select post;
            return query.ToPagedList<Post, PostDto>(pageIndex, pageSize);
        }

        public bool IsUniqueUrl(string url)
        {
            var record = _postRepository.GetByUrl(url);
            return record == null;
        }


        public bool Save(PostRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var record = _postRepository.Get(request.Id);
            if (record == null)
            {
                record = _mapper.Map<Post>(request);
                _postRepository.Add(record);
            }
            else
            {
                record.UniqueUrl = request.UniqueUrl;
                record.Image = request.Image;
                record.Title = request.Title;
                record.Description = request.Description;
                record.Body = request.Body;
                record.IsPublished = request.IsPublished;
                _postRepository.Update(record);
            }

            return _unitOfWork.SaveChanges() != 0;
        }

        public bool Delete(string id)
        {
            var record = _postRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _postRepository.Delete(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }

        public bool Published(string id)
        {
            var record = _postRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            record.IsPublished = true;
            record.PublishedDate = DateTime.Now;

            _postRepository.Update(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }

        public bool UnPublished(string id)
        {
            var record = _postRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }


            record.IsPublished = false;
            record.PublishedDate = null;

            _postRepository.Update(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}
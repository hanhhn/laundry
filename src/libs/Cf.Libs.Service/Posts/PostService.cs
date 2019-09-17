using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.News;
using Cf.Libs.DataAccess.Repository.Posts;
using Cf.Libs.DataAccess.Repository.Settings;
using Cf.Libs.DataAccess.Repository.Tags;
using Cf.Libs.Service.Dtos.Post;
using Cf.Libs.Service.Dtos.Setting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Posts
{
    public class PostService : BaseService, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ISettingRepository _settingRepository;

        public PostService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPostRepository postRepository,
            ITagRepository tagRepository,
            ISettingRepository settingRepository) : base(unitOfWork, mapper)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _settingRepository = settingRepository;
        }

        public PostDto Get(string id)
        {
            var record = _postRepository.Get(id);
            return _mapper.Map<PostDto>(record);
        }

        public PostDto GetByUrl(string uniqueUrl)
        {
            var record = _postRepository.GetByUrl(uniqueUrl);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var result = _mapper.Map<PostDto>(record);

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
                record.Id = Guid.NewGuid().ToString();
                record.PublishedDate = null;
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

        public IEnumerable<PostDto> GetProcessPost(int pageIndex, int pageSize)
        {
            var record = _settingRepository.FindByKey(SettingKey.Process.ToString());

            List<string> posts = new List<string>();
            if (record != null)
            {
                posts = JsonConvert.DeserializeObject<string[]>(record.Value).ToList();
            }

            var query = from post in _postRepository.GetQuery()
                        orderby post.CreateDate descending
                        orderby post.PublishedDate descending
                        where !post.IsDeleted && post.IsPublished && posts.Contains(post.Id)
                        select post;

            var result = _mapper.Map<IEnumerable<PostDto>>(query.AsEnumerable());

            return result;
        }

        public GuidePost GetGuidePost(int pageIndex, int pageSize)
        {
            var record = _settingRepository.FindByKey(SettingKey.Guide.ToString());

            GuideDto posts = new GuideDto();
            if (record != null && !string.IsNullOrEmpty(record.Value))
            {
                posts = JsonConvert.DeserializeObject<GuideDto>(record.Value);
            }

            var query = from post in _postRepository.GetQuery()
                        orderby post.CreateDate descending
                        orderby post.PublishedDate descending
                        where !post.IsDeleted && post.IsPublished && posts.Steppers.Contains(post.Id)
                        select post;

            var result = _mapper.Map<IEnumerable<PostDto>>(query.AsEnumerable());

            return new GuidePost
            {
                Title = posts.Title,
                Description = posts.Description,
                Image = posts.Image,
                Posts = result
            };
        }
    }
}
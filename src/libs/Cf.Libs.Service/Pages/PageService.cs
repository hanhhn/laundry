using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Static;
using Cf.Libs.DataAccess.Repository.Pages;
using Cf.Libs.DataAccess.Repository.Settings;
using Cf.Libs.DataAccess.Repository.Tags;
using Cf.Libs.Service.Dtos.Page;
using System;
using System.Linq;

namespace Cf.Libs.Service.Pages
{
    public class PageService : BaseService, IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ISettingRepository _settingRepository;

        public PageService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPageRepository postRepository,
            ITagRepository tagRepository,
            ISettingRepository settingRepository) : base(unitOfWork, mapper)
        {
            _pageRepository = postRepository;
            _tagRepository = tagRepository;
            _settingRepository = settingRepository;
        }

        public PageDto Get(string id)
        {
            var record = _pageRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var result = _mapper.Map<PageDto>(record);

            return result;
        }

        public PageDto GetByUrl(string uniqueUrl)
        {
            var record = _pageRepository.GetByUrl(uniqueUrl);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var result = _mapper.Map<PageDto>(record);

            return result;
        }

        public IPagedList<PageDto> GetAll(int pageIndex, int pageSize)
        {
            var query = from post in _pageRepository.GetQuery()
                        orderby post.SortOrder ascending
                        orderby post.CreateDate descending
                        where !post.IsDeleted
                        select post;
            return query.ToPagedList<Page, PageDto>(pageIndex, pageSize);
        }

        public bool IsUniqueUrl(string url)
        {
            var record = _pageRepository.GetByUrl(url);
            return record == null;
        }


        public bool Save(PageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var record = _pageRepository.Get(request.Id);
            if (record == null)
            {
                record = _mapper.Map<Page>(request);
                record.Id = Guid.NewGuid().ToString();
                _pageRepository.Add(record);
            }
            else
            {
                record.UniqueUrl = request.UniqueUrl;
                record.Image = request.Image;
                record.Title = request.Title;
                record.Description = request.Description;
                record.Body = request.Body;
                record.SortOrder = request.SortOrder;
                _pageRepository.Update(record);
            }

            return _unitOfWork.SaveChanges() != 0;
        }

        public bool Delete(string id)
        {
            var record = _pageRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _pageRepository.Delete(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}
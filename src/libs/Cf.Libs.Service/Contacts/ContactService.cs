using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Repository.Contacts;
using Cf.Libs.Service.Dtos.Contact;

namespace Cf.Libs.Service.Contacts
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IContactRepository contactRepository) : base(unitOfWork, mapper)
        {
            _contactRepository = contactRepository;
        }
        
        public bool Add(ContactRequest request)
        {
            var contact = _mapper.Map<Contact>(request);
            contact.Seen = false;
            var record = _contactRepository.Add(contact);
            return _unitOfWork.SaveChanges() != 0;
        }

        public bool Seen(int[] ids)
        {
            foreach(var id in ids)
            {
                var record = _contactRepository.Get(id);
                if(record == null)
                {
                    record.Seen = true;
                }
                _contactRepository.Update(record);
            }

            return _unitOfWork.SaveChanges() == ids.Length;
        }
    }
}
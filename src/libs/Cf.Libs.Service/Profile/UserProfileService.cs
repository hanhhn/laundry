using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Repository.UserProfiles;

namespace Cf.Libs.Service.Profile
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserProfileRepository userProfileRepository)  : base(unitOfWork, mapper)
        {
            _userProfileRepository = userProfileRepository;
        }
    }
}
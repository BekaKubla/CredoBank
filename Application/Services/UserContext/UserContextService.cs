using KredoBank.Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace KredoBank.Application.Services.UserContext
{
    public class UserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserContextService(IHttpContextAccessor httpContextAccessor,
                                  IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entity.User.Users> GetCurrentUserId()
        {
            var userIdentifier = _httpContextAccessor.HttpContext.User.Claims.ToList().Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
            var currentUser = await _unitOfWork.UserRepository.GetSingleAsync(x => x.Id == int.Parse(userIdentifier));

            return currentUser;
        }

    }
}

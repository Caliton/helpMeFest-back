using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Models.Models;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User user)
        {
            var createdUser = this.unitOfWork.UserRepository.CreateFillProps(user);
            await this.unitOfWork.Commit();
            return createdUser;
        }

        public User ValidateLogin(string email, string password)
        {
            return this.unitOfWork.UserRepository.FindByCondition(user => user.Email == email && user.Password == password).FirstOrDefault();
        }
    }
}

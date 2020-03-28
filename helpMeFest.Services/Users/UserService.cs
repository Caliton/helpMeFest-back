using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Models.Models;
using helpMeFest.Models.Utils;
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
            var createdUser = this.unitOfWork.UserRepository.Create(user);
            await this.unitOfWork.Commit();
            return createdUser;
        }

        public async Task<AuthenticationResult> ValidateLogin(string email, string password)
        {
            var users = await this.unitOfWork.UserRepository.FindByCondition(user => user.Email == email && user.Password == password);
            var user = users.FirstOrDefault();
            if (user == null)
            {
                return new AuthenticationResult()
                {
                    LoginResult = Models.LoginResult.FAIL,
                    Message = "Não encontrei seus dados ou eles estão incorretos"
                };
            }

            return new AuthenticationResult()
            {
                LoginResult = Models.LoginResult.SUCCESS,
                Message = "Logado! Vai filhão!",
                ReturnedUser = user
            };
        }
    }
}

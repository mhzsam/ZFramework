using Application.DTO.UserService;
using Application.Helper;
using Application.Interface;
using Application.SetUp.Model;
using Domain.Common;
using Domain.Entites;
using Mapster;
using Microsoft.Extensions.Options;

namespace Application.Service.UserService
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly JwtConfig _jwtConfig;

        public UserService(IUnitOfWork unitOfWork, IOptions<JwtConfig> op)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = op.Value;
        }


        public async Task<IEnumerable<User>> GetAll(int PageNumber, int pageSize)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var res = await _unitOfWork.GetRepository<User>().GetAllAsync(PageNumber, pageSize);
                _unitOfWork.CommitTransaction();

                return res;

            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.GetRepository<User>().GetAsync(id);
        }

        public async Task<(bool result, string token)> Login(string Email, string PassWord)
        {
            var user = await _unitOfWork.GetRepository<User>().FindByAsync(t => t.EmailAddress == Email.Trim());
            if (user == null)
            {
                return (false, "");
            }
            PassWord = SecurityHelper.PasswordToSHA256(PassWord.Trim());
            if (PassWord != user.Password)
            {
                return (false, "");
            }
            var token = SecurityHelper.GetNewToken(user.Id, _jwtConfig.TokenKey, _jwtConfig.TokenTimeOut);
            return (true, token);

        }

        public Task<User> SingUp(AddUserModel addUserModel)
        {
            addUserModel.Password = SecurityHelper.PasswordToSHA256(addUserModel.Password);

            //var res = addUserModel.Adapt<User>();
            var user = Mapper<User>.ToEntity(addUserModel);
            _unitOfWork.GetRepository<User>().Insert(user);
            _unitOfWork.SaveChangesAsync();
            return Task.FromResult(user);

        }

    }
}

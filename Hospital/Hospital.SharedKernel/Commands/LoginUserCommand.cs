using Hospital.Services;
using Hospital.Core;
using MediatR;
using Hospital.Infrastructure.Cryptography;
using Hospital.Infrastructure;

namespace Hospital.SharedKernel.Commands
{
    public class LoginUserCommand : IRequest<ServiceResult<string>>
    {
        public LoginUserCommand(string nationaCode, string passWord)
        {
            NationaCode = nationaCode;
            PassWord = passWord;
        }

        public string NationaCode { get; set; }
        public string PassWord { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ServiceResult<string>>
    {
        protected readonly UserRepository _userRepository;
        private readonly IAES AES;
        private TokenGenerator _tokenGenerator;


        public LoginUserCommandHandler(UserRepository userRepository, IAES aES, TokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            AES = aES;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ServiceResult<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserWitheNationaCode(request.NationaCode);
            if (user is null)
                throw new Exception("this user is exist");

            bool checkPassword = false;


            if (AES.Decrypt(user.Password) == AES.Encrypt(request.PassWord))
                checkPassword = true;


            if (checkPassword is true)
                throw new Exception("this password is not correct");



            var token = _tokenGenerator.GetToken(user);
            return ServiceResult.Create(token);
        }
    }
}
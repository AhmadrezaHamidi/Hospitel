using Hospital.Services;
using Hospital.Core;
using MediatR;
using Hospital.Infrastructure.Cryptography;
using Hospital.Infrastructure;

namespace Hospital.SharedKernel.Commands
{
    public class CreateUserCommand : IRequest<ServiceResult<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationaCode { get; set; }
        public string PassWord { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<string>>
    {
        protected readonly UserRepository _userRepository;
        private readonly IAES AES;
        private TokenGenerator _tokenGenerator;

        public CreateUserCommandHandler(UserRepository userRepository, IAES aES,TokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            AES = aES;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.IsNotExist(request.FirstName, request.LastName);
            var checkNationaCode = _userRepository.IsExistByNationaCode(request.NationaCode);


            if (user is true)
                throw new Exception("this user is exist");

            if (checkNationaCode is true)
                throw new Exception("this NationaCode is exist");

            var hashPassWoed = AES.Encrypt(request.PassWord);
            var istance = new UserEntity(request.FirstName, request.LastName, request.NationaCode, hashPassWoed);
            var insert = _userRepository.AddUser(istance);
            var res = _tokenGenerator.GetToken(istance);

            return ServiceResult.Create(res);
        }
    }
}
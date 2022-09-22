using Hospital.Services;
using Hospital.Core;
using MediatR;

namespace Hospital.SharedKernel.Commands
{
    public class CreateUserCommand : IRequest<ServiceResult<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationaCode { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<string>>
    {
        protected readonly UserRepository _userRepository;

        public CreateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.IsNotExist(request.FirstName, request.LastName);
            var checkNationaCode = _userRepository.IsExistByNationaCode(request.NationaCode);


            if (user is true)
                throw new Exception("this user is exist");

            if (checkNationaCode is true)
                throw new Exception("this NationaCode is exist");


            var istance = new UserEntity(request.FirstName,request.LastName,request.NationaCode);
            var res = _userRepository.AddUser(istance);
            return ServiceResult.Create(res);
        }
    }
}
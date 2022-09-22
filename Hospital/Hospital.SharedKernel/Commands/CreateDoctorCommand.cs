using Hospital.Core;
using Hospital.Services;
using MediatR;

namespace Hospital.SharedKernel.Commands
{
    public class CreateDoctorCommand : IRequest<ServiceResult<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }

    }
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, ServiceResult<string>>
    {
        protected readonly DoctorRepository _docRepository;

        public CreateDoctorCommandHandler(DoctorRepository docRepository)
        {
            _docRepository = docRepository;
        }

        public async Task<ServiceResult<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = _docRepository.GetDoctorByUserName(request.FirstName, request.LastName);


            if (user != null)
                throw new Exception("this dock is exist");

            var istance = new DoctorEntity(request.FirstName, request.LastName,request.Specialty);
            var res = _docRepository.AddDoctor(istance);
            return ServiceResult.Create(res);
        }
    }
}
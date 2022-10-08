using Hospital.DtoModels;
using Hospital.Services;
using Hospital.Web.DtoModels;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GetDoctorsQuery : IRequest<ServiceResult<List<DoctorsResultDto>>>
    {
    }
    
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, ServiceResult<List<DoctorsResultDto>>>
    {
        protected readonly DoctorRepository _doctorRepository;

        public GetDoctorsQueryHandler(DoctorRepository DoctorRepository)
        {
            _doctorRepository = DoctorRepository;
        }

        public async Task<ServiceResult<List<DoctorsResultDto>>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = _doctorRepository.GetAll();
            var res = doctors.Adapt<List<DoctorsResultDto>>();

            return ServiceResult.Create(res);
        }
    }
}
using Hospital.DtoModels;
using Hospital.Services;
using Hospital.Web.DtoModels;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GetDocktersQuery : IRequest<ServiceResult<List<DocktersResultDto>>>
    {
    }
    
    public class GetDocktersQueryHandler : IRequestHandler<GetDocktersQuery, ServiceResult<List<DocktersResultDto>>>
    {
        protected readonly DoctorRepository _doctorRepository;

        public GetDocktersQueryHandler(DoctorRepository DoctorRepository)
        {
            _doctorRepository = DoctorRepository;
        }

        public async Task<ServiceResult<List<DocktersResultDto>>> Handle(GetDocktersQuery request, CancellationToken cancellationToken)
        {
            var doctors = _doctorRepository.GetAll();
            var res = doctors.Adapt<List<DocktersResultDto>>();

            return ServiceResult.Create(res);
        }
    }
}
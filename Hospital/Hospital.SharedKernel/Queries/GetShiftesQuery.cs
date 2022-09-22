using Hospital.DtoModels;
using Hospital.Services;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GetShiftesQuery  : IRequest<ServiceResult<List<ShiftResultDto>>>
    {
    }
    
    public class GetShiftesQueryHandler : IRequestHandler<GetShiftesQuery, ServiceResult<List<ShiftResultDto>>>
    {
        protected readonly ShiftRepository _shiftRepository;

        public GetShiftesQueryHandler(ShiftRepository ShiftRepository)
        {
            _shiftRepository = ShiftRepository;
        }

        public async Task<ServiceResult<List<ShiftResultDto>>> Handle(GetShiftesQuery request, CancellationToken cancellationToken)
        {
            var shiftes = _shiftRepository.GetAll();
            var res = shiftes.Adapt<List<ShiftResultDto>>();


            return ServiceResult.Create(res);
        }
    }
}
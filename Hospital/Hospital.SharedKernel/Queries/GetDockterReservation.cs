using Hospital.Services;
using Hospital.Web.DtoModels;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GetDockterReservation : IRequest<ServiceResult<DockterReservationDto>>
    {
        public GetDockterReservation(string docktorId)
        {
            DocktorId = docktorId;
        }

        public string DocktorId { get; set; }
        
    }
    
    public class GetDockterReservationHandler : IRequestHandler<GetDockterReservation, ServiceResult<DockterReservationDto>>
    {
        protected readonly ReservationRepository _reservationRepository;
        protected readonly ShiftRepository _shiftRepository;

        public GetDockterReservationHandler(ReservationRepository ReservationRepository,ShiftRepository ShiftRepository)
        {
            _reservationRepository = ReservationRepository;
            _shiftRepository = ShiftRepository;
        }


        public async Task<ServiceResult<DockterReservationDto>> Handle(GetDockterReservation request, CancellationToken cancellationToken)
        {

            var doctors = _reservationRepository.GetAll()
            .Where(x => x.DoctorId.Equals(request.DocktorId));

            var fullSinceInput = new List<ReservationDto>();
            var fullSince = doctors.Where(x => x.UserId != null).ToList();
            var shiftOIds = fullSince.Select(x => x.ShiftId).ToList();
            var shiftOffullSince = _shiftRepository.GetAll()
            .Where(x =>  shiftOIds.Contains(x.Id.ToString())).ToList();
            fullSince.ForEach(item =>
            {
                var dto = new ReservationDto();
                dto.DoctorId = item.DoctorId;
                dto.IsDone = item.IsDone;
                var shift = shiftOffullSince.FirstOrDefault(predicate :  x => x.Id.Equals(item.ShiftId));
                dto.Shift = shift.Adapt<ShiftReserveshionResultDto>(); 
                fullSinceInput.Add(dto);
            });





            var freeSinceInput = new List<ReservationDto>();
            var freeSince = doctors.Where(x => x.UserId == null).ToList();
            var shiftFreeOIds = fullSince.Select(x => x.ShiftId).ToList();
            var shiftOfFreeSince = _shiftRepository.GetAll()
            .Where(x =>  shiftOIds.Contains(x.Id.ToString())).ToList();
            freeSince.ForEach(item =>
            {
                var dto = new ReservationDto();
                dto.DoctorId = item.DoctorId;
                dto.IsDone = item.IsDone;
                var shift = shiftOfFreeSince.FirstOrDefault(predicate :  x => x.Id.Equals(item.ShiftId));
                dto.Shift = shift.Adapt<ShiftReserveshionResultDto>(); 
                fullSinceInput.Add(dto);
            });



            var res =new DockterReservationDto(fullSinceInput,freeSinceInput);

            return ServiceResult.Create(res);
        }
    }
}
using Hospital.Services;
using Hospital.Web.DtoModels;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GetMyReserveshionTime : IRequest<ServiceResult<GetMyReserveshionDto>>
    {
        public GetMyReserveshionTime(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

    }

    public class GetMyReserveshionTimeHandler : IRequestHandler<GetMyReserveshionTime, ServiceResult<GetMyReserveshionDto>>
    {
        protected readonly ReservationRepository _reservationRepository;
        protected readonly ShiftRepository _shiftRepository;

        public GetMyReserveshionTimeHandler(ReservationRepository ReservationRepository, ShiftRepository ShiftRepository)
        {
            _reservationRepository = ReservationRepository;
            _shiftRepository = ShiftRepository;
        }


        public async Task<ServiceResult<GetMyReserveshionDto>> Handle(GetMyReserveshionTime request, CancellationToken cancellationToken)
        {

            var reserviosnes = _reservationRepository.GetAll()
            .Where(x => x.UserId.Equals(request.UserId));

            var doneSinceInput = new List<MyReservationDto>();
            var doneSince = reserviosnes.Where(x => x.IsDone == true).ToList();
            var shiftOIds = doneSince.Select(x => x.ShiftId).ToList();
            var shiftOffullSince = _shiftRepository.GetAll()
            .Where(x => shiftOIds.Contains(x.Id.ToString())).ToList();
            doneSince.ForEach(item =>
            {
                var dto = new MyReservationDto();
                dto.DoctorId = item.DoctorId;
                dto.IsDone = item.IsDone;
                var shift = shiftOffullSince.FirstOrDefault(predicate: x => x.Id.Equals(item.ShiftId));
                dto.Shift = shift.Adapt<ShiftReserveshionResultDto>();
                dto.TrackingCode = item.TrackingCode;
                doneSinceInput.Add(dto);
            });



            var inComingReserviosnes = _reservationRepository.GetAll()
                        .Where(x => x.UserId.Equals(request.UserId));

            var inComingReserviosnesInput = new List<MyReservationDto>();
            var inComingSince = inComingReserviosnes.Where(x => x.IsDone == false).ToList();
            var incomningShiftOIds = inComingSince.Select(x => x.ShiftId).ToList();
            var inCommingSince = _shiftRepository.GetAll()
            .Where(x => shiftOIds.Contains(x.Id.ToString())).ToList();
            inComingSince.ForEach(item =>
            {
                var dto = new MyReservationDto();
                dto.DoctorId = item.DoctorId;
                dto.IsDone = item.IsDone;
                var shift = inCommingSince.FirstOrDefault(predicate: x => x.Id.Equals(item.ShiftId));
                dto.Shift = shift.Adapt<ShiftReserveshionResultDto>();
                dto.TrackingCode = item.TrackingCode;
                doneSinceInput.Add(dto);
            });





            var res = new GetMyReserveshionDto(doneSinceInput, inComingReserviosnesInput);

            return ServiceResult.Create(res);
        }
    }
}
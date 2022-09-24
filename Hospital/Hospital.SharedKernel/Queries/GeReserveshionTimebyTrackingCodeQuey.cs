using Hospital.Services;
using Hospital.Web.DtoModels;
using Mapster;
using MediatR;

namespace Hospital.SharedKernel.Queries
{
    public class GeReserveshionTimebyTrackingCodeQuey : IRequest<ServiceResult<ReservationDto>>
    {
        public GeReserveshionTimebyTrackingCodeQuey(string trackingCode)
        {
            TrackingCode = trackingCode;
        }

        public string TrackingCode { get; set; }

    }

    public class GeReserveshionTimebyTrackingCodeQueyHandler : IRequestHandler<GeReserveshionTimebyTrackingCodeQuey, ServiceResult<ReservationDto>>
    {
        protected readonly ReservationRepository _reservationRepository;
        protected readonly ShiftRepository _shiftRepository;

        public GeReserveshionTimebyTrackingCodeQueyHandler(ReservationRepository ReservationRepository, ShiftRepository ShiftRepository)
        {
            _reservationRepository = ReservationRepository;
            _shiftRepository = ShiftRepository;
        }


        public async Task<ServiceResult<ReservationDto>> Handle(GeReserveshionTimebyTrackingCodeQuey request, CancellationToken cancellationToken)
        {
            var reservation = _reservationRepository.GetAll()
            .FirstOrDefault(x => x.TrackingCode.Equals(request.TrackingCode));

            if (reservation is null)
                throw new Exception("this reservishion is not exist");


            var shift = _shiftRepository.GetShiftById(reservation.ShiftId);



            var res = new ReservationDto();
            res.DoctorId = reservation.DoctorId;
            res.IsDone = reservation.IsDone;
            res.Shift = shift.Adapt<ShiftReserveshionResultDto>();



            return ServiceResult.Create(res);
        }
    }
}
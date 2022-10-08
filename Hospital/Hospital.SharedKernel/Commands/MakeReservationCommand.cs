using Hospital.Core;
using Hospital.Services;
using MediatR;

namespace Hospital.SharedKernel.Commands
{
    public class MakeReservationCommand : IRequest<ServiceResult<string>>
    {
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public string ShiftId { get; set; }

    }
    public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, ServiceResult<string>>
    {
        protected readonly ReservationRepository _reservationRepository;
        protected readonly DoctorRepository _doctorRepository;
        protected readonly ShiftRepository _shiftRepository;

        public MakeReservationCommandHandler(ReservationRepository ReservationRepository,
        DoctorRepository DoctorRepository, ShiftRepository ShiftRepository)
        {
            _reservationRepository = ReservationRepository;
            _doctorRepository = DoctorRepository;
            _shiftRepository = ShiftRepository;
        }

        public async Task<ServiceResult<string>> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
        {
            var checkReservation = _reservationRepository.CheckReservation(request.ShiftId, request.DoctorId);



            if (checkReservation != null)
                throw new Exception("this shift time is full");

            var doctor = _doctorRepository.GetFirstById(request.DoctorId);


            if (doctor is null)
                throw new Exception("this Doctor is not exist");





            var shift = _shiftRepository.GetShiftById(request.ShiftId);
            if (shift is null)
                throw new Exception("this shift is not exist");

            var istance = new ReservationEntity(request.UserId, request.DoctorId, request.ShiftId);
            var res = _reservationRepository.AddReservaghtion(istance);
            return ServiceResult.Create(res);
        }
    }
}
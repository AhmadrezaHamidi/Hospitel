using Hospital.Core;
using Hospital.Services;
using MediatR;

namespace Hospital.SharedKernel.Commands
{
    public class CreateShiftCommand : IRequest<ServiceResult<string>>
    {
        public int WorkDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
     
    public class CreateShiftCommandHandler : IRequestHandler<CreateShiftCommand, ServiceResult<string>>
    {
        protected readonly ShiftRepository _shiftRepository;

        public CreateShiftCommandHandler(ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<ServiceResult<string>> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
        {
            var shift = _shiftRepository.CheckShift(request.WorkDay,
             request.Start,request.End);


            if (shift != null)
                throw new Exception("this dock is exist");

            var istance = new ShiftEntity(request.WorkDay, request.Start,request.End);
            var res = _shiftRepository.AddShift(istance);
            return ServiceResult.Create(res);
        }
    }
}
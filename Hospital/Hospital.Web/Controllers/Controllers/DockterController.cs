using Hospital.DtoModels.UserDtos;
using Hospital.Infrastructure;
using Hospital.Services;
using Hospital.SharedKernel.Commands;
using Hospital.Web.DtoModels.UserDtos;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hospital.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Hospital.SharedKernel.Queries;


namespace Hospital.Web.Controllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DoctorController : AHControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(ILogger<UserController> logger
        , IMediator _madiator) : base(logger)
        {
            _mediator = _madiator;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> RegisterDoctor([FromBody] RegisteDoctorDto input)
        {
            var command = input.Adapt<CreateDoctorCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }



        [HttpPost]
       /// [Authorize(Roles = "doctor")]
        public async Task<ActionResult<ServiceResult<string>>> CreateShift([FromBody] CreateShiftDto input)
        {
            var command = input.Adapt<CreateShiftCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }





        [HttpGet]
      ///  [Authorize(Roles = "doctor")]
        public async Task<ActionResult<ServiceResult<List<ShiftResultDto>>>> GetShiftes()
        {
            var command = new GetShiftesQuery();
            var result = await _mediator.Send<ServiceResult<List<ShiftResultDto>>>(command);
            return await result?.AsyncResult();
        }



        [HttpPost]
       /// [Authorize(Roles = "doctor")]
        public async Task<ActionResult<ServiceResult<string>>> MakeReservation([FromBody] MakeReservationInputDto input)
        {
            var command = input.Adapt<MakeReservationCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }

    }
}
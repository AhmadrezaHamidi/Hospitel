using Hospital.DtoModels.UserDtos;
using Hospital.Infrastructure;
using Hospital.Services;
using Hospital.SharedKernel.Commands;
using Hospital.SharedKernel.Queries;
using Hospital.Web.DtoModels;
using Hospital.Web.DtoModels.UserDtos;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UserController : AHControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger
        , IMediator _madiator) : base(logger)
        {
            _mediator = _madiator;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> RegisterUser([FromBody] RegisterUserDto input)
        {
            var command = input.Adapt<CreateUserCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }



        [HttpPost("logIn")]
        public async Task<ActionResult<ServiceResult<string>>> LogIn([FromBody] LoginInputDto input)
        {
            var command = new LoginUserCommand(input.NationaCode, input.PassWord);
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();

        }





        [HttpGet("Dockters")]
     ///   [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<List<DocktersResultDto>>>> GetDockters()
        {
            var command = new GetDocktersQuery();
            var result = await _mediator.Send<ServiceResult<List<DocktersResultDto>>>(command);
            return await result?.AsyncResult();
        }



        [HttpGet("{dockterId}")]
      //  [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<DockterReservationDto>>> GetDockterReservation([FromRoute] string dockterId)
        {
            var command = new GetDockterReservation(dockterId);
            var result = await _mediator.Send<ServiceResult<DockterReservationDto>>(command);
            return await result?.AsyncResult();
        }



        [HttpPost]
     //   [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<string>>> MakeReservation([FromBody] Hospital.DtoModels.MakeReservationInputDto input)
        {
            var command = input.Adapt<MakeReservationCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }



        [HttpPost]
       /// [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<GetMyReserveshionDto>>> GetMyReserveshionTime(string userId)
        {
            var command = new GetMyReserveshionTime(userId);
            var result = await _mediator.Send<ServiceResult<GetMyReserveshionDto>>(command);
            return await result?.AsyncResult();
        }



    }
}
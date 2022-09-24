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


        /// <summary>
        /// برای ثبت نام کاریر 
        /// </summary>
        /// <param name="RegisterUser"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> RegisterUser([FromBody] RegisterUserDto input)
        {
            var command = input.Adapt<CreateUserCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }




        /// <summary>
        /// برای ورود کاریر 
        /// </summary>
        /// <param name="logIn"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>

        [HttpPost("logIn")]
        public async Task<ActionResult<ServiceResult<string>>> LogIn([FromBody] LoginInputDto input)
        {
            var command = new LoginUserCommand(input.NationaCode, input.PassWord);
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();

        }





        /// <summary>
        /// برای گرفتن لیست دکتر ها 
        /// </summary>
        /// <param name="Dockters"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>

        [HttpGet("Dockters")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<List<DocktersResultDto>>>> GetDockters()
        {
            var command = new GetDocktersQuery();
            var result = await _mediator.Send<ServiceResult<List<DocktersResultDto>>>(command);
            return await result?.AsyncResult();
        }





        /// <summary>
        /// دیدن وقت های دکتر ها 
        /// </summary>
        /// <param name="GetDockterShift"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>
        [HttpGet("{dockterId}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<DockterReservationDto>>> GetDockterShift([FromRoute] string dockterId)
        {
            var command = new GetDockterReservation(dockterId);
            var result = await _mediator.Send<ServiceResult<DockterReservationDto>>(command);
            return await result?.AsyncResult();
        }





         /// <summary>
        /// گرفتن وقت با دکتر  
        /// </summary>
        /// <param name="GetDockterShift"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<string>>> MakeReservation([FromBody] Hospital.DtoModels.MakeReservationInputDto input)
        {
            var command = input.Adapt<MakeReservationCommand>();
            var result = await _mediator.Send<ServiceResult<string>>(command);
            return await result?.AsyncResult();
        }





        /// <summary>
        /// دیدن وقت های من   
        /// </summary>
        /// <param name="GetDockterShift"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<GetMyReserveshionDto>>> GetMyReserveshionTime(string userId)
        {
            var command = new GetMyReserveshionTime(userId);
            var result = await _mediator.Send<ServiceResult<GetMyReserveshionDto>>(command);
            return await result?.AsyncResult();
        }




        /// <summary>
        /// بیگیری نوبت دکتر با شماره بیگیری    
        /// </summary>
        /// <param name="GetDockterShift"></param>
        /// <returns>تایید با کد 200 یا عدم تایید با خطای 400</returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> GeReserveshionTimebyTrackingCode(string trackingCode)
        {
            var command = new GeReserveshionTimebyTrackingCodeQuey(trackingCode);
            var result = await _mediator.Send<ServiceResult<ReservationDto>>(command);
            return await result?.AsyncResult();
        }



    }
}
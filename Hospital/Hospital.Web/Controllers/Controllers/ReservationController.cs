using Microsoft.AspNetCore.Mvc;
using Hospital.DtoModels;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Hospital.DtoModels.UserDtos;
using Mapster;
using Clinic_management_api.DtoModels;
using Hospital.Services;
using Hospital.Infrastructure;
using Hospital.SharedKernel.Commands;
using Hospital.SharedKernel.Queries;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ReservationController : AHControllerBase
{
    protected readonly UserRepository _userRepository;
    protected readonly DoctorRepository _doctorRepository;
    protected readonly ReservationRepository _reservationRepository;
    private readonly IMediator _mediator;

    public ReservationController(ILogger<ReservationController> logger
     , UserRepository userRepository, DoctorRepository
    doctorRepository, ReservationRepository reservationRepository,
    IMediator _madiator) : base(logger)
    {
        _userRepository = userRepository;
        _doctorRepository = doctorRepository;
        _reservationRepository = reservationRepository;
        _mediator = _madiator;
    }


    

    

    [HttpPost]
   // [Authorize]
    public async Task<ActionResult<ServiceResult<string>>> RegisterUser([FromBody] RegisterUserDto input)
    {
        var command = input.Adapt<CreateUserCommand>();
        var result = await _mediator.Send<ServiceResult<string>>(command);
        return await result?.AsyncResult();
    }


    [HttpPost]
   // [Authorize]
    
    public async Task<ActionResult<ServiceResult<string>>> RegisterDoctor([FromBody] RegisteDoctorDto input)
    {
        var command = input.Adapt<CreateDoctorCommand>();
        var result = await _mediator.Send<ServiceResult<string>>(command);
        return await result?.AsyncResult();
    }



    [HttpPost]
    //[Authorize]
    
    public async Task<ActionResult<ServiceResult<string>>> CreateShift([FromBody] CreateShiftDto input)
    {
        var command = input.Adapt<CreateShiftCommand>();
        var result = await _mediator.Send<ServiceResult<string>>(command);
        return await result?.AsyncResult();
    }




    [HttpGet]
    ///[Authorize]
    public async Task<ActionResult<ServiceResult<List<ShiftResultDto>>>> GetShiftes()
    {
        var command =  new GetShiftesQuery();
        var result = await _mediator.Send<ServiceResult<List<ShiftResultDto>>>(command);
        return await result?.AsyncResult();
    }



    [HttpPost]
    //[Authorize]
    public async Task<ActionResult<ServiceResult<string>>> MakeReservation([FromBody] MakeReservationInputDto input)
    {
        var command = input.Adapt<MakeReservationCommand>(); 
        var result = await _mediator.Send<ServiceResult<string>>(command);
        return await result?.AsyncResult();
    }











}


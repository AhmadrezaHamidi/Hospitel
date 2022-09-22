using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure;

[ApiController]
[Route("api/v1/[controller]/[action]")]

public abstract class AHControllerBase : ControllerBase
{
    protected readonly ILogger logger;

    public AHControllerBase()
    {

    }

    public AHControllerBase(ILogger logger)
    {
        this.logger = logger;
    }

}

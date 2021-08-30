using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Travel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public abstract class ApiController:ControllerBase
    {
        private IMediator _medistor;
        protected IMediator Mediator => _medistor ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

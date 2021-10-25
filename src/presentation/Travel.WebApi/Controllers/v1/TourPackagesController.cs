using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Travel.Data.Contexts;
//using Travel.Domain.Entities;
using Travel.Application.TourPackages.Commands.CreateTourPackage;
using Travel.Application.TourPackages.Commands.DeleteTourPackage;
using Travel.Application.TourPackages.Commands.UpdateTourPackage;
using Travel.Application.TourPackages.Commands.UpdateTourPackageDetail;
using Travel.Application.TourPackages.Queries;
using Travel.Application.Dtos.Tour;


namespace Travel.WebApi.Controllers.v1
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class TourPackagesController : ApiController //ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TourPackageDto>>> GetTourPackages([FromQuery] GetTourPackagesQuery query)
        {
            return await Mediator.Send(query);
        }
        //private readonly TravelDbContext _context;

        //public TourPackagesController(TravelDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_context.TourPackages);
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTourPackageCommand command) //[FromBody] TourPackage tourPackage)
        {
            //await _context.TourPackages.AddAsync(tourPackage);
            //await _context.SaveChangesAsync();
            //return Ok(tourPackage);
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) //[FromRoute] int id)
        {
            //var tourPackage = await _context.TourPackages.SingleOrDefaultAsync(tp => tp.Id == id);
            //if (tourPackage == null)
            //{
            //    return NotFound();
            //}

            //_context.TourPackages.Remove(tourPackage);
            //await _context.SaveChangesAsync();

            //return Ok(tourPackage);
            await Mediator.Send(new DeleteTourPackageCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTourPackageCommand command) //[FromRoute] int id,[FromBody] TourPackage tourPackage)
        {
            //_context.Update(tourPackage);
            //await _context.SaveChangesAsync();
            //return Ok(tourPackage);
            if (id != command.Id)
                return BadRequest();
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTourPackageDetailCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            await Mediator.Send(command);

            return NoContent();
        }
    }
}

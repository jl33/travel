using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Travel.Data.Contexts;
//using Travel.Domain.Entities;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourLists.Commands.DeleteTourList;
using Travel.Application.TourLists.Commands.UpdateTourList;
using Travel.Application.TourLists.Queries.ExportTours;
using Travel.Application.TourLists.Queries.GetTours;

namespace Travel.WebApi.Controllers.v1
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class TourListsController : ApiController //ControllerBase
    {
        //private readonly TravelDbContext _context;

        //public TourListsController(TravelDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_context.TourLists);
        //}

        [HttpGet]
        public async Task<ActionResult<ToursVm>> Get()
        {
            return await Mediator.Send(new GetToursQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportToursQuery { ListId = id });
            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTourListCommand command) //[FromBody] TourList tourList)
        {
            //await _context.TourLists.AddAsync(tourList);
            //await _context.SaveChangesAsync();
            //return Ok(tourList);
            return await Mediator.Send(command);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTourListCommand command) //[FromRoute] int id, [FromBody] TourList tourList)
        {
            //_context.Update(tourList);
            //await _context.SaveChangesAsync();
            //return Ok(tourList);
            if (id != command.Id)
                return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) //[FromRoute] int id)
        {
            //var tourList = await _context.TourLists.SingleOrDefaultAsync(tp => tp.Id == id);
            //if (tourList == null)
            //{
            //    return NotFound();
            //}

            //_context.TourLists.Remove(tourList);
            //await _context.SaveChangesAsync();

            //return Ok(tourList);
            await Mediator.Send(new DeleteTourListCommand { Id = id });
            return NoContent();
        }

    }
}

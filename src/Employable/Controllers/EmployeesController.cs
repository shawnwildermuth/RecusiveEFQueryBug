using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employable.Data;
using Employable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employable.Controllers
{
  [Route("api/[controller]")]
  public class EmployeesController : Controller
  {
    private EmployableContext _ctx;
    private IMappingEngine _mapper;

    public EmployeesController(EmployableContext ctx, IMappingEngine mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    // GET api/values
    [HttpGet]
    public IActionResult Get()
    {
      var emp = _ctx.Employees.Include(e => e.Reports).Include(e => e.Department).ToList();

      return Ok(_mapper.Map<IEnumerable<EmployeeViewModel>>(emp));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var emp = _ctx.Employees
        .Include(e => e.Reports)
        .Include(e => e.Department)
//        .ToList()
        .Where(e => e.Id == id)
        .FirstOrDefault();

      return Ok(_mapper.Map<EmployeeViewModel>(emp));
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}

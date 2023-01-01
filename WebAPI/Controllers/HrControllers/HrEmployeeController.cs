using Application.Features.Hr.Commands;
using Application.Features.Hr.Queries;
using Domain.Hr;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers.HrControllers
{
    public class HrEmployeeController : BaseGeneralController
    {
        [HttpGet]
        [Route("/FindEmployee/{Id}")]
        public async Task<IActionResult> FindEmployee(int Id)
        {
            return Ok(await Mediator.Send(new GetEmployeeQuery() { Id = Id }));
        }
        [HttpPost]
        [Route("/CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpPut]
        [Route("/EditEmployee")]
        public async Task<IActionResult> EditEmployee(UpdateEmployeeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [HttpDelete]
        [Route("/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployeeCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}

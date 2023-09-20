using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverManagement.Application.ViewModels;
using DriverManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DriverManagement.Api.Controllers.DriverManagementController
{

    [ApiController]
    [Route("api/[controller]")]
    public class DriverManagementController : ControllerBase
    {
       protected readonly IDriverManagementService _driverManagementService;

       public DriverManagementController(IDriverManagementService driverManagementService)
       {
           _driverManagementService = driverManagementService;
       }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _driverManagementService.GetAllDrivers();
            return Ok(result);
        }

        [HttpGet("drivers/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _driverManagementService.GetDriverById(id);
            return Ok(result);
        }

        [HttpPost("drivers")]
        public async Task<IActionResult> Create([FromBody] DriverViewModel driver)
        {
            var result = await _driverManagementService.CreateDriver(driver);
            return Ok(result);
        }

        [HttpPut("drivers")]
        public async Task<IActionResult> Update([FromBody] DriverViewModel driver)
        {
            var result = await _driverManagementService.UpdateDriver(driver);
            return Ok(result);
        }

        [HttpDelete("drivers/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _driverManagementService.DeleteDriver(id);
            return Ok();
        }
    }
}
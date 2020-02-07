using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataAccess.Repositories.Interfaces;
using HomeAreaManagement.ViewModels;
using HomeAreaManagement.Extensions;

namespace HomeAreaManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly ILogger<AreasController> _logger;
        private readonly IAreaRepository _areaRepository;

        public AreasController(ILogger<AreasController> logger, IAreaRepository areaRepository)
        {
            _logger = logger;
            _areaRepository = areaRepository;
        }

        [HttpGet]
        public IEnumerable<AreaViewModel> Get()
        {
            return _areaRepository.GetAllAreas().Select(i => i.ConvertToAreaViewModel());
        }

        [HttpGet("{id}")]
        public AreaViewModel Get(int id)
        {
            return _areaRepository.GetAreaById(id).ConvertToAreaViewModel();
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] AreaViewModel area)
        {
            try
            {
                if (area != null)
                {
                    area.UpdatedOn = Convert.ToString(DateTime.Now);
                    area.UpdatedById = "1";
                    _areaRepository.UpdateArea(area.ConvertToAreaModel());
                    return Ok(area);
                }
                return BadRequest("Error Occured");
            }
            catch(Exception Ex)
            {
                //To-Do: log the message
                return BadRequest("Error Occured" + Ex.Message);
            }
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    _areaRepository.RemoveAreaById(id);
                    return Ok(id);
                }
                return BadRequest("Error Occured");
            }
            catch (Exception Ex)
            {
                //To-Do: log the message
                return BadRequest("Error Occured" + Ex.Message);
            }
        }
    }
}

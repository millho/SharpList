using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/houses")]
    public class HouseController : ControllerBase
    {

        private readonly HouseService _houseService;
        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        public ActionResult<List<House>> GetAllHouses()
        {
            try
            {

                List<House> houses = _houseService.GetAllHouses();
                return Ok(houses);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{houseId}")]
        public ActionResult<House> GetHouseById(int houseId)
        {
            try
            {
                House house = _houseService.GetHouseById(houseId);
                return Ok(house);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<House> CreateHouse([FromBody] House houseData)
        {
            try
            {
                House house = _houseService.CreateHouse(houseData);
                return Ok(house);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{houseId}")]
        public ActionResult<House> UpdateHouse([FromBody] House houseData, int houseId)
        {
            try
            {
                houseData.Id = houseId;
                House house = _houseService.UpdateHouse(houseData);
                return Ok(house);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{houseId}")]
        public ActionResult<string> DeleteHouse(int houseId)
        {
            string message = _houseService.DeleteHouse(houseId);
            return Ok(message);
        }
    }
}
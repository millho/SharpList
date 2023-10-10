using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class HouseService
    {

        private readonly HouseRepository _repo;
        public HouseService(HouseRepository repo)
        {
            _repo = repo;
        }

        internal List<House> GetAllHouses()
        {
            List<House> houses = _repo.GetAllHouses();
            return houses;
        }

        internal House GetHouseById(int houseId)
        {
            House house = _repo.GetHouseById(houseId);
            if (house == null) throw new Exception($"No House found at ID '{houseId}'");
            return house;
        }

        internal House CreateHouse(House houseData)
        {
            House house = _repo.CreateHouse(houseData);
            return house;
        }

        internal House UpdateHouse(House houseData)
        {
            House original = this.GetHouseById(houseData.Id);
            original.Bathrooms = houseData.Bathrooms ?? original.Bathrooms;
            original.Bedrooms = houseData.Bedrooms ?? original.Bedrooms;
            original.Description = houseData.Description ?? original.Description;
            original.Price = houseData.Price ?? original.Price;
            original.Year = houseData.Year ?? original.Year;
            original.Image = houseData.Image ?? original.Image;
            House house = _repo.UpdateHouse(original);
            return house;
        }

        internal string DeleteHouse(int houseId)
        {
            this.GetHouseById(houseId);
            _repo.DeleteHouse(houseId);
            return $"House at ID '{houseId}' has been deleted";
        }
    }
}
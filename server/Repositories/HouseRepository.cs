using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories
{
    public class HouseRepository
    {
        private readonly IDbConnection _db;
        public HouseRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<House> GetAllHouses()
        {
            string sql = "SELECT * FROM houses;";
            List<House> houses = _db.Query<House>(sql).ToList();
            return houses;
        }

        internal House GetHouseById(int houseId)
        {
            string sql = "SELECT * FROM houses WHERE id = @houseId;";
            House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
            return house;
        }

        internal House CreateHouse(House houseData)
        {
            string sql = @"
            INSERT INTO houses
                (bedrooms, bathrooms, description, year, price, image)
            VALUES
                (@bedrooms, @bathrooms, @description, @year, @price, @image);
            SELECT * FROM houses WHERE id = LAST_INSERT_ID();";
            House house = _db.Query(sql, houseData).FirstOrDefault();
            return house;
        }

        internal House UpdateHouse(House original)
        {
            string sql = @"
            UPDATE cars
            SET
                bedrooms = @bedrooms,
                bathrooms = @bathrooms,
                year = @year,
                price = @price,
                image = @image,
                description = @description,
            WHERE id = @id;
            SELECT * FROM cars WHERE id = @id;";
            House house = _db.Query<House>(sql, original).FirstOrDefault();
            return house;
        }

        internal void DeleteHouse(int houseId)
        {
            string sql = "DELETE FROM houses WHERE id = @houseId;";
            _db.Execute(sql, new { houseId });
        }
    }
}
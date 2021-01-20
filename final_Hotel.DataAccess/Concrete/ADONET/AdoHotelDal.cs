using final_Hotel.DataAccess.Abstract;
using final_Hotel.Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace final_Hotel.DataAccess.Concrete.ADONET
{
    public class AdoHotelDal : IHotelDal
    {
        public void Add(Hotel entity)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Hotels (HotelName,FeePerNight,Stars) " +
                "VALUES(@HotelName,@FeePerNight,@Stars)"))
            {
                cmd.Parameters.AddWithValue("HotelName", entity.HotelName);
                cmd.Parameters.AddWithValue("FeePerNight", entity.FeePerNight);
                cmd.Parameters.AddWithValue("Stars", entity.Stars);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Delete(Hotel entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM Hotels WHERE HotelId = @HotelId"))
            {
                cmd.Parameters.AddWithValue("HotelId", entity.HotelId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            List<Hotel> hotelList = new List<Hotel>();
            SqlCommand cmd = new SqlCommand("Select * from Hotels");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Hotel hotel = new Hotel
                {
                    HotelId = Convert.ToInt32(reader[0]),
                    HotelName = reader[1].ToString(),
                    Stars = Convert.ToInt32(reader[2]),
                    FeePerNight = Convert.ToDecimal(reader[3].ToString())
                };

                hotelList.Add(hotel);
            }
            var list = hotelList.Where(filter.Compile()).ToList();
            return list[0] ;
        }
        public List<Hotel> GetFilter(Expression<Func<Hotel, bool>> filter)
        {
            List<Hotel> hotelList = new List<Hotel>();
            SqlCommand cmd = new SqlCommand("Select * from Hotels");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Hotel hotel = new Hotel
                {
                    HotelId = Convert.ToInt32(reader[0]),
                    HotelName = reader[1].ToString(),
                    Stars = Convert.ToInt32(reader[2]),
                    FeePerNight = Convert.ToDecimal(reader[3].ToString())
                };

                hotelList.Add(hotel);
            }
            var list = hotelList.Where(filter.Compile()).ToList();
            return hotelList.Where(filter.Compile()).ToList(); ;
        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {

            List<Hotel> hotelList = new List<Hotel>();
            SqlCommand cmd = new SqlCommand("Select * from Hotels");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Hotel hotel = new Hotel
                {
                    HotelId = Convert.ToInt32(reader[0]),
                    HotelName = reader[1].ToString(),
                    Stars = Convert.ToInt32(reader[2]),
                    FeePerNight = Convert.ToDecimal(reader[3].ToString())
                };

                hotelList.Add(hotel);
            }

            return filter == null ? hotelList : hotelList.Where(filter.Compile()).ToList();


        }

        public void Update(Hotel entity)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Hotels set HotelName = @HotelName, FeePerNight=@FeePerNight, Stars=@Stars WHERE HotelId = @HotelId"))
            {
                cmd.Parameters.AddWithValue("@HotelId", entity.HotelId);
                cmd.Parameters.AddWithValue("@HotelName", entity.HotelName);
                cmd.Parameters.AddWithValue("@FeePerNight", entity.FeePerNight);
                cmd.Parameters.AddWithValue("@Stars", entity.Stars);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }
    }
}

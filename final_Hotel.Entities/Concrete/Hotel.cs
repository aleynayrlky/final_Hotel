using final_Hotel.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_Hotel.Entities.Concrete
{
    public class Hotel : IEntity
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public decimal FeePerNight { get; set; }
        public int Stars { get; set; }
        public Hotel()
        {

        }
        public Hotel(string hotelName, decimal feePerNight, int stars)
        {
            HotelName = hotelName;
            FeePerNight = feePerNight;
            Stars = stars;
        }
        public override string ToString()
        {
            return $"{HotelId,-5} {HotelName,-30} {FeePerNight,-5} {Stars,-5}";
        }
    }
}

using final_Hotel.Business.Abstract;
using final_Hotel.DataAccess.Abstract;
using final_Hotel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace final_Hotel.Business.Concrete
{
    public class HotelManager : IHotelService
    {

        // Dependency Injection
        private IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotel)
        {
            _hotelDal = hotel;
        }

        public void Add(Hotel entity)
        {
            _hotelDal.Add(entity);
        }

        public void Delete(Hotel entity)
        {
            _hotelDal.Delete(entity);
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            return _hotelDal.Get(filter);
        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {
            return _hotelDal.GetAll(filter);
        }

        public List<Hotel> GetFilter(Expression<Func<Hotel, bool>> filter)
        {
            return _hotelDal.GetFilter(filter);
        }

        public void Update(Hotel entity)
        {
            _hotelDal.Update(entity);
        }
    }
}

using final_Hotel.DataAccess.Abstract;
using final_Hotel.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_Hotel.DataAccess.Concrete.EntityFramework
{
    public class EfHotelDal : EfRepositoryBase<Hotel, HotelContext>, IHotelDal
    {

    }
}

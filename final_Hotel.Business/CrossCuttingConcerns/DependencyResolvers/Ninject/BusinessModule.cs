using final_Hotel.Business.Abstract;
using final_Hotel.Business.Concrete;
using final_Hotel.DataAccess.Abstract;
using final_Hotel.DataAccess.Concrete.ADONET;
using final_Hotel.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace final_Hotel.Business.CrossCuttingConcerns.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHotelService>().To<HotelManager>().InSingletonScope();
           // Bind<IHotelDal>().To<EfHotelDal>().InSingletonScope();
            Bind<IHotelDal>().To<EfHotelDal>().InSingletonScope();
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal aaboutDal;

        public AboutManager(IAboutDal aaboutDal)
        {
            this.aaboutDal = aaboutDal;
        }

        public List<About> GetList()
        {
           return aaboutDal.GetListAll();
        }
    }
}

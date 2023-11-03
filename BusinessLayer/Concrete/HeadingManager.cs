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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headerdal;

        public HeadingManager(IHeadingDal headerdal)
        {
            _headerdal = headerdal;
        }

        public Heading GetByID(int id)
        {
            return _headerdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headerdal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headerdal.Insert(heading);
        }

       

    

        public void HeadingDelete(Heading p)
        {
            _headerdal.Delete(p);
        }

       

        public void HeadingUpdate(Heading p)
        {
            _headerdal.Update(p);
        }
    }
}

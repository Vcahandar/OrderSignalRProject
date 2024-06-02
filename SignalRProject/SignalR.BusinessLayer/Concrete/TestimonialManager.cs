using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public void TAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
           _testimonialDal.Delete(entity);
        }

        public Testimonial TGetById(int id)
        {
           return _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
           return _testimonialDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
           _testimonialDal.Update(entity);
        }
    }
}

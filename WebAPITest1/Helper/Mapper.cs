using AutoMapper;
using WebAPITest1.Model;
using WebAPITest1.Model.DTO;

namespace WebAPITest1.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}

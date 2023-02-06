using Microsoft.EntityFrameworkCore;
using TravelLibrary.Server.Data;

namespace TravelLibrary.Server.Test
{
    public class TestBase
    {
        protected dbTravelLIBContext ConstruirContext(string dbName)
        {
            var opciones = new DbContextOptionsBuilder<dbTravelLIBContext>()
                .UseInMemoryDatabase(dbName).Options;
            var dbContext = new dbTravelLIBContext(opciones);
            return dbContext;
        }


        /*protected class IMapper ContruirAutoMapper() 
        {
            var config = new MapperConfiguration(opt =>
            {
                var geomtryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                //opt.AddProfile(AutoMapperProfiles(geomtryFactory));
            });
            return config.CreateMapper();
        }*/
    }
}

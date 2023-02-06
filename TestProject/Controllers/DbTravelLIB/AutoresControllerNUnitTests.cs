using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TravelLibrary.Server.Test;
using TravelLibrary.Server.Controllers.dbTravelLIB;
using TravelLibrary.Server.Data;
using TravelLibrary.Server.Models.dbTravelLIB;
using System.Xml.Linq;

// AutoresControllerNUnitTests.cs  
// compile with: /reference:..\Server\TravelLibrary.Server.csproj /reference:..\Client\TravelLibrary.Client.csproj
namespace TravelLibrary.Server.Controllers.DbTravelLIB
{
    [TestFixture] //Decorador para identificar la clase del tipo Test (Prueba)
    public partial class AutoresControllerNUnitTests: TestBase
    {

      //protected IEnumerable<Autore>? autores;
        protected Autore autor;
        private dbTravelLIBContext context;
        private string DbName="";
        private int nAuthors = 0;

        [SetUp]
        public void SetUp()
        {    
           //Preparación
            DbName = Guid.NewGuid().ToString();
            context = ConstruirContext(DbName);            
            nAuthors = SetTestAuthors();
        }

        [Test]
        [ValidateAntiForgeryToken]
        public void GetAutores_ConsultaAutores_ReturnTrue()
        {
            //Hasta aquí hemos guardado datos de prueba 
            //Prueba (Se ejecuta como tal la prueba, pero usando dbcontext y no context...)
            var dbcontext = ConstruirContext(DbName);
            //Microsoft.AspNetCore.Components.NavigationManager navigationManager = null;
            var controller = new AutoresController(dbcontext);
            var result = controller.GetAutores().ToList();
            //Verificación
            Assert.AreEqual(nAuthors, result.Count());
        }

        public int SetTestAuthors()
        {
            for (byte i = 200; i <= 205 ; i++) 
            {
                context.Autores.Add(new Autore() {id=i,nombre="Nombres"+i.ToString(),apellidos="Apellidos "+i.ToString(), autor = "Nombres" + i.ToString() + " "+ "Apellidos " + i.ToString() });
            }

            context.SaveChanges();
            
            return context.Autores.Count();
        }
    }
}

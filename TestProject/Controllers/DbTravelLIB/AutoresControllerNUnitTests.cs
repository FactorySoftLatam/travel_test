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
        //Emuladmos al context
        //[Inject]
        //public dbTravelLIBService? dbTravelLIBService { get; set; }

        protected IEnumerable<Autore>? autores;
        protected Autore autor;
        private dbTravelLIBContext context;
        private string DbName="";

        [SetUp]
        public void SetUp()
        {
            autor = Substitute.For<Autore>();
            autor = new Autore()
            {
                id = 300,
                nombre = "Nombres 1",
                apellidos = "Apellidos 1"
            };
            autor = new Autore()
            {
                id = 301,
                nombre = "Nombres 2",
                apellidos = "Apellidos2"
            };

            //Preparación
            DbName = Guid.NewGuid().ToString();
            this.context = ConstruirContext(DbName);
        }

        [Test]
        [ValidateAntiForgeryToken]
        public void GetAutores_ConsultaAutores_ReturnTrue()
        {
            //Preparación
            int nAuthors = SetTestAuthors();

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

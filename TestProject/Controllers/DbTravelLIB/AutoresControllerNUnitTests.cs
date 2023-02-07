using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.SignalR;
using TravelLibrary.Server.Controllers.dbTravelLIB;
using TravelLibrary.Server.Data;
using TravelLibrary.Server.Models.dbTravelLIB;

// AutoresControllerNUnitTests.cs  
// compile with: /reference:..\Server\TravelLibrary.Server.csproj /reference:..\Client\TravelLibrary.Client.csproj
namespace TravelLibrary.Server.Test.Controllers.DbTravelLIB
{
    [TestFixture] //Decorador para identificar la clase del tipo Test (Prueba)
    public partial class AutoresControllerNUnitTests : TestBase
    {

        //protected IEnumerable<Autore>? autores;
        protected Autore[] autorArray;
        private dbTravelLIBContext context;
        private string DbName = "";
        private int nAuthors = 0;

        public int SetTestAuthors()
        {
            for (byte i = 200; i <= 205; i++)
            {
                _ = context.Autores.Add(new Autore() { id = i, nombre = "Nombres" + i.ToString(), apellidos = "Apellidos " + i.ToString(), autor = "Nombres" + i.ToString() + " " + "Apellidos " + i.ToString() });
            }

            _ = context.SaveChanges();

            return context.Autores.Count();
        }

        [SetUp]
        public void SetUp()
        {
            //Preparación
            DbName = Guid.NewGuid().ToString();
            context = ConstruirContext(DbName);
            nAuthors = SetTestAuthors();

            autorArray = new Autore[4]
            { new Autore {id=90,nombre="Nombre 90",apellidos="Apellido 90",autor="Nombre 90 Apellido 90" },
              new Autore {id=91,nombre="Nombre 91",apellidos="Apellido 91",autor="Nombre 91 Apellido 91" },
              new Autore {id=92,nombre="Nombre 92",apellidos="Apellido 92",autor="Nombre 92 Apellido 92" },
              new Autore {id=93,nombre="Nombre 93",apellidos="Apellido 93",autor="Nombre 93 Apellido 93" },
            };

        }

        [Test]
        [ValidateAntiForgeryToken]
        public void ObtenerAutores_ReturnTrue()
        {
            //Hasta aquí hemos guardado datos de prueba 
            //Prueba (Se ejecuta como tal la prueba, pero usando dbcontext y no context...)
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            List<Autore> result = controller.GetAutores().ToList();
            //Verificación
            int totalAutores = result.Count();
            string xAutor = result[0].ToString();
            //Que el controlador devuleve datos
            Assert.IsNotNull(result);
            //Que se cumpla una condción cuaqluiera esperada
            Assert.IsTrue(xAutor.ToString() != string.Empty, "No hay autores registrados");
            //Que la cantidad de registros sean equivalenetes 
            Assert.That(totalAutores, Is.EqualTo(nAuthors));
        }

        [Test]
        public void Obtener_UnAutor_Existente()
        {
            //Arrange            
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            Autore? itemToReturn = context.Autores.Where(i => i.id == 200).FirstOrDefault();
            //Act
            SingleResult<Autore> result = controller.GetAutore(200);
            Autore? actual = result?.Queryable.SingleOrDefault();
            //Assert
            Assert.That(actual.id, Is.EqualTo(itemToReturn.id));
        }


        [Test]
        public void Obtener_UnAutor_NoExistente()
        {
            //Arrange            
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            //Act
            var resultado = controller.GetAutore(0);
              //Assert
            Assert.IsNull(resultado?.Queryable.FirstOrDefault());//Al buscar el registro consultado devuleve NULL
        }


        [Test]
        public void CrearAutor_OK()
        {
            //Arrange            
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            //Act
            Autore autor = new Autore();
            autor = new Autore() { nombre = "Nombre 206", apellidos = "Apellido 206", autor = "Nombre 206 Apellido 206" };

            var result = controller.Post(autor);
            
            SingleResult<Autore> data = controller.GetAutore(206);
            Autore? item = data?.Queryable.SingleOrDefault();

            var contexto2 = ConstruirContext(DbName);
            var cantidad = context.Autores.Count();
            //Assert
            Assert.IsInstanceOf<Autore>(item);  
            Assert.AreEqual(7, cantidad);            
            Assert.That(206, Is.EqualTo(item.id));
        }

        [Test]
        public void CrearAutor_Repetido()
        {
            //Arrange            
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            //Act
            Autore autor = new Autore();
            autor = new Autore() {id=205, nombre = "Nombre 205", apellidos = "Apellido 205", autor = "Nombre 205 Apellido 205" };
            var result = controller.Post(autor) as BadRequestObjectResult;
            //Assert
            //Se valida que no sea exitosos el proceso de adición
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
            var nReg = controller.GetAutores().Count();
            Assert.AreNotEqual(7, controller.GetAutores().Count()); //No se logró adcionar el registro 6 + 1 = 7
        }


        [Test]
        public void ActualizarNombreAutorExistente()
        {
            //Arrange            
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            //Act
            
            var delta = new Delta<Autore>(typeof(Autore));
            delta.TrySetPropertyValue("nombre", "Nombre 205 Reemplazado");
            var result = controller.PatchAutore(205, delta);

            var estado = (result as StatusCodeResult); //Assert 201

            var contexto2 = ConstruirContext(DbName);
            var existe = contexto2.Autores.Any(x => x.nombre == "Nombre 205 Reemplazado");
            //Assert
            Assert.IsTrue(existe);
        }

        [Test]
        public void BorrarAutorNoExistente()
        {
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            var result = controller.DeleteAutore(0);
            //Se valida que no sea exitoso el proceso de borrado y cantidades NO congruentres
            Assert.IsInstanceOf(typeof(BadRequestResult), result);
            var nReg = controller.GetAutores().Count();
            Assert.AreNotEqual(5,nReg); //No se logró adcionar el registro 6 - 1 = 5, no son iguales
        }


        [Test]
        public void BorrarAutorExistente()
        {
            dbTravelLIBContext dbcontext = ConstruirContext(DbName);
            AutoresController controller = new(dbcontext);
            var result = controller.DeleteAutore(205);
            //Se valida que sea exitoso el proceso de borrado y cantidades congruentres
            Assert.IsInstanceOf(typeof(NoContentResult), result); //DeleteAutore devuelve return new NoContentResult();
            var nReg = controller.GetAutores().Count();
            Assert.AreEqual(5, nReg); //Se logró Borrar el registro 6 - 1 = 5, son iguales
        }

    }
}

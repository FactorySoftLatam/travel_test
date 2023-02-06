using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TravelLibrary.Server.Controllers.dbTravelLIB
{
    [Route("odata/dbTravelLIB/AutoresHasLibros")]
    public partial class AutoresHasLibrosController : ODataController
    {
        private TravelLibrary.Server.Data.dbTravelLIBContext context;

        public AutoresHasLibrosController(TravelLibrary.Server.Data.dbTravelLIBContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> GetAutoresHasLibros()
        {
            var items = this.context.AutoresHasLibros.AsQueryable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>();
            this.OnAutoresHasLibrosRead(ref items);

            return items;
        }

        partial void OnAutoresHasLibrosRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> items);

        partial void OnAutoresHasLibroGet(ref SingleResult<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/dbTravelLIB/AutoresHasLibros(autores_id={keyautores_id},libros_ISBN={keylibros_ISBN})")]
        public SingleResult<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> GetAutoresHasLibro([FromODataUri] int keyautores_id, [FromODataUri] int keylibros_ISBN)
        {
            var items = this.context.AutoresHasLibros.Where(i => i.autores_id == keyautores_id && i.libros_ISBN == keylibros_ISBN);
            var result = SingleResult.Create(items);

            OnAutoresHasLibroGet(ref result);

            return result;
        }
        partial void OnAutoresHasLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        [HttpDelete("/odata/dbTravelLIB/AutoresHasLibros(autores_id={keyautores_id},libros_ISBN={keylibros_ISBN})")]
        public IActionResult DeleteAutoresHasLibro([FromODataUri] int keyautores_id, [FromODataUri] int keylibros_ISBN)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AutoresHasLibros
                    .Where(i => i.autores_id == keyautores_id && i.libros_ISBN == keylibros_ISBN)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAutoresHasLibroDeleted(item);
                this.context.AutoresHasLibros.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAutoresHasLibroDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAutoresHasLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        [HttpPut("/odata/dbTravelLIB/AutoresHasLibros(autores_id={keyautores_id},libros_ISBN={keylibros_ISBN})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAutoresHasLibro([FromODataUri] int keyautores_id, [FromODataUri] int keylibros_ISBN, [FromBody]TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.autores_id != keyautores_id && item.libros_ISBN != keylibros_ISBN))
                {
                    return BadRequest();
                }
                this.OnAutoresHasLibroUpdated(item);
                this.context.AutoresHasLibros.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AutoresHasLibros.Where(i => i.autores_id == keyautores_id && i.libros_ISBN == keylibros_ISBN);
                Request.QueryString = Request.QueryString.Add("$expand", "Autore,Libro");
                this.OnAfterAutoresHasLibroUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/dbTravelLIB/AutoresHasLibros(autores_id={keyautores_id},libros_ISBN={keylibros_ISBN})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAutoresHasLibro([FromODataUri] int keyautores_id, [FromODataUri] int keylibros_ISBN, [FromBody]Delta<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AutoresHasLibros.Where(i => i.autores_id == keyautores_id && i.libros_ISBN == keylibros_ISBN).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAutoresHasLibroUpdated(item);
                this.context.AutoresHasLibros.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AutoresHasLibros.Where(i => i.autores_id == keyautores_id && i.libros_ISBN == keylibros_ISBN);
                Request.QueryString = Request.QueryString.Add("$expand", "Autore,Libro");
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAutoresHasLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnAutoresHasLibroCreated(item);
                this.context.AutoresHasLibros.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AutoresHasLibros.Where(i => i.autores_id == item.autores_id && i.libros_ISBN == item.libros_ISBN);

                Request.QueryString = Request.QueryString.Add("$expand", "Autore,Libro");

                this.OnAfterAutoresHasLibroCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}

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
    [Route("odata/dbTravelLIB/Libros")]
    public partial class LibrosController : ODataController
    {
        private TravelLibrary.Server.Data.dbTravelLIBContext context;

        public LibrosController(TravelLibrary.Server.Data.dbTravelLIBContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.Libro> GetLibros()
        {
            var items = this.context.Libros.AsQueryable<TravelLibrary.Server.Models.dbTravelLIB.Libro>();
            this.OnLibrosRead(ref items);

            return items;
        }

        partial void OnLibrosRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Libro> items);

        partial void OnLibroGet(ref SingleResult<TravelLibrary.Server.Models.dbTravelLIB.Libro> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/dbTravelLIB/Libros(ISBN={ISBN})")]
        public SingleResult<TravelLibrary.Server.Models.dbTravelLIB.Libro> GetLibro(int key)
        {
            var items = this.context.Libros.Where(i => i.ISBN == key);
            var result = SingleResult.Create(items);

            OnLibroGet(ref result);

            return result;
        }
        partial void OnLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        [HttpDelete("/odata/dbTravelLIB/Libros(ISBN={ISBN})")]
        public IActionResult DeleteLibro(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Libros
                    .Where(i => i.ISBN == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnLibroDeleted(item);
                this.context.Libros.Remove(item);
                this.context.SaveChanges();
                this.OnAfterLibroDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        [HttpPut("/odata/dbTravelLIB/Libros(ISBN={ISBN})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutLibro(int key, [FromBody]TravelLibrary.Server.Models.dbTravelLIB.Libro item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.ISBN != key))
                {
                    return BadRequest();
                }
                this.OnLibroUpdated(item);
                this.context.Libros.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Libros.Where(i => i.ISBN == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Editoriale");
                this.OnAfterLibroUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/dbTravelLIB/Libros(ISBN={ISBN})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchLibro(int key, [FromBody]Delta<TravelLibrary.Server.Models.dbTravelLIB.Libro> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Libros.Where(i => i.ISBN == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnLibroUpdated(item);
                this.context.Libros.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Libros.Where(i => i.ISBN == key);
                Request.QueryString = Request.QueryString.Add("$expand", "Editoriale");
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TravelLibrary.Server.Models.dbTravelLIB.Libro item)
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

                int nReg = context.Libros.Count();
                int maxValue = 0;
                if (nReg > 0)
                {
                    maxValue = context.Libros.Max(x => x.ISBN) + 1;
                }
                else
                {
                    maxValue = 1;
                }


                this.OnLibroCreated(item);
                item.ISBN= maxValue;
                this.context.Libros.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Libros.Where(i => i.ISBN == item.ISBN);

                Request.QueryString = Request.QueryString.Add("$expand", "Editoriale");

                this.OnAfterLibroCreated(item);

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

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
    [Route("odata/dbTravelLIB/Autores")]
    public partial class AutoresController : ODataController
    {
        private Data.dbTravelLIBContext context;

        public AutoresController(Data.dbTravelLIBContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<Models.dbTravelLIB.Autore> GetAutores()
        {
            var items = this.context.Autores.AsQueryable<Models.dbTravelLIB.Autore>();
            this.OnAutoresRead(ref items);

            return items;
        }

        partial void OnAutoresRead(ref IQueryable<Models.dbTravelLIB.Autore> items);

        partial void OnAutoreGet(ref SingleResult<Models.dbTravelLIB.Autore> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/dbTravelLIB/Autores(id={id})")]
        public SingleResult<Models.dbTravelLIB.Autore> GetAutore(int key)
        {
            var items = this.context.Autores.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            OnAutoreGet(ref result);

            return result;
        }
        partial void OnAutoreDeleted(Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreDeleted(Models.dbTravelLIB.Autore item);

        [HttpDelete("/odata/dbTravelLIB/Autores(id={id})")]
        public IActionResult DeleteAutore(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Autores
                    .Where(i => i.id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAutoreDeleted(item);
                this.context.Autores.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAutoreDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAutoreUpdated(Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreUpdated(Models.dbTravelLIB.Autore item);

        [HttpPut("/odata/dbTravelLIB/Autores(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAutore(int key, [FromBody]Models.dbTravelLIB.Autore item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.id != key))
                {
                    return BadRequest();
                }
                this.OnAutoreUpdated(item);
                this.context.Autores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Autores.Where(i => i.id == key);
                ;
                this.OnAfterAutoreUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/dbTravelLIB/Autores(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAutore(int key, [FromBody]Delta<Models.dbTravelLIB.Autore> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Autores.Where(i => i.id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAutoreUpdated(item);
                this.context.Autores.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Autores.Where(i => i.id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAutoreCreated(Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreCreated(Models.dbTravelLIB.Autore item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] Models.dbTravelLIB.Autore item)
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

                this.OnAutoreCreated(item);
                this.context.Autores.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Autores.Where(i => i.id == item.id);

                ;

                this.OnAfterAutoreCreated(item);

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

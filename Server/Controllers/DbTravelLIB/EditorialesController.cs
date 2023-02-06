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
    [Route("odata/dbTravelLIB/Editoriales")]
    public partial class EditorialesController : ODataController
    {
        private TravelLibrary.Server.Data.dbTravelLIBContext context;

        public EditorialesController(TravelLibrary.Server.Data.dbTravelLIBContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> GetEditoriales()
        {
            var items = this.context.Editoriales.AsQueryable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>();
            this.OnEditorialesRead(ref items);

            return items;
        }

        partial void OnEditorialesRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> items);

        partial void OnEditorialeGet(ref SingleResult<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/dbTravelLIB/Editoriales(id={id})")]
        public SingleResult<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> GetEditoriale(int key)
        {
            var items = this.context.Editoriales.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            OnEditorialeGet(ref result);

            return result;
        }
        partial void OnEditorialeDeleted(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeDeleted(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        [HttpDelete("/odata/dbTravelLIB/Editoriales(id={id})")]
        public IActionResult DeleteEditoriale(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Editoriales
                    .Where(i => i.id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnEditorialeDeleted(item);
                this.context.Editoriales.Remove(item);
                this.context.SaveChanges();
                this.OnAfterEditorialeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEditorialeUpdated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeUpdated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        [HttpPut("/odata/dbTravelLIB/Editoriales(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutEditoriale(int key, [FromBody]TravelLibrary.Server.Models.dbTravelLIB.Editoriale item)
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
                this.OnEditorialeUpdated(item);
                this.context.Editoriales.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Editoriales.Where(i => i.id == key);
                ;
                this.OnAfterEditorialeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/dbTravelLIB/Editoriales(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchEditoriale(int key, [FromBody]Delta<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Editoriales.Where(i => i.id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnEditorialeUpdated(item);
                this.context.Editoriales.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Editoriales.Where(i => i.id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnEditorialeCreated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeCreated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] TravelLibrary.Server.Models.dbTravelLIB.Editoriale item)
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

                int nReg = context.Editoriales.Count();
                int maxValue = 0;
                if (nReg > 0)
                {
                    maxValue = context.Editoriales.Max(x => x.id) + 1;
                }
                else
                {
                    maxValue = 1;
                }


                this.OnEditorialeCreated(item);
                item.id = maxValue;
                this.context.Editoriales.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Editoriales.Where(i => i.id == item.id);

                ;

                this.OnAfterEditorialeCreated(item);

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

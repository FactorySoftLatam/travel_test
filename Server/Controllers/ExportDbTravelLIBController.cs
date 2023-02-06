using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TravelLibrary.Server.Data;

namespace TravelLibrary.Server.Controllers
{
    public partial class ExportdbTravelLIBController : ExportController
    {
        private readonly dbTravelLIBContext context;
        private readonly dbTravelLIBService service;

        public ExportdbTravelLIBController(dbTravelLIBContext context, dbTravelLIBService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/dbTravelLIB/autores/csv")]
        [HttpGet("/export/dbTravelLIB/autores/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoresToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutores(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/autores/excel")]
        [HttpGet("/export/dbTravelLIB/autores/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoresToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutores(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/autoreshaslibros/csv")]
        [HttpGet("/export/dbTravelLIB/autoreshaslibros/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoresHasLibrosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoresHasLibros(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/autoreshaslibros/excel")]
        [HttpGet("/export/dbTravelLIB/autoreshaslibros/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoresHasLibrosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoresHasLibros(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/editoriales/csv")]
        [HttpGet("/export/dbTravelLIB/editoriales/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEditorialesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEditoriales(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/editoriales/excel")]
        [HttpGet("/export/dbTravelLIB/editoriales/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEditorialesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEditoriales(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/libros/csv")]
        [HttpGet("/export/dbTravelLIB/libros/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLibrosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLibros(), Request.Query), fileName);
        }

        [HttpGet("/export/dbTravelLIB/libros/excel")]
        [HttpGet("/export/dbTravelLIB/libros/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLibrosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLibros(), Request.Query), fileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace TravelLibrary.Client.Pages
{
    public partial class AutoresHasLibros
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        public dbTravelLIBService dbTravelLIBService { get; set; }

        protected IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> autoresHasLibros;

        protected RadzenDataGrid<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> grid0;
        protected int count;

        protected string search = "";

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            await grid0.Reload();
        }

        protected async Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var result = await dbTravelLIBService.GetAutoresHasLibros(filter: $"{args.Filter}", expand: "Autore,Libro", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                autoresHasLibros = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Inhabilitado para cargar Libros por Autor" });
            }
        }    

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddAutoresHasLibro>("Adicionar Libro Autor", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> args)
        {
            await DialogService.OpenAsync<EditAutoresHasLibro>("Modificar Libro Autor", new Dictionary<string, object> { {"autores_id", args.Data.autores_id}, {"libros_ISBN", args.Data.libros_ISBN} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoresHasLibro)
        {
            try
            {
                if (await DialogService.Confirm("¿Esta seguro de elmininar este Registro?") == true)
                {
                    var deleteResult = await dbTravelLIBService.DeleteAutoresHasLibro(autoresId:autoresHasLibro.autores_id, librosIsbn:autoresHasLibro.libros_ISBN);

                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                { 
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error", 
                    Detail = $"Inahbilitado para borrar este registro" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await dbTravelLIBService.ExportAutoresHasLibrosToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Autore,Libro", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "AutoresHasLibros");
            }

            if (args == null || args.Value == "xlsx")
            {
                await dbTravelLIBService.ExportAutoresHasLibrosToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Autore,Libro", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "AutoresHasLibros");
            }
        }
    }
}
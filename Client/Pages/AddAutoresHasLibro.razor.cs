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
    public partial class AddAutoresHasLibro
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

        protected override async Task OnInitializedAsync()
        {
            autoresHasLibro = new TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro();
        }
        protected bool errorVisible;
        protected TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoresHasLibro;

        protected IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.Autore> autoresForautoresId;

        protected IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.Libro> librosForlibrosISBN;


        protected int autoresForautoresIdCount;
        protected TravelLibrary.Server.Models.dbTravelLIB.Autore autoresForautoresIdValue;
        protected async Task autoresForautoresIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await dbTravelLIBService.GetAutores(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                autoresForautoresId = result.Value.AsODataEnumerable();
                autoresForautoresIdCount = result.Count;

                if (!object.Equals(autoresHasLibro.autores_id, null))
                {
                    var valueResult = await dbTravelLIBService.GetAutores(filter: $"id eq {autoresHasLibro.autores_id}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        autoresForautoresIdValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"No se puede cargar Radzen.Design.EntityProperty" });
            }
        }

        protected int librosForlibrosISBNCount;
        protected TravelLibrary.Server.Models.dbTravelLIB.Libro librosForlibrosISBNValue;

        [Inject]
        protected SecurityService Security { get; set; }
        protected async Task librosForlibrosISBNLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await dbTravelLIBService.GetLibros(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                librosForlibrosISBN = result.Value.AsODataEnumerable();
                librosForlibrosISBNCount = result.Count;

                if (!object.Equals(autoresHasLibro.libros_ISBN, null))
                {
                    var valueResult = await dbTravelLIBService.GetLibros(filter: $"ISBN eq {autoresHasLibro.libros_ISBN}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        librosForlibrosISBNValue = firstItem;
                    }
                }

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Radzen.Design.EntityProperty" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                await dbTravelLIBService.CreateAutoresHasLibro(autoresHasLibro);
                DialogService.Close(autoresHasLibro);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
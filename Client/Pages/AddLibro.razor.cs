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
    public partial class AddLibro
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
            libro = new TravelLibrary.Server.Models.dbTravelLIB.Libro();
        }
        protected bool errorVisible;
        protected TravelLibrary.Server.Models.dbTravelLIB.Libro libro;

        protected IEnumerable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> editorialesForeditorialesId;


        protected int editorialesForeditorialesIdCount;
        protected TravelLibrary.Server.Models.dbTravelLIB.Editoriale editorialesForeditorialesIdValue;

        [Inject]
        protected SecurityService Security { get; set; }
        protected async Task editorialesForeditorialesIdLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await dbTravelLIBService.GetEditoriales(filter: $"{args.Filter}", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                editorialesForeditorialesId = result.Value.AsODataEnumerable();
                editorialesForeditorialesIdCount = result.Count;

                if (!object.Equals(libro.editoriales_id, null))
                {
                    var valueResult = await dbTravelLIBService.GetEditoriales(filter: $"id eq {libro.editoriales_id}");
                    var firstItem = valueResult.Value.FirstOrDefault();
                    if (firstItem != null)
                    {
                        editorialesForeditorialesIdValue = firstItem;
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
                await dbTravelLIBService.CreateLibro(libro);
                DialogService.Close(libro);
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
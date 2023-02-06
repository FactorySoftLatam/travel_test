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
    public partial class AddEditoriale
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
            editoriale = new TravelLibrary.Server.Models.dbTravelLIB.Editoriale();
        }
        protected bool errorVisible;
        protected TravelLibrary.Server.Models.dbTravelLIB.Editoriale editoriale;

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task FormSubmit()
        {
            try
            {
                await dbTravelLIBService.CreateEditoriale(editoriale);
                DialogService.Close(editoriale);
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
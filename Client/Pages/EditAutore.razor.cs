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
    public partial class EditAutore
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

        [Parameter]
        public int id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            autore = await dbTravelLIBService.GetAutoreById(id:id);
        }
        protected bool errorVisible;
        protected TravelLibrary.Server.Models.dbTravelLIB.Autore autore;

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task FormSubmit()
        {
            try
            {
                await dbTravelLIBService.UpdateAutore(id:id, autore);
                DialogService.Close(autore);
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
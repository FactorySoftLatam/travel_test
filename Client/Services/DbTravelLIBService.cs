
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace TravelLibrary.Client
{
    public partial class dbTravelLIBService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public dbTravelLIBService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/dbTravelLIB/");
        }


        public async System.Threading.Tasks.Task ExportAutoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAutoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetAutores(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Autore>> GetAutores(Query query)
        {
            return await GetAutores(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Autore>> GetAutores(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Autores");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAutores(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Autore>>(response);
        }

        partial void OnCreateAutore(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> CreateAutore(TravelLibrary.Server.Models.dbTravelLIB.Autore autore = default(TravelLibrary.Server.Models.dbTravelLIB.Autore))
        {
            var uri = new Uri(baseUri, $"Autores");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(autore), Encoding.UTF8, "application/json");

            OnCreateAutore(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Autore>(response);
        }

        partial void OnDeleteAutore(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteAutore(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Autores({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAutore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetAutoreById(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> GetAutoreById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Autores({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAutoreById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Autore>(response);
        }

        partial void OnUpdateAutore(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateAutore(int id = default(int), TravelLibrary.Server.Models.dbTravelLIB.Autore autore = default(TravelLibrary.Server.Models.dbTravelLIB.Autore))
        {
            var uri = new Uri(baseUri, $"Autores({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(autore), Encoding.UTF8, "application/json");

            OnUpdateAutore(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportAutoresHasLibrosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autoreshaslibros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autoreshaslibros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAutoresHasLibrosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autoreshaslibros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autoreshaslibros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetAutoresHasLibros(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>> GetAutoresHasLibros(Query query)
        {
            return await GetAutoresHasLibros(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>> GetAutoresHasLibros(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AutoresHasLibros");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAutoresHasLibros(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>>(response);
        }

        partial void OnCreateAutoresHasLibro(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> CreateAutoresHasLibro(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoresHasLibro = default(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro))
        {
            var uri = new Uri(baseUri, $"AutoresHasLibros");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(autoresHasLibro), Encoding.UTF8, "application/json");

            OnCreateAutoresHasLibro(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>(response);
        }

        partial void OnDeleteAutoresHasLibro(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteAutoresHasLibro(int autoresId = default(int), int librosIsbn = default(int))
        {
            var uri = new Uri(baseUri, $"AutoresHasLibros(autores_id={autoresId},libros_ISBN={librosIsbn})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAutoresHasLibro(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetAutoresHasLibroByAutoresIdAndLibrosIsbn(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> GetAutoresHasLibroByAutoresIdAndLibrosIsbn(string expand = default(string), int autoresId = default(int), int librosIsbn = default(int))
        {
            var uri = new Uri(baseUri, $"AutoresHasLibros(autores_id={autoresId},libros_ISBN={librosIsbn})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAutoresHasLibroByAutoresIdAndLibrosIsbn(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>(response);
        }

        partial void OnUpdateAutoresHasLibro(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateAutoresHasLibro(int autoresId = default(int), int librosIsbn = default(int), TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoresHasLibro = default(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro))
        {
            var uri = new Uri(baseUri, $"AutoresHasLibros(autores_id={autoresId},libros_ISBN={librosIsbn})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(autoresHasLibro), Encoding.UTF8, "application/json");

            OnUpdateAutoresHasLibro(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportEditorialesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/editoriales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/editoriales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEditorialesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/editoriales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/editoriales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetEditoriales(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>> GetEditoriales(Query query)
        {
            return await GetEditoriales(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>> GetEditoriales(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Editoriales");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEditoriales(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>>(response);
        }

        partial void OnCreateEditoriale(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> CreateEditoriale(TravelLibrary.Server.Models.dbTravelLIB.Editoriale editoriale = default(TravelLibrary.Server.Models.dbTravelLIB.Editoriale))
        {
            var uri = new Uri(baseUri, $"Editoriales");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(editoriale), Encoding.UTF8, "application/json");

            OnCreateEditoriale(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>(response);
        }

        partial void OnDeleteEditoriale(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteEditoriale(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Editoriales({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEditoriale(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEditorialeById(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> GetEditorialeById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Editoriales({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEditorialeById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>(response);
        }

        partial void OnUpdateEditoriale(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateEditoriale(int id = default(int), TravelLibrary.Server.Models.dbTravelLIB.Editoriale editoriale = default(TravelLibrary.Server.Models.dbTravelLIB.Editoriale))
        {
            var uri = new Uri(baseUri, $"Editoriales({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(editoriale), Encoding.UTF8, "application/json");

            OnUpdateEditoriale(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportLibrosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/libros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/libros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLibrosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/libros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/libros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetLibros(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Libro>> GetLibros(Query query)
        {
            return await GetLibros(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Libro>> GetLibros(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Libros");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLibros(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TravelLibrary.Server.Models.dbTravelLIB.Libro>>(response);
        }

        partial void OnCreateLibro(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> CreateLibro(TravelLibrary.Server.Models.dbTravelLIB.Libro libro = default(TravelLibrary.Server.Models.dbTravelLIB.Libro))
        {
            var uri = new Uri(baseUri, $"Libros");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(libro), Encoding.UTF8, "application/json");

            OnCreateLibro(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Libro>(response);
        }

        partial void OnDeleteLibro(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteLibro(int isbn = default(int))
        {
            var uri = new Uri(baseUri, $"Libros({isbn})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLibro(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetLibroByIsbn(HttpRequestMessage requestMessage);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> GetLibroByIsbn(string expand = default(string), int isbn = default(int))
        {
            var uri = new Uri(baseUri, $"Libros({isbn})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLibroByIsbn(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TravelLibrary.Server.Models.dbTravelLIB.Libro>(response);
        }

        partial void OnUpdateLibro(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateLibro(int isbn = default(int), TravelLibrary.Server.Models.dbTravelLIB.Libro libro = default(TravelLibrary.Server.Models.dbTravelLIB.Libro))
        {
            var uri = new Uri(baseUri, $"Libros({isbn})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(libro), Encoding.UTF8, "application/json");

            OnUpdateLibro(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
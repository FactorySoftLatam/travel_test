using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using TravelLibrary.Server.Data;

namespace TravelLibrary.Server
{
    public partial class dbTravelLIBService
    {
        dbTravelLIBContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly dbTravelLIBContext context;
        private readonly NavigationManager navigationManager;

        public dbTravelLIBService(dbTravelLIBContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAutoresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoresRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Autore> items);

        public async Task<IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Autore>> GetAutores(Query query = null)
        {
            var items = Context.Autores.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoresRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoreGet(TravelLibrary.Server.Models.dbTravelLIB.Autore item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> GetAutoreById(int id)
        {
            var items = Context.Autores
                              .AsNoTracking()
                              .Where(i => i.id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoreGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoreCreated(TravelLibrary.Server.Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreCreated(TravelLibrary.Server.Models.dbTravelLIB.Autore item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> CreateAutore(TravelLibrary.Server.Models.dbTravelLIB.Autore autore)
        {
            OnAutoreCreated(autore);

            var existingItem = Context.Autores
                              .Where(i => i.id == autore.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Autores.Add(autore);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autore).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoreCreated(autore);

            return autore;
        }

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> CancelAutoreChanges(TravelLibrary.Server.Models.dbTravelLIB.Autore item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoreUpdated(TravelLibrary.Server.Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreUpdated(TravelLibrary.Server.Models.dbTravelLIB.Autore item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> UpdateAutore(int id, TravelLibrary.Server.Models.dbTravelLIB.Autore autore)
        {
            OnAutoreUpdated(autore);

            var itemToUpdate = Context.Autores
                              .Where(i => i.id == autore.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(autore);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoreUpdated(autore);

            return autore;
        }

        partial void OnAutoreDeleted(TravelLibrary.Server.Models.dbTravelLIB.Autore item);
        partial void OnAfterAutoreDeleted(TravelLibrary.Server.Models.dbTravelLIB.Autore item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Autore> DeleteAutore(int id)
        {
            var itemToDelete = Context.Autores
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoreDeleted(itemToDelete);


            Context.Autores.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoreDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoresHasLibrosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autoreshaslibros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autoreshaslibros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoresHasLibrosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/autoreshaslibros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/autoreshaslibros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoresHasLibrosRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> items);

        public async Task<IQueryable<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>> GetAutoresHasLibros(Query query = null)
        {
            var items = Context.AutoresHasLibros.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoresHasLibrosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoresHasLibroGet(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> GetAutoresHasLibroByAutoresIdAndLibrosIsbn(int autoresid, int librosisbn)
        {
            var items = Context.AutoresHasLibros
                              .AsNoTracking()
                              .Where(i => i.autores_id == autoresid && i.libros_ISBN == librosisbn);

                items = items.Include(i => i.Autore);
                items = items.Include(i => i.Libro);
  
            var itemToReturn = items.FirstOrDefault();

            OnAutoresHasLibroGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoresHasLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> CreateAutoresHasLibro(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoreshaslibro)
        {
            OnAutoresHasLibroCreated(autoreshaslibro);

            var existingItem = Context.AutoresHasLibros
                              .Where(i => i.autores_id == autoreshaslibro.autores_id && i.libros_ISBN == autoreshaslibro.libros_ISBN)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoresHasLibros.Add(autoreshaslibro);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autoreshaslibro).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoresHasLibroCreated(autoreshaslibro);

            return autoreshaslibro;
        }

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> CancelAutoresHasLibroChanges(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoresHasLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> UpdateAutoresHasLibro(int autoresid, int librosisbn, TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro autoreshaslibro)
        {
            OnAutoresHasLibroUpdated(autoreshaslibro);

            var itemToUpdate = Context.AutoresHasLibros
                              .Where(i => i.autores_id == autoreshaslibro.autores_id && i.libros_ISBN == autoreshaslibro.libros_ISBN)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(autoreshaslibro);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoresHasLibroUpdated(autoreshaslibro);

            return autoreshaslibro;
        }

        partial void OnAutoresHasLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);
        partial void OnAfterAutoresHasLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro> DeleteAutoresHasLibro(int autoresid, int librosisbn)
        {
            var itemToDelete = Context.AutoresHasLibros
                              .Where(i => i.autores_id == autoresid && i.libros_ISBN == librosisbn)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoresHasLibroDeleted(itemToDelete);


            Context.AutoresHasLibros.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoresHasLibroDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEditorialesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/editoriales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/editoriales/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEditorialesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/editoriales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/editoriales/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEditorialesRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> items);

        public async Task<IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>> GetEditoriales(Query query = null)
        {
            var items = Context.Editoriales.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEditorialesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEditorialeGet(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> GetEditorialeById(int id)
        {
            var items = Context.Editoriales
                              .AsNoTracking()
                              .Where(i => i.id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnEditorialeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEditorialeCreated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeCreated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> CreateEditoriale(TravelLibrary.Server.Models.dbTravelLIB.Editoriale editoriale)
        {
            OnEditorialeCreated(editoriale);

            var existingItem = Context.Editoriales
                              .Where(i => i.id == editoriale.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Editoriales.Add(editoriale);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(editoriale).State = EntityState.Detached;
                throw;
            }

            OnAfterEditorialeCreated(editoriale);

            return editoriale;
        }

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> CancelEditorialeChanges(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEditorialeUpdated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeUpdated(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> UpdateEditoriale(int id, TravelLibrary.Server.Models.dbTravelLIB.Editoriale editoriale)
        {
            OnEditorialeUpdated(editoriale);

            var itemToUpdate = Context.Editoriales
                              .Where(i => i.id == editoriale.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(editoriale);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEditorialeUpdated(editoriale);

            return editoriale;
        }

        partial void OnEditorialeDeleted(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);
        partial void OnAfterEditorialeDeleted(TravelLibrary.Server.Models.dbTravelLIB.Editoriale item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Editoriale> DeleteEditoriale(int id)
        {
            var itemToDelete = Context.Editoriales
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEditorialeDeleted(itemToDelete);


            Context.Editoriales.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEditorialeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLibrosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/libros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/libros/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLibrosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbtravellib/libros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbtravellib/libros/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLibrosRead(ref IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Libro> items);

        public async Task<IQueryable<TravelLibrary.Server.Models.dbTravelLIB.Libro>> GetLibros(Query query = null)
        {
            var items = Context.Libros.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLibrosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLibroGet(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> GetLibroByIsbn(int isbn)
        {
            var items = Context.Libros
                              .AsNoTracking()
                              .Where(i => i.ISBN == isbn);

                items = items.Include(i => i.Editoriale);
  
            var itemToReturn = items.FirstOrDefault();

            OnLibroGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroCreated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> CreateLibro(TravelLibrary.Server.Models.dbTravelLIB.Libro libro)
        {
            OnLibroCreated(libro);

            var existingItem = Context.Libros
                              .Where(i => i.ISBN == libro.ISBN)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Libros.Add(libro);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(libro).State = EntityState.Detached;
                throw;
            }

            OnAfterLibroCreated(libro);

            return libro;
        }

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> CancelLibroChanges(TravelLibrary.Server.Models.dbTravelLIB.Libro item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroUpdated(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> UpdateLibro(int isbn, TravelLibrary.Server.Models.dbTravelLIB.Libro libro)
        {
            OnLibroUpdated(libro);

            var itemToUpdate = Context.Libros
                              .Where(i => i.ISBN == libro.ISBN)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(libro);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLibroUpdated(libro);

            return libro;
        }

        partial void OnLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.Libro item);
        partial void OnAfterLibroDeleted(TravelLibrary.Server.Models.dbTravelLIB.Libro item);

        public async Task<TravelLibrary.Server.Models.dbTravelLIB.Libro> DeleteLibro(int isbn)
        {
            var itemToDelete = Context.Libros
                              .Where(i => i.ISBN == isbn)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLibroDeleted(itemToDelete);


            Context.Libros.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLibroDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}
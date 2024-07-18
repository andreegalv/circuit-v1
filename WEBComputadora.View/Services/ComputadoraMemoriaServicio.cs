using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Model.Utils.Html;
using WEBComputadora.Model.ViewModels.Computadoras;
using WEBComputadora.Model.ViewModels.ComputadorasMemorias;
using WEBComputadora.Model.ViewModels.Memorias;
using WEBComputadora.View.Services.Interfaces;
using WEBComputadora.View.Utils;
using WEBComputadora.View.Utils.Http;
using WEBComputadora.View.Utils.Loggers;

namespace WEBComputadora.View.Services
{
    public class ComputadoraMemoriaServicio : IComputadoraMemoriaServicio
    {
        private string applicationUrl = ApplicationBaseContext.GetSiteRootUrl();
        private string filterSessionName = "COMPUTADORAMEMORIA_CONTROLLER_GRIDFILTERS";

        public ComputadoraMemoriaVistaModelo GetIndex()
        {
            var model = new ComputadoraMemoriaVistaModelo();

            model.Title = "Memorias";
            model.FormTitle = "Memorias | WEB";
            model.PageSize = new PageSize(10);

            SetFilterSession(filterSessionName, model);

            return model;
        }
        public async Task<ComputadoraMemoriaGrillaVistaModelo> GetComputersAsync(string descripcion, int? capacidadIgual, int? capacidadMayorGb,
                                                        int? pageSize, bool? changePage, int? toPage)
        {
            SaveFilterValues(filterSessionName, descripcion, capacidadIgual, capacidadMayorGb);

            var modelo = new ComputadoraMemoriaGrillaVistaModelo();

            UriBuilder uriBuilderBaseUrl = new UriBuilder(applicationUrl + @"/api/obtener/computadoras");
            var query = HttpUtility.ParseQueryString(uriBuilderBaseUrl.Query);
            
            if (!string.IsNullOrEmpty(descripcion))
                query["descripcion"] = descripcion;
            if (capacidadIgual != null && capacidadIgual > 0)
                query["capacidadIgual"] = capacidadIgual.ToString();
            if (capacidadMayorGb != null && capacidadMayorGb > 0)
                query["capacidadMayorGb"] = capacidadMayorGb.ToString();

            uriBuilderBaseUrl.Query = query.ToString();

            var computers = await GetEntityFromApiAsync<IEnumerable<ComputadoraMemoria>>
                                    (uriBuilderBaseUrl.ToString()).ConfigureAwait(false);

            if (computers == null)
                return modelo;

            foreach (var computer in computers)
            {
                modelo.Datas.Add(new ComputadoraMemoriaGrillaLineaVistaModelo()
                {
                    ComputadoraId = computer.ComputadoraId,
                    ComputadoraMemoriaId = computer.ComputadoraMemoriaId,
                    MemoriaComputadoraId = computer.MemoriaComputadoraId,
                    Computadora = new ComputadoraVistaModelo()
                    {
                        ComputadoraId = computer.Computadora.ComputadoraId,
                        ComputadoraProcesadorId = computer.Computadora.ProcesadorComputadoraId,
                        Descripcion = computer.Computadora.Descripcion,
                    },
                    Memoria = new MemoriaVistaModelo()
                    {
                        MemoriaId = computer.Memoria.MemoriaId,
                        Descripcion = computer.Memoria.Descripcion,
                        Capacidad = computer.Memoria.Capacidad,
                        Frecuencia = computer.Memoria.Frecuencia,
                        Tipo = computer.Memoria.Tipo,
                        CapacidadGigaBytes = ConvertTypeMemory.ConvertMegaToGiga(computer.Memoria.Capacidad)
                    }
                });
            }

            modelo.TotalRecords = modelo.Datas.Count();

            if (pageSize != null)
            {
                modelo.AddPaginator(new Paginator(modelo.TotalRecords, (int)pageSize));

                if (changePage != null && (bool)changePage && toPage != null)
                    modelo.Paginator.SetCurrentPage((int)toPage);

                if (modelo.Paginator.Skip > 0)
                    modelo.Datas = modelo.Datas.Skip(modelo.Paginator.Skip).ToList();

                modelo.Datas = modelo.Datas.Take(modelo.Paginator.Take).ToList();
            }

            return modelo;
        }
        public async Task<ComputadoraMemoriaDisplayViewModel> GetComputerByIdAsync(int? computadoraId, int? computadoraMemoriaId)
        {
            if (computadoraId == null || computadoraMemoriaId == null)
                return null;

            var modelo = new ComputadoraMemoriaDisplayViewModel();

            UriBuilder uriBuilderBaseUrl = new UriBuilder(applicationUrl + "/api/obtener/computadora");
            var query = HttpUtility.ParseQueryString(uriBuilderBaseUrl.Query);

            query["computadoraId"] = computadoraId.ToString();
            query["computadoraMemoriaId"] = computadoraMemoriaId.ToString();

            uriBuilderBaseUrl.Query = query.ToString();

            var computer = await GetEntityFromApiAsync<ComputadoraMemoria>(
                uriBuilderBaseUrl.ToString()).ConfigureAwait(false);

            if (computer != null)
            {
                modelo.ToAssociateModel(computer);
                return modelo;
            }

            return null;            
        }

        private async Task<TEntity> GetEntityFromApiAsync<TEntity>(string apiUrl)
        {
            TEntity entity = default;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = new TimeSpan(0, 0, 10);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl,
                                                    HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        entity = await response.Content.ReadAsAsync<TEntity>().ConfigureAwait(false);
                    }
                }
                catch (ArgumentNullException e)
                {
                    ExceptionLogger.WriteLog($"({nameof(ArgumentNullException)}) {e.Message + Environment.NewLine + e.StackTrace}");
                }
                catch (UriFormatException e)
                {
                    ExceptionLogger.WriteLog($"({nameof(UriFormatException)}) {e.Message + Environment.NewLine + e.StackTrace}");
                }
                catch (HttpRequestException e)
                {
                    ExceptionLogger.WriteLog($"({nameof(HttpRequestException)}) {e.Message + Environment.NewLine + e.StackTrace}");
                }

                return entity;
            }
        }
        private void SaveFilterValues(string sessionName, string descripcion, int? capacidadIgual, int? capacidadMayorGb)
        {
            FilterValuesSession filters = new FilterValuesSession();

            filters.AddFilter("descripcion", descripcion);
            filters.AddFilter("capacidadIgual", capacidadIgual);
            filters.AddFilter("capacidadMayorGb", capacidadMayorGb);

            ApplicationBaseContext.SaveSession(sessionName, filters);
        }
        private void SetFilterSession(string sessionName, ComputadoraMemoriaVistaModelo model)
        {
            var filters = (FilterValuesSession)ApplicationBaseContext.GetSession(sessionName);
            if (filters != null)
            {
                foreach (var filter in filters.FilterValues)
                {
                    switch (filter.KeyName)
                    {
                        case "descripcion":
                            model.DescripcionFilter = filter.Value.ToString();
                            break;
                        case "capacidadIgual":
                            model.CapacidadIgualFilter = (filter.Value != null) ? (int)filter.Value : 0;
                            break;
                        case "capacidadMayorGb":
                            model.CapacidadMayorAFilter = (filter.Value != null) ? (int)filter.Value : 0;
                            break;
                    }
                }
            }
        }
    }
}
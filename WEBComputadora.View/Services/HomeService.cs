using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.Model.ViewModels.Home;
using WEBComputadora.Model.Utils.Messages;
using WEBComputadora.View.Services.Interfaces;
using WEBComputadora.View.Utils;

namespace WEBComputadora.View.Services
{
    public class HomeService : IHomeService
    {
        private readonly string programName = "HOME_SERVICE";

        public HomeIndexViewModel GetIndexModel()
        {
            var model = new HomeIndexViewModel();

            using (var context = new WebDbContext())
            {
                var databasesList = new List<HomeIndexDatabaseInfoViewModel>
                {
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "Marcas",
                        Order = 1,
                        TableTotalRecords = context.Marcas.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "Memorias",
                        Order = 2,
                        TableTotalRecords = context.Memorias.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "Discos duros",
                        Order = 3,
                        TableTotalRecords = context.DiscosDuros.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "Procesadores",
                        Order = 4,
                        TableTotalRecords = context.Procesadores.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "Computadoras",
                        Order = 5,
                        TableTotalRecords = context.Computadoras.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "C. Memorias",
                        IsSubLevel = true,
                        Order = 6,
                        TableNameParent = "Computadoras",
                        TableTotalRecords = context.ComputadorasMemorias.Count
                    },
                    new HomeIndexDatabaseInfoViewModel
                    {
                        TableName = "C. Discos duros",
                        IsSubLevel = true,
                        Order = 7,
                        TableNameParent = "Computadoras",
                        TableTotalRecords = context.ComputadorasDiscosDuros.Count
                    }
                };
                model.HomeDatabasesList.AddRange(databasesList);

                model.SeedNumber = context.GetSeedNumber();
                model.WaitTimeRequest = context.GetWaitTimeRequest();
                model.TotalRecordsSeed = context.GetTotalRecordsToCreate();
            }

            var menuList = new List<HomeIndexMenuInfoViewModel>
            {
                new HomeIndexMenuInfoViewModel
                {
                    Description = "Memorias",
                    ActionName = "Index",
                    RouteName = "ComputadoraMemoria"
                }
            };
            model.HomeMenusList.AddRange(menuList);

            object alertObject = ApplicationBaseContext.GetSession(programName, "MESSAGE");
            if (alertObject != null && alertObject is ApplicationMessage)
            {
                model.AddMessage((ApplicationMessage)alertObject);
                ApplicationBaseContext.RemoveSession(programName, "MESSAGE");
            }

            return model;
        }

        public void UpdateSeedFromContext()
        {
            var message = new ApplicationMessage();
            if (WebDbContext.RefreshSeed())
            {
                message.SetSuccessMessage("Se ha generado correctamente una nueva semilla");
            }
            else
            {
                message.SetErrorMessage("Se ha generado correctamente una nueva semilla");
            }
            ApplicationBaseContext.SaveSession(programName, "MESSAGE", message);
        }
        public bool SetConfiguration(int? waitTimeRequest, int? totalRecordsCreate)
        {
            bool isChange = false;

            if (waitTimeRequest != null && waitTimeRequest >= 0 && waitTimeRequest <= 10000)
            {
                isChange = true;
                WebDbContext.WaitTimeRequest = (int)waitTimeRequest;
            }
            if (totalRecordsCreate != null && totalRecordsCreate >= 0 && totalRecordsCreate < 100)
            {
                isChange = true;
                WebDbContext.SetRecordsToCreate((int)totalRecordsCreate);
            }

            return isChange;
        }
    }
}
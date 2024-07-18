using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBComputadora.Model.Utils.Messages;

namespace WEBComputadora.Model.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            HomeDatabasesList = new List<HomeIndexDatabaseInfoViewModel>();
            HomeMenusList = new List<HomeIndexMenuInfoViewModel>();
            Messages = new List<ApplicationMessage>();
        }

        public int TotalDatabaseRecords => HomeDatabasesList.Sum(d => d.TableTotalRecords);
        public int SeedNumber { get; set; }
        public bool HasMessages => (Messages.Count > 0) ? true : false;

        [MinLength(0), MaxLength(30)]
        public int TotalRecordsSeed { get; set; }
        [MinLength(0), MaxLength(10000)]
        public int WaitTimeRequest { get; set; }

        public List<ApplicationMessage> Messages { get; set; }
        public List<HomeIndexDatabaseInfoViewModel> HomeDatabasesList { get; set; }
        public List<HomeIndexMenuInfoViewModel> HomeMenusList { get; set; }

        public void AddMessage(ApplicationMessage message)
        {
            if (message == null)
                throw new ArgumentNullException();

            Messages.Add(message);
        }
    }
    public class HomeIndexDatabaseInfoViewModel
    {
        public string TableName { get; set; }
        public int Order { get; set; }
        public bool IsSubLevel { get; set; }
        public string TableNameParent { get; set; }
        public int TableTotalRecords { get; set; }
    }
    public class HomeIndexMenuInfoViewModel
    {
        public string Description { get; set; }
        public string ActionName { get; set; }
        public string RouteName { get; set; }
        public object Parameters { get; set; }
        public bool HasParameters => (Parameters != null) ? true : false;
    }
}
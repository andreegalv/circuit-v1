using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBComputadora.Model.ViewModels.Home;

namespace WEBComputadora.View.Services.Interfaces
{
    public interface IHomeService
    {
        HomeIndexViewModel GetIndexModel();

        void UpdateSeedFromContext();
        bool SetConfiguration(int? waitTimeRequest, int? totalRecordsCreate);
    }
}

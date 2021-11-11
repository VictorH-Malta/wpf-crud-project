using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfLightProject.Models;

namespace WpfLightProject.DataAccess
{
    public interface ICompanyDataContext
    {
        ICompany Company { get; set; }
        List<ICompany> CompaniesList { get; set; }
        ICompany Insert(ICompany company);
        ICompany Delete(ICompany company);
        ICompany Update(ICompany company);
        List<ICompany> Select();
    }
}

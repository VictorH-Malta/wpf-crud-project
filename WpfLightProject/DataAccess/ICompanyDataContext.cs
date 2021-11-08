using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfLightProject.Models;

namespace WpfLightProject.DataAccess
{
    public interface ICompanyDataContext
    {
        ICompany Company { get; set; }
        List<ICompany> CompaniesList { get; set; }
        void Insert(ICompany company);
        void Delete(ICompany company);
        void Update(ICompany company);
        List<ICompany> Select();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLightProject.Models.Enums;

namespace WpfLightProject.Models.Validations
{
    public interface IValidateCompany : IValidateEntity
    {
        bool ValidateBusinessBranch(BusinessBranch business);
        bool ValidateCompanySize(CompanySize companySize);
        bool ValidateStatus(Status status);

        bool IsCompanyValid(ICompany company);
    }
}

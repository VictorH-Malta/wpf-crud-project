using WpfLightProject.Models.Enums;

namespace WpfLightProject.Models
{
    public interface ICompany : IEntity
    {
        BusinessBranch Business { get; set; }
        CompanySize CompanySize { get; set; }
        Status Status { get; set; }
    }
}

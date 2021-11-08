using System;

namespace WpfLightProject.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        string RegisterNumber { get; set; }
        string Address { get; set; }
        DateTime BirthDate { get; set; }
    }
}

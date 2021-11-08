using System;

namespace WpfLightProject.Models.Validations
{
    public interface IValidateEntity
    {
        bool IsIdValid { get; set; }
        bool IsNameValid { get; set; }
        bool IsRegisterNumberValid { get; set; }
        bool IsAddressValid { get; set; }
        bool IsBirthDateValid { get; set; }

        bool ValidateId(int id);
        bool ValidateName(string name);
        bool ValidateRegisterNumber(string number);
        bool ValidateAdress(string address);
        bool ValidateBirthDate(DateTime date);
    }
}

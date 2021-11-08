using System;
using System.Linq;
using WpfLightProject.Models.Enums;

namespace WpfLightProject.Models.Validations
{
    public class ValidateCompany : IValidateCompany
    {
        public bool IsIdValid { get; set; }
        public bool IsNameValid { get; set; }
        public bool IsRegisterNumberValid { get; set; }
        public bool IsAddressValid { get; set; }
        public bool IsBirthDateValid { get; set; }

        public ValidateCompany()
        {
            IsAddressValid = true;
            IsNameValid = true;
            IsRegisterNumberValid = true;
            IsAddressValid = true;
            IsBirthDateValid = true;
        }

        public bool IsCompanyValid(ICompany company)
        {
            return ValidateId(company.Id) && ValidateName(company.Name) && ValidateRegisterNumber(company.RegisterNumber) && ValidateAdress(company.Address) && ValidateBirthDate(company.BirthDate) && ValidateBusinessBranch(company.Business) && ValidateCompanySize(company.CompanySize) && ValidateStatus(company.Status);
        }

        public bool ValidateAdress(string address)
        {
            if (address.Length > 150)
                return IsAddressValid = false;

            if (String.IsNullOrWhiteSpace(address))
                return IsAddressValid = false;

            return IsAddressValid;
        }

        public bool ValidateBirthDate(DateTime date)
        {
            if (date >= DateTime.Now)
                return IsBirthDateValid = false;

            return IsBirthDateValid;
        }

        public bool ValidateBusinessBranch(BusinessBranch business)
        {
            return true;
        }

        public bool ValidateCompanySize(CompanySize companySize)
        {
            return true;
        }

        public bool ValidateId(int id)
        {
            if (id < 0)
                return IsIdValid = false;

            if (id > Int32.MaxValue)
                return IsIdValid = false;

            return IsIdValid;
        }

        public bool ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return IsNameValid = false;

            if (name.Length >= 50)
                return IsNameValid  = false;

            return IsNameValid;
        }

        public bool ValidateRegisterNumber(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return IsRegisterNumberValid = false;


            if (number.Length != 14)
                return IsRegisterNumberValid = false;

            int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string inicialNumber = "";
            int sum = 0;
            int mod1 = 0;
            string digit = "";

            number = number.Trim();
            number = number.Replace(".", "").Replace("-", "").Replace("/", "");


            inicialNumber = number.Substring(0, 12);

            for (int i = 0; i < 12; i++)
            {
                char[] array = inicialNumber.ToArray();
                sum += array[i] * mult1[i];
            }

            ModCalculate(mod1, sum);

            digit = mod1.ToString();
            inicialNumber += digit;

            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                char[] array = inicialNumber.ToArray();
                sum += array[i] * mult2[i];
            }

            ModCalculate(mod1, sum);

            digit += mod1.ToString();

            return number.EndsWith(digit);
        }

        public bool ValidateStatus(Status status)
        {
            return true;
        }

        private int ModCalculate(int number, int sum)
        {
            number = sum % 11;
            if (number < 2)
                number = 0;
            else
                number = 11 - number;

            return number;
        }
    }
}

using System;
using WpfLightProject.Models.Enums;
using WpfLightProject.ViewModels;

namespace WpfLightProject.Models
{
    public class Company : ViewModelBase, ICompany
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _cnpj;

        public string RegisterNumber
        {
            get { return _cnpj; }
            set
            {
                _cnpj = value;
                OnPropertyChanged("RegisterNumber");
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private DateTime dateTime;

        public DateTime BirthDate
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private BusinessBranch _business;

        public BusinessBranch Business
        {
            get { return _business; }
            set 
            { 
                _business = value;
                OnPropertyChanged("Business");
            }
        }

        private CompanySize _companySize;

        public CompanySize CompanySize
        {
            get { return _companySize; }
            set 
            { 
                _companySize = value;
                OnPropertyChanged("CompanySize");
            }
        }

        private Status _status;

        public Status Status
        {
            get { return _status; }
            set 
            { 
                _status = value;
                OnPropertyChanged("Status");
            }
        }



        public Company()
        {

        }
    }
}

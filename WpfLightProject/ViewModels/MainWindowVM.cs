using System.Linq;
using WpfLightProject.Models;
using WpfLightProject.Views;
using System.Windows.Input;
using WpfLightProject.DataAccess;
using System.Collections.ObjectModel;
using System;
using System.Windows;

namespace WpfLightProject.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public ICompanyDataContext CompanyContext { get; private set; }
        public ObservableCollection<ICompany> CompanyList { get; set; }
        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;
                OnPropertyChanged("SelectedCompany");
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        public ICommand EditCommand { get; private set; }


        public MainWindowVM()
        { 
            RegisterCommand = new RelayCommand((param) => { Register(); });
            DeleteCommand = new RelayCommand((param) => { Delete(); });
            EditCommand = new RelayCommand((param) => { Edit(); });

            CompanyContext = new NpgsqlCompanyContext();
            CompanyList = new ObservableCollection<ICompany>(CompanyContext.Select());
        }

        private void Register()
        {
            Company company = new Company();
            company.Status = Status.Active;
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.DataContext = company;
            registerWindow.ShowDialog();

            if (registerWindow.DialogResult.HasValue && registerWindow.DialogResult.Value)
            {
               CompanyContext.Insert(company);
               SelectedCompany = company;
            }
        }

        private void Delete()
        {
            if (SelectedCompany != null)
            {
                CompanyContext.Delete(SelectedCompany);
                CompanyList.Remove(SelectedCompany);
                SelectedCompany = (Company)CompanyList.FirstOrDefault();
            }
        }

        private void Edit()
        {
            
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.DataContext = SelectedCompany;
            registerWindow.ShowDialog();

            if (registerWindow.DialogResult.HasValue && registerWindow.DialogResult.Value)
            {
                CompanyContext.Update(SelectedCompany);
            }
        }
     }
}

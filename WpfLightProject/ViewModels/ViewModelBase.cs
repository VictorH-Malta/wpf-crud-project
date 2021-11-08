using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLightProject.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Notifica a mudança de uma propriedade e atualiza com o novo valor, caso seja Nulo
        protected void OnPropertyChanged(string property)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

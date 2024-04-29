using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multitaschenrechner.Utilities;
using System.Windows.Input;

namespace Multitaschenrechner.ViewModel
{
    class Navigation : ViewModelBase
    {
        private object _currentView;
        public object CurrentView { get { return _currentView; } set { _currentView = value; OnPropertyChanged(); } }

        public ICommand Page1Command { get; set; }
        public ICommand Page2Command { get; set; }

        private void Page1(object obj) => CurrentView = new Page1Vm();
        private void Page2(object obj) => CurrentView = new Page2Vm();

        public Navigation() 
        { 
            Page1Command = new RelayCommand(Page1);
            Page2Command = new RelayCommand(Page2);

            CurrentView = new Page1Vm();
        }

    }

    
}

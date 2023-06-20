using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SunClouds.ViewModel.Helpers
{
    public class PropertyChangedHelper : INotifyPropertyChanged
    {
        ////////////////////////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Notify(params string[] names)
        {
            foreach (var name in names)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

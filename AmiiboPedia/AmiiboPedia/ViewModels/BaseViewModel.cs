using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AmiiboPedia.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy; set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        #region Implementación
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}

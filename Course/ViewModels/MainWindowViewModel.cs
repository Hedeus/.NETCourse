using Course.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        private string _Title = "Курсовая работа по C#";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();
            //
            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }

        #endregion
    }
}

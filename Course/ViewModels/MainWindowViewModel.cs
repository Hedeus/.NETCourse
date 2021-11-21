using Course.Infrastructure.Commands.Base;
using Course.Models;
using Course.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

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

        #region Входние данные
        /// <summary>
        /// Свойства отвечающие за входные данные xmin, xmax, dx, a
        /// </summary>

        #region XMin

        private double _XMin = 0d;

        public double XMin
        {
            get => _XMin;
            set => Set(ref _XMin, value);
        }

        #endregion

        #region XMax

        private double _XMax = 0d;

        public double XMax
        {
            get => _XMax;
            set => Set(ref _XMax, value);
        }

        #endregion

        #region DX

        private double _DX = 0d;

        public double DX
        {
            get => _DX;
            set => Set(ref _DX, value);
        }

        #endregion

        #region A

        private double _A = 0d;

        public double A
        {
            get => _A;
            set => Set(ref _A, value);
        }

        #endregion

        #endregion

        #region Status : String - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status 
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------------------------------------*/

        #region Команды

        #region  CloseApplicationCommand
        //public ICommand CloseApplicationCommand { get; }

        //private bool CanCloseApplicationCommandExecute(object p) => true;

        //private void OnCloseApplicationCommandExecuted(object p)
        //{
        //    Application.Current.Shutdown();
        //}
        #endregion

        #endregion

        /* ---------------------------------------------------------------------------------------------------------------------------------------*/

        public MainWindowViewModel()
        {
            #region Команды

            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);



            #endregion



        }
    }
}

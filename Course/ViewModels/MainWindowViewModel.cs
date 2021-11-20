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
        #region TestDataPoints - IEnumerable<DataPoint> - Тестовый набор данных для визуализации графиков
        /// <summary>
        /// Тестовый набор данных для визуализации графиков
        /// </summary>
        private IEnumerable<DataPoint> _TestDataPoints;

        /// <summary>
        /// Тестовый набор данных для визуализации графиков
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints; set => Set(ref _TestDataPoints, value); }

        #endregion


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

        #region Команды

        #region  CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

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

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;
        }
    }
}

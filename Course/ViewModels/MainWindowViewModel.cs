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
        #region Свойства

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

        //#region F1CalcResults - Результаты расчетов по первой формуле.

        //private List<CalcResults> _F1CalcResults;

        //public List<CalcResults> F1CalcResults
        //{
        //    get => _F1CalcResults;
        //    set => Set(ref _F1CalcResults, value);
        //}

        //#endregion

        //#region F2CalcResults - Результаты расчетов по второй формуле.

        //private List<CalcResults> _F2CalcResults;

        //public List<CalcResults> F2CalcResults
        //{
        //    get => _F2CalcResults;
        //    set => Set(ref _F2CalcResults, value);
        //}

        //#endregion

        #region F1CalcResults - Результаты расчетов по первой формуле.

        //public object[] _F1CalcResults;

        public string[] F1CalcResults { get; set; }
        //{
        //    get => _F1CalcResults;
        //    set => Set(ref _F1CalcResults, value);
        //}

        #endregion

        #region F2CalcResults - Результаты расчетов по второй формуле.

        private List<CalcResults> _F2CalcResults;

        public List<CalcResults> F2CalcResults
        {
            get => _F2CalcResults;
            set => Set(ref _F2CalcResults, value);
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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------------------------------------*/

        #region Методы

        #region Необходимые расчеты

        #region CalculationF1 - Необходимые расчеты по первой формуле.        

        private string[] CalculationF1 (double XMin, double XMax, double DX, double A, double Q)
        {
            var Res_list = new List<string>();
            string TempRes;
            if (DX <= 0) { return Res_list.ToArray(); }
            for (double X = XMin; X <= XMax; X += DX)
            {
                if (A <= X)
                {
                    TempRes = "Неможливо взяти логарифм (a-x)<= 0, при a=" + A.ToString("0.000") + " та x=" + X.ToString("0.000");
                }
                else
                {
                    double Y = (Math.Log10(A - X)) / Q;
                    TempRes = "x= " + X.ToString("0.000") + ", q= " + Q.ToString("0.000") + ", y= " + Y.ToString("0.000");
                }
                Res_list.Add(TempRes);
            }

            return Res_list.ToArray();
        }

        #endregion

        #endregion

        #region Calculation - Вызов подходящей функции

        private void Calculation()
        {
            Random rnd = new Random();
            double Q = rnd.Next(1,7)/10d;
            if (Q <= 0.7)
            {
                F1CalcResults = CalculationF1(XMin, XMax, DX, A, Q);
                return;
            }
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

        #region  CalculateCommand
        public ICommand CalculateCommand { get; }

        private bool CanCalculateCommandExecute(object p) => true;

        private void OnCalculateCommandExecuted(object p)
        {
            Calculation();
        }
        #endregion

        #endregion

        /* ---------------------------------------------------------------------------------------------------------------------------------------*/

        public MainWindowViewModel()
        {
            #region Команды

            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            CalculateCommand = new LambdaCommand(OnCalculateCommandExecuted, CanCalculateCommandExecute);

            #endregion

            //var data_list = new List<string>();
            //data_list.Add("Hello");
            //data_list.Add("World!");
            //F1CalcResults = data_list.ToArray();



        }
    }
}

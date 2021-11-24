using Course.Infrastructure.Commands.Base;
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

        private double _XMin = 1d;

        public double XMin
        {
            get => _XMin;
            set => Set(ref _XMin, value);
        }

        #endregion

        #region XMax

        private double _XMax = 5d;

        public double XMax
        {
            get => _XMax;
            set => Set(ref _XMax, value);
        }

        #endregion

        #region DX

        private double _DX = 0.5;

        public double DX
        {
            get => _DX;
            set => Set(ref _DX, value);
        }

        #endregion

        #region A

        private double _A = 4d;

        public double A
        {
            get => _A;
            set => Set(ref _A, value);
        }

        #endregion

        #endregion

        #region Результаты
        /// <summary>
        /// Свойства отвечающие за входные данные xmin, xmax, dx, a
        /// </summary>

        #region F1CalcResults - Результаты расчетов по первой формуле.

        private string[] _F1CalcResults;
        public string[] F1CalcResults 
        { 
            get => _F1CalcResults;
            set => Set(ref _F1CalcResults, value); 
        }

        #endregion

        #region F2CalcResults - Результаты расчетов по второй формуле.

        private string[] _F2CalcResults;
        public string[] F2CalcResults
        {
            get => _F2CalcResults;
            set => Set(ref _F2CalcResults, value);
        }

        #endregion

        #region Количество расчетов по первой формуле

        private string _F1Count = "К-ть розрахунків f1(x) = 0";
        public string F1Count
        {
            get => _F1Count;
            set => Set(ref _F1Count, value);
        }

        #endregion

        #region Количество расчетов по второй формуле

        private string _F2Count = "К-ть розрахунків f2(x) = 0";
        public string F2Count
        {
            get => _F2Count;
            set => Set(ref _F2Count, value);
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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------------------------------------*/

        #region Методы

        #region Необходимые расчеты

        #region CalculationF1 - Необходимые расчеты по первой формуле.        

        //private string[] CalculationF1 (double XMin, double XMax, double DX, double A, double Q)
        //{
        //    var Res_list = new List<string>();
        //    string TempRes;
        //    if (DX <= 0) { return Res_list.ToArray(); }
        //    for (double X = XMin; X <= XMax; X += DX)
        //    {
        //        if (A <= X)
        //        {
        //            TempRes = "Неможливо взяти логарифм (a-x)<= 0, при a=" + A.ToString("0.000") + " та x=" + X.ToString("0.000");
        //        }
        //        else
        //        {
        //            double Y = (Math.Log10(A - X)) / Q;
        //            TempRes = "x= " + X.ToString("0.000") + ", q= " + Q.ToString("0.000") + ", y= " + Y.ToString("0.000");
        //        }
        //        Res_list.Add(TempRes);
        //    }

        //    return Res_list.ToArray();
        //}

        #endregion

        #endregion

        #region Calculation - Метод разрахунків
                
        private void Calculation()
        {
            Random rnd = new Random();
            var Res_list1 = new List<string>();
            var Res_list2 = new List<string>();
            string TempRes;            
            if (DX <= 0 ||  XMax < XMin)
            {
                TempRes = "DX має бути більше 0. XMin має бути менше XMax ";
                Res_list1.Add(TempRes);
                F1CalcResults = Res_list1.ToArray();                
                F2CalcResults = Res_list1.ToArray();
                return;
            }
            double Q;
            double Y;
            for (double X = XMin; X <= XMax; X += DX)
            {
                Q = rnd.Next(1, 10) / 10d;
                if (Q <= 0.7)
                {
                    if (A > X)
                    {
                        Y = (Math.Log10(A - X)) / Q;
                        TempRes = "x= " + X.ToString("0.000") + ", q= " + Q.ToString("0.000") + ", y= " + Y.ToString("0.000");                        
                    }
                    else
                    {
                        TempRes = "a <= x. Обчислення десятково логарифма числа меншого чи рівного нулю неможливе.";
                    }
                    Res_list1.Add(TempRes);
                }
                else
                {
                    Y = Math.Pow((Q*X), 1/3d);
                    TempRes = "x= " + X.ToString("0.000") + ", q= " + Q.ToString("0.000") + ", y= " + Y.ToString("0.000");
                    Res_list2.Add(TempRes);
                }
            }
            F1CalcResults = Res_list1.ToArray();
            F2CalcResults = Res_list2.ToArray();
            F1Count = "К - ть розрахунків f1(x) = " + F1CalcResults.Length.ToString();
            F2Count = "К - ть розрахунків f2(x) = " + F2CalcResults.Length.ToString();
            return;
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

        }
    }
}

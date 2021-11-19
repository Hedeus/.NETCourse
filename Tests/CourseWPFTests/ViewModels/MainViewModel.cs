using System.Collections.Generic;
using CourseWPFTests.ViewModels.Base;
using OxyPlot;

namespace CourseWPFTests.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region Заголовок окна
        private string _Title = "Test OxyPlot";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            
            set => Set(ref _Title, value);
        }

        #endregion

        #region Точки графика
        private List<DataPoint> _Points;

        /// <summary>Заголовок окна</summary>

        public List<DataPoint> Points
        {
            get => _Points;

            set => Set(ref _Points, value);
        }

        #endregion

        public MainViewModel()
        {
            Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };

        }
    }
}


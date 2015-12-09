using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using MySql.Data.MySqlClient;
using System.ComponentModel.Composition;
using P3.Helpers;
using i_hate_windows.Helpers;
using i_hate_windows.ViewModels;
using System.ComponentModel;
using OxyPlot;
using OxyPlot.Series;

namespace P3.ViewModels
{
    [Export(typeof(GraphScreenViewModel))]
    class GraphScreenViewModel : Screen
    {

        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public GraphScreenViewModel(BindableCollection<Listing> ls, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _results = ls;
            this.Title = "test";
            this.Points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
        }
        private BindableCollection<Listing> _results;
        private string _title;
        private IList<DataPoint> _points;
        public string Title    
        {
            get { return _title; }
           
            set {_title = value;
                NotifyOfPropertyChange(() => Title);
                }
        }
        public BindableCollection<Listing> Results
        {
            get { return _results; }

            set
            {
                _results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }

        public IList<DataPoint> Points 
        {
            get
            {
                return _points;
            }

            set
            {
                _points = value;
                NotifyOfPropertyChange(() => Points);
            }
        }
    }
}
    
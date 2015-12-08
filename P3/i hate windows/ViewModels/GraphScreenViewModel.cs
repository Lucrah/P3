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
        public GraphScreenViewModel(BindableCollection<Listing> ls, IWindowManager _windowManager)
        {
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

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }
    }
}
    
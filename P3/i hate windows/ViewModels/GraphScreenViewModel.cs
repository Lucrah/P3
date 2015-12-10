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
using OxyPlot.Axes;

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
            this.Title = "Pris udvikling";
            this.Kvm = new List<DataPoint>();

            foreach (var Property in Results)
            {
                if( Property.IsSelected ){
                    if (Property.SalesDate.ToOADate() != 0)
                    {
                        Kvm.Add(new DataPoint(Property.SalesDate.ToOADate(), Property.PriceSqr));
                    }
                    else
                        Kvm.Add(new DataPoint(Property.ForSaleDate.ToOADate(), Property.PriceSqr));
                };
                
            }
            Kvm.OrderBy(s => s.X);   
                             

        }

        private BindableCollection<Listing> _results;
        private string _title;
        private IList<DataPoint> _kvm;
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

        public IList<DataPoint> Kvm 
        {
            get
            {
                return _kvm;
            }

            set
            {
                _kvm = value;
                NotifyOfPropertyChange(() => Kvm);
            }
        }
    }
}
    
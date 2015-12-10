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

        public GraphScreenViewModel(BindableCollection<Listing> ls, IWindowManager windowManager, string searchInput)
        {
            _windowManager = windowManager;
            _results = ls;
            _input = searchInput;
            this.Title1 = "Pris udvikling";
            this.Kvm1 = new List<DataPoint>();
            this.Kvm2 = new List<DataPoint>();
            this.Liggetid = new List<DataPoint>();
           
            

                foreach (var Property in Results.OrderBy(t=>t.SalesDate).ThenBy(s=>s.ForSaleDate))
                {
                         if (Property.SalesDate.ToOADate() != 0)
                    {
                        Kvm1.Add(new DataPoint(Property.SalesDate.ToOADate(), Property.PriceSqr));
                    }
                    else
                    {
                        Kvm2.Add(new DataPoint(Property.ForSaleDate.ToOADate(), Property.PriceSqr));
                    }
                }




                this.Liggetid = new List<DataPoint>();
           



        }

        private BindableCollection<Listing> _results;
        private string _title1;
        private string _title2;
        private string _input;
        private IList<DataPoint> _kvm1;
        private IList<DataPoint> _kvm2;
        private IList<DataPoint> _liggetid;
        public string Title1    
        {
            get { return _title1; }
           
            set {_title1 = value;
                NotifyOfPropertyChange(() => Title1);
                }
        }
        public string Title2
        {
            get { return _title2; }

            set
            {
                _title2 = value;
                NotifyOfPropertyChange(() => Title2);
            }
        }
        public string Input
        {
            get { return _input; }

            set
            {
                _input = value;
                NotifyOfPropertyChange(() => Input);
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

        public IList<DataPoint> Kvm1 
        {
            get
            {
                return _kvm1;
            }

            set
            {
                _kvm1 = value;
                NotifyOfPropertyChange(() => Kvm1);
            }
        }
        public IList<DataPoint> Kvm2
        {
            get
            {
                return _kvm2;
            }

            set
            {
                _kvm2 = value;
                NotifyOfPropertyChange(() => Kvm2);
            }
        }
        public IList<DataPoint> Liggetid
        {
            get
            {
                return _liggetid;
            }

            set
            {
                _liggetid = value;
                NotifyOfPropertyChange(() => Liggetid);
            }
        }
    }
}
    
using Caliburn.Micro;
using i_hate_windows.Helpers;
using P3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_hate_windows.ViewModels
{
    [Export(typeof(PrintWindowViewModel))]
    class PrintWindowViewModel : Screen
    {
        //Enable these as needed.
        //IWindowManager _windowManager;
        IEventAggregator _eventAggregator;

        SearchSettingModel _searchSettings;
        BindableCollection<Listing> _resultsReturned;
        object _graphResults;
        string _whatToAppend;

        public string WhatToAppend
        {
            get
            {
                return _whatToAppend;
            }

            set
            {
                _whatToAppend = value;
            }
        }

        [ImportingConstructor]
        public PrintWindowViewModel(BindableCollection<Listing> resultsReturned, SearchSettingModel searchSettings, object graphResults, IEventAggregator eventaggregator)
        {
            _searchSettings = searchSettings;
            _resultsReturned = resultsReturned;
            _graphResults = graphResults;
            _eventAggregator = eventaggregator;
            _eventAggregator.Subscribe(this);
        }

        public void executePDFCreation()
        {
            try
            {
                PDFConverter pdfcon = new PDFConverter(_resultsReturned, _searchSettings, _graphResults, WhatToAppend);
                pdfcon.ExecuteCreation();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ClosingMsg()
        {
            _eventAggregator.PublishOnUIThread(new BoolPropMsg("IsPrintOpen", false));
        }
    }
}

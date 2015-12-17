using Caliburn.Micro;
using P3.Helpers;
using P3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3.ViewModels
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

    bool _useSearch;
    bool _useGraph;
    int _numberOfSearchResults;
    bool _useAllResults;

    public string WhatToAppend
    {
      get
      {
        return _whatToAppend;
      }

      set
      {
        _whatToAppend = value;
        NotifyOfPropertyChange(() => WhatToAppend);
      }
    }
    public bool UseSearch
    {
      get
      {
        return _useSearch;
      }

      set
      {
        _useSearch = value;
        NotifyOfPropertyChange(() => UseSearch);
      }
    }
    public bool UseGraph
    {
      get
      {
        return _useGraph;
      }

      set
      {
        _useGraph = value;
        NotifyOfPropertyChange(() => UseGraph);
      }
    }
    public int NumberOfSearchResults
    {
      get
      {
        return _numberOfSearchResults;
      }

      set
      {
        _numberOfSearchResults = value;
        NotifyOfPropertyChange(() => NumberOfSearchResults);
      }
    }
    public bool UseAllResults
    {
      get
      {
        return _useAllResults;
      }

      set
      {
        _useAllResults = value;
        NotifyOfPropertyChange(() => UseAllResults);
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

    public void ExecutePDFCreation()
    {
      try
      {
        PDFConverter pdfcon = new PDFConverter(_resultsReturned, _searchSettings, _graphResults, WhatToAppend);
        if (UseSearch && !UseGraph)
        {
          pdfcon.ExecuteCreation("result", NumberOfSearchResults);
        }
        if (UseGraph && !UseSearch)
        {
          pdfcon.ExecuteCreation("graph", NumberOfSearchResults);
        }
        else
          pdfcon.ExecuteCreation("", NumberOfSearchResults);

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

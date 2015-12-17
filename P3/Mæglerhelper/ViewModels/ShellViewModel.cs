using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Interfaces;
using P3.Helpers;
using P3.Models;
using P3.ViewModels;

namespace P3.ViewModels
{
  [Export(typeof(IShell))]
  class ShellViewModel : Conductor<object>.Collection.OneActive, IShell, IHandle<IsFlyoutOpenMsg>
  {
    #region IOC Fields
    private readonly IEventAggregator _eventAggregator;
    private readonly IWindowManager _windowManager;
    #endregion

    [ImportingConstructor]
    public ShellViewModel()
    {
      _windowManager = IoC.Get<IWindowManager>();
      _eventAggregator = IoC.Get<IEventAggregator>();
      WindowTitle = "MæglerHelper v0.1337";
      ActivateItem(new SearchScreenViewModel(_windowManager, _eventAggregator));
      _eventAggregator.Subscribe(this);
      FlyoutViewModel = new FlyoutLeftViewModel(_eventAggregator);
    }

    #region Fields / getset

    private string _windowTitle;
    private bool _isFlyoutOpen;
    private FlyoutLeftViewModel _flyoutviewmodel;
    private Listing _selectedListing;

    public string WindowTitle
    {
      get
      {
        return _windowTitle;
      }

      set
      {
        _windowTitle = value;
        NotifyOfPropertyChange(() => WindowTitle);
      }
    }

    public bool IsFlyoutOpen
    {
      get
      {
        return _isFlyoutOpen;
      }

      set
      {
        _isFlyoutOpen = value;
        NotifyOfPropertyChange(() => IsFlyoutOpen);
      }
    }

    public FlyoutLeftViewModel FlyoutViewModel
    {
      get
      {
        return _flyoutviewmodel;
      }

      set
      {
        _flyoutviewmodel = value;
        NotifyOfPropertyChange(() => FlyoutViewModel);
      }
    }

    public Listing SelectedListing
    {
      get
      {
        return _selectedListing;
      }

      set
      {
        _selectedListing = value;
        NotifyOfPropertyChange(() => SelectedListing);
      }
    }
    #endregion
    #region HandleEvents

    public void Handle(IsFlyoutOpenMsg message)
    {
      if (!IsFlyoutOpen)
      {
        IsFlyoutOpen = message.IsOpen;
        SelectedListing = message.SelectedListing;
      }
    }
    #endregion
    #region NavigateFunctions
    public void ShowSearchScreen()
    {
      ActivateItem(new SearchScreenViewModel(_windowManager, _eventAggregator));
    }
    #endregion
  }
}

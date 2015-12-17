﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Interfaces;
using i_hate_windows.Helpers;
using P3.Models;
using i_hate_windows.ViewModels;

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
    //this  whole ordeal is very badly named i know. make me fix.
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
    /*Shows how to display an item(in this case a usercontrol)
     *you then do something like this on a button:
     * <Button x:Name="ShowResultScreen" Content="ResultScreen" Height="29.5" VerticalAlignment="Top" Width="96"/>
     * And really, this can be used to bind any function to any button/other control.
     * This also shows the aforementioned ActivateItem. If i wanted to pass settings or something into the views it could be done here.
     * */

    public void ShowSearchScreen()
    {
      ActivateItem(new SearchScreenViewModel(_windowManager, _eventAggregator));
    }
    #endregion
  }
}

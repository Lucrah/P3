using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;
using Caliburn.Micro;
using P3.Helpers;
using P3.Models;
using System.ComponentModel.Composition;

namespace P3.ViewModels
{
  [Export(typeof(FlyoutLeftViewModel))]
  class FlyoutLeftViewModel : Screen, IHandle<IsFlyoutOpenMsg>
  {
    private IEventAggregator _eventaggregator;
    private Listing _selectedItem;

    [ImportingConstructor]
    public FlyoutLeftViewModel(IEventAggregator iEventAggregator)
    {
      _eventaggregator = iEventAggregator;
      _eventaggregator.Subscribe(this);
    }

    public Listing SelectedItem
    {
      get
      {
        return _selectedItem;
      }

      set
      {
        _selectedItem = value;
        NotifyOfPropertyChange(() => SelectedItem);
      }
    }

    public void Handle(IsFlyoutOpenMsg message)
    {
      SelectedItem = message.SelectedListing;
    }
  }
}

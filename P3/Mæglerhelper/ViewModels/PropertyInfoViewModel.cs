using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using System.ComponentModel.Composition;

namespace P3.ViewModels
{
  [Export(typeof(PropertyInfoViewModel))]
  class PropertyInfoViewModel : Screen
  {
    
    private readonly IWindowManager _windowManager;
    [ImportingConstructor]
    public PropertyInfoViewModel(Listing ls, IWindowManager windowManager)
    {
      _windowManager = windowManager;
      _propertyToShow = ls;
    }
    private Listing _propertyToShow;

    public Listing PropertyToShow
    {
      get
      {
        return _propertyToShow;
      }

      set
      {
        _propertyToShow = value;
        NotifyOfPropertyChange(() => PropertyToShow);
      }
    }
  }
}

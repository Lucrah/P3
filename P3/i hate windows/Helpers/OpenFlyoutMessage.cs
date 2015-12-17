using Caliburn.Micro;
using P3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_hate_windows.Helpers
{
  class IsFlyoutOpenMsg
  {
    private bool _isOpen;
    public bool IsOpen
    {
      get { return _isOpen; }
      set { _isOpen = value; }
    }
    private Listing _selectedListing;
    public Listing SelectedListing
    {
      get { return _selectedListing; }
      set { _selectedListing = value; }
    }
    public IsFlyoutOpenMsg(bool isOpen, Listing selectedListing)
    {
      SelectedListing = selectedListing;
      IsOpen = isOpen;
    }
  }
}

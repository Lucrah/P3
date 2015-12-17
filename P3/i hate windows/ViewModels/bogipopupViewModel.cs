using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_hate_windows.ViewModels
{
  class bogipopupViewModel : PropertyChangedBase
  {

    public bogipopupViewModel(string text)
    {
      Text = text;
    }
    private string _text;

    public string Text
    {
      get
      {
        return _text;
      }

      set
      {
        _text = value;
        NotifyOfPropertyChange(() => Text);
      }
    }
  }
}

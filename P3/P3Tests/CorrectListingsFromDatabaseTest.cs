using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3;
using P3.Helpers;
using P3.Models;
using P3.Views;
using Caliburn.Micro;

namespace P3Tests
{

  [TestClass]
  public class CorrectListingsFromDatabaseTest
  {
    static IWindowManager windowManager;
    Funktionality fncy = new Funktionality(windowManager);

    [TestMethod]
    public void TestCorrectDatabaseReturn()
    {
      BindableCollection<Listing> TestResults = new BindableCollection<Listing>();

      SearchSettingModel TestSearchSetting = new SearchSettingModel();

      TestSearchSetting.SearchInput = "Rendsburggade 28 9000";
      TestSearchSetting.SizeSliderLowerValue = 100;
      TestSearchSetting.SizeSliderHigherValue = 200;
      TestSearchSetting.Villa = true;
      TestSearchSetting.Lejlighed = true;
      TestSearchSetting.AreaSliderHigherValue = 3000;
      TestSearchSetting.PriceSliderHigherValue = 2500000;
      TestSearchSetting.PriceSliderLowerValue = 1000000;

      TestResults = fncy.SuperSearch(TestSearchSetting);



      foreach (var item in TestResults)
      {
        Assert.IsTrue(item.Price <= TestSearchSetting.PriceSliderHigherValue && item.Price >= TestSearchSetting.PriceSliderLowerValue);
        Assert.IsTrue(item.Size <= TestSearchSetting.SizeSliderHigherValue && item.Size >= TestSearchSetting.SizeSliderLowerValue);
        Assert.IsTrue(item.PropertyType == "Villa" || item.PropertyType == "Lejlighed");
      }
    }
  }
}

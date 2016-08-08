using System.Collections.Generic;
using Xunit;
using System;


namespace BandTracker.Objects
{
  public class BandTest
  {

    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }



    [Fact]
    public void Test1_BandGetName()
    {

      Band newBand = new Band("Beattles");

      string result = newBand.GetName();

      Assert.Equal("Beattles", result);
    }

    [Fact]
    public void Test2_SetName()
    {

      Band newBand = new Band("Beattles");
      newBand.SetName("Nirvana");

      string result = newBand.GetName();

      Assert.Equal("Nirvana", result);
    }


  [Fact]
     public void Test3_Save()
     {

       Band testBand = new Band("Beatles");

       testBand.Save();
       List<Band> result = Band.GetAll();
       List<Band> testList = new List<Band>{testBand};
      
       Assert.Equal(testList, result);
     }



  }
}

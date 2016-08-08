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
      // arrange
      Band newBand = new Band("Beattles");
      // act
      string result = newBand.GetName();
      // assert
      Assert.Equal("Beattles", result);
    }

  }
}
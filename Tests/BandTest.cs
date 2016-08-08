using System.Collections.Generic;
using Xunit;
using System;


namespace BandTracker.Objects
{
  public class BandTest
  {

    public BandTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Band_Tracker_test;Integrated Security=SSPI;";
   }



    [Fact]
    public void Test1_BandGetName()
    {

      Band newBand = new Band("Sting");

      string result = newBand.GetName();

      Assert.Equal("Sting", result);
    }

    [Fact]
  public void Test2_SetName()
  {

    Band newBand = new Band("All 4 One");
    newBand.SetName("All 4 One");

    string result = newBand.GetName();

    Assert.Equal("All 4 One", result);
  }

  [Fact]
      public void Test3_SaveBand()
      {

      Band newBand = new Band("Beatles");
      newBand.Save();

      List<Band> allBands = Band.GetAll();

      Assert.Equal(newBand, allBands[0]);
      }


     [Fact]
  public void Test4_FindId()
  {
    Band newBand = new Band ("Coldplay");
    newBand.Save();

    Band findBand = Band.Find(newBand.GetId());

    Assert.Equal(findBand, newBand);
  }

  [Fact]
    public void Test5_UpdateBand()
    {
      Band newBand = new Band("Queen");
      newBand.Save();
      newBand.Update("Queen");
      string result = newBand.GetName();

      Assert.Equal("Queen", result);
    }


    [Fact]
  public void Test7_DeleteOneBand()
  {

    Band firstBand = new Band("Sting");
    firstBand.Save();

    Band secondBand = new Band("Chilli-peppers");
    secondBand.Save();

    firstBand.Delete();
    List<Band> allBands = Band.GetAll();
    List<Band> afterDeleteFristBand = new List<Band> {secondBand};

    Assert.Equal(afterDeleteFristBand, allBands);
}



  }
}

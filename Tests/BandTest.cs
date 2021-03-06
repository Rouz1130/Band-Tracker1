using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmptyAtFirst()
    {

      int result = Band.GetAll().Count;


      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Equal_ReturnsTrueIfNamesAreTheSame()
    {

      Band firstBand = new Band("GreenDay");
      Band secondBand = new Band("GreenDay");


      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
   public void Test3_Save_SavesToDatabase()
   {

     Band testBand = new Band("Nirvana");


     testBand.Save();
     List<Band> result = Band.GetAll();
     List<Band> testList = new List<Band>{testBand};


     Assert.Equal(testList, result);
   }


   [Fact]
   public void Test4_Save_AssignsIdToBandObject()
   {

     Band testBand = new Band("Nirvana");
     testBand.Save();

     Band savedBand = Band.GetAll()[0];

     int result = savedBand.GetId();
     int testId = testBand.GetId();


     Assert.Equal(testId, result);
   }


    [Fact]
    public void Test5_Find_FindsBandInDatabase()
    {

      Band testBand = new Band("Nirvana");
      testBand.Save();


      Band foundBand = Band.Find(testBand.GetId());


      Assert.Equal(testBand, foundBand);
    }


    [Fact]
   public void Test6_AddVenue_AddsVenueToBand()
   {

     Band testBand = new Band("Nirvana");
     testBand.Save();

     Venue testVenue = new Venue("Acc");
     testVenue.Save();

     testBand.AddVenue(testVenue);

     List<Venue> result = testBand.GetVenues();
     List<Venue> testList = new List<Venue>{testVenue};

     Assert.Equal(testList, result);
   }


   [Fact]
    public void Test7_GetVenues_ReturnsBandVenues()
    {
      Band testBand = new Band("The Doors");
      testBand.Save();

      Venue testVenue1 = new Venue("Acc");
      testVenue1.Save();

      Venue testVenue2 = new Venue("O2");
      testVenue2.Save();

      testBand.AddVenue(testVenue1);
      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1};


      Assert.Equal(testList, result);
    }


    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}

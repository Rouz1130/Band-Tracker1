using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_VenuesEmptyAtFirst()
    {

      int result = Venue.GetAll().Count;


      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Equal_ReturnsTrueForSameName()
    {

      Venue firstVenue = new Venue("Skydome");
      Venue secondVenue = new Venue("Skydome");


      Assert.Equal(firstVenue, secondVenue);
    }

    [Fact]
    public void Test_Save_SavesVenueToDatabase()
    {

      Venue testVenue = new Venue("Skydome");
      testVenue.Save();


      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};


      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test4_Save_AssignsIdToVenueObject()
    {

      Venue testVenue = new Venue("Skydome");
      testVenue.Save();

      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      Assert.Equal(testId, result);
    }


    [Fact]
    public void Test_Find_FindsVenueInDatabase()
    {

      Venue testVenue = new Venue("Skydome");
      testVenue.Save();


      Venue foundVenue = Venue.Find(testVenue.GetId());


      Assert.Equal(testVenue, foundVenue);
    }







    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}

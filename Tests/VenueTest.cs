using System.Collections.Generic;
using Xunit;
using System;


namespace BandTracker.Objects
{
  public class VenueTest
  {

    public VenueTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
   }


   [Fact]
   public void Test1_GetVenueName()
   {

     Venue newVenue = new Venue("O2");

     string result = newVenue.GetVenueName();

     Assert.Equal("O2", result);
   }


   // [Fact]
  public void Test2_SetVenueName()
  {
    // arrange
    Venue newVenue = new Venue("Skydome");
    newVenue.SetName("Skydome");
    // act
    string result = newVenue.GetVenueName();

    Assert.Equal("Skydome", result);
  }

  [Fact]
  public void Test3_SaveVenueName()
  {

  Venue newVenue = new Venue("ShowBox");
  newVenue.Save();

  List<Venue> allVenues = Venue.GetAll();
  Console.WriteLine(allVenues.Count);

  Assert.Equal(newVenue, allVenues[0]);
  }




  }
}

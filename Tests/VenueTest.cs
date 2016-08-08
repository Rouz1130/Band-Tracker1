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
     // arrange
     Venue newVenue = new Venue("O2");
     // act
     string result = newVenue.GetVenueName();

     Assert.Equal("O2", result);
   }


  }
}

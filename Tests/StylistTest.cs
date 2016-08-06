using System.Collections.Generic;
using Xunit;
using System;


namespace HairSaloon.Objects
{
  public class StylistTest
  {
    [Fact]
    public void Test1_StylistGetName()
    {
      Stylist newStylist = new Stylist("Bill");

      string result = newStylist.GetName();

     Assert.Equal("Bill", result);

    }





  }
}

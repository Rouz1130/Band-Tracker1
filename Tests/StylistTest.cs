using System.Collections.Generic;
using Xunit;
using System;


namespace HairSaloon.Objects
{
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }

  public StylistTest()
  {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_Saloon_test;Integrated Security=SSPI;";
  }

    [Fact]
    public void Test1_StylistGetName()
    {
      Stylist newStylist = new Stylist("Bill");

      string result = newStylist.GetName();

     Assert.Equal("Bill", result);
    }

    [Fact]
    public void Test2_SetName()
    {
      Stylist newStylist = new Stylist("Bill");
      newStylist.SetName("Bill");

      string result = newStylist.GetName();

      Assert.Equal("Bill", result);
    }

    [Fact]
    public void Test3_SaveStylist()
    {
      Stylist newStylist = new Stylist("Bill");
      newStylist.Save();

      List<Stylist> allStylists = Stylist.GetAll();
      Console.WriteLine(allStylists.Count);

      Assert.Equal(newStylist, allStylists[0]);
    }

   [Fact]
   public void Test4_FindStylist_Name_Id()
   {
    Stylist newStylist = new Stylist ("Bill");
    newStylist.Save();

    Stylist findStylist = Stylist.Find(newStylist.GetId());

    Assert.Equal(findStylist, newStylist);
  }


    [Fact]
    public void Test6_UpdateStylist_Database()
    {
      Stylist newStylist = new Stylist("Bill");
      newStylist.Save();
      newStylist.Update("Bill");
      string result = newStylist.GetName();

      Assert.Equal("Bill", result);
    }

    [Fact]
    public void Test7_DeleteOneStylist()
    {
      Stylist firstStylist = new Stylist("Bill");
      firstStylist.Save();

      Stylist secondStylist = new Stylist("Bob");
      secondStylist.Save();

      firstStylist.Delete();
      List<Stylist> allStylists = Stylist.GetAll();
      List<Stylist> afterDeleteFristStylist = new List<Stylist> {secondStylist};

      Assert.Equal(afterDeleteFristStylist, allStylists);
    }


  }
}

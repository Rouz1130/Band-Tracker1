using System.Collections.Generic;
using Xunit;
using System;


namespace HairSaloon.Objects
{
  public class ClientTest
  {
    // public void Dispose()
    // {
    //   Client.DeleteAll();
    // }

    public ClientTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_saloon_test;Integrated Security=SSPI;";
   }


   [Fact]
    public void Test1_ClientGetName()
    {
      // arrange
      Client newClient = new Client("Bill", 1);
      // act
      string result = newClient.GetName();

      Assert.Equal("Bill", result);
    }

    [Fact]
  public void Test2_SetName()
  {
    // arrange
    Client newClient = new Client("Bobby",2);
    newClient.SetName("Bobby");
    // act
    string result = newClient.GetName();

    Assert.Equal("Bobby", result);
  }

  }
}

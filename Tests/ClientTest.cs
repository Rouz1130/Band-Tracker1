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
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_Saloon_test;Integrated Security=SSPI;";
   }


   [Fact]
    public void Test1_ClientGetName()
    {
      // arrange
      Client newClient = new Client("Russ", 1);
      // act
      string result = newClient.GetName();

      Assert.Equal("Russ", result);
    }
  }
}

using System.Collections.Generic;
using Xunit;
using System;


namespace HairSaloon.Objects
{
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      //Client.DeleteAll();
    }

    public ClientTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_Saloon_test;Integrated Security=SSPI;";
   }

   [Fact]
   public void Test1_GetClientName()
   {
     // arrange
     Client newClient = new Client("English");
     // act
     string result = newClient.GetClientName();

     Assert.Equal("English", result);
   }
  }
 }

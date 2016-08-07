using System.Collections.Generic;
using Xunit;
using System;


namespace HairSaloon.Objects
{
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }

    public void ClientTest1()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_saloon_test;Integrated Security=SSPI;";
   }


   [Fact]
    public void Test2_ClientGetName()
    {
      // arrange
      Client newClient = new Client("Bill", 1);
      // act
      string result = newClient.GetName();

      Assert.Equal("Bill", result);
    }

    [Fact]
  public void Test3_SetName()
  {
    // arrange
    Client newClient = new Client("Bobby",2);
    newClient.SetName("Bobby");
    // act
    string result = newClient.GetName();

    Assert.Equal("Bobby", result);
  }

  [Fact]
   public void Test4_SaveClient()
   {
     //Arrange
   Client newClient = new Client("Becky",1);
   newClient.Save();
     //ACt
   List<Client> allClients = Client.GetAll();
   //Console.WriteLine(allClients[0].GetName());
     //assert
   Assert.Equal(newClient, allClients[0]);
   }


   [Fact]
      public void Test5_Find_FindsClientInDatabase()
      {

        Client testClient = new Client("Bill", 1);
        testClient.Save();


        Client foundClient = Client.Find(testClient.GetClient_id());


        Assert.Equal(testClient, foundClient);
      }




  }
}

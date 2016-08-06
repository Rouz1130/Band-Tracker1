using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSaloon
{
  public class Client
  {
    private string _clientName;
    private int _id;


    public Client(string clientName, int id=0)
    {
      _clientName = clientName;
      _id = id;
    }

    public string GetClientName()
    {
      return _clientName;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string newClientName)
    {
      _clientName = newClientName;
    }


    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        return this.GetClientName().Equals(newClient.GetClientName());
      }
    }
   }
  }

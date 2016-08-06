using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSaloon.Objects
{
  public class Client
  {

    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string Name, int stylist_id ,int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylist_id = stylist_id;
    }

    public int GetStylistId()
    {
      return _stylist_id;
    }

    public void SetStylistId(int id)
    {
      _stylist_id = id;
    }


    public string GetName()
    {
      return _name;
    }

    public int GetClient_id()
     {
       return _id;
     }


    public void SetName(string newName)
    {
      _name = newName;
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
        Console.WriteLine("this.GetName()=" + this.GetName());
        Console.WriteLine("newClient.GetName()=" + newClient.GetName());
        return this.GetName() == newClient.GetName();
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
  }
}

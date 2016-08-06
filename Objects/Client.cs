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
    //constructor
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

    public void Save()
       {
         SqlConnection conn = DB.Connection();
         conn.Open();

         SqlCommand cmd = new SqlCommand("INSERT INTO Clients (name, Stylist_id) OUTPUT INSERTED.id VALUES (@clientsName, @stylist_id);", conn);

         SqlParameter nameParameter = new SqlParameter();
         nameParameter.ParameterName = "@clientsName";
         nameParameter.Value = this.GetName();
         cmd.Parameters.Add(nameParameter);

         SqlParameter stylistIdParameter = new SqlParameter();
          stylistIdParameter.ParameterName = "@stylist_id";
          stylistIdParameter.Value = this.GetStylistId();
          cmd.Parameters.Add(stylistIdParameter);

         SqlDataReader rdr = cmd.ExecuteReader();

         while(rdr.Read())
         {
           this._id = rdr.GetInt32(0);
         }
         if (rdr != null)
         {
           rdr.Close();
         }
         if (conn != null)
         {
           conn.Close();
         }
       }

       public static List<Client> GetAll()
       {
         List<Client> allClients = new List<Client>{};

         SqlConnection conn = DB.Connection();
         conn.Open();
         SqlCommand cmd = new SqlCommand("SELECT * FROM Clients;", conn);
         SqlDataReader rdr  = cmd.ExecuteReader();

         while(rdr.Read())
         {
           string clientName = rdr.GetString(1);
           int stylistId = rdr.GetInt32(2);
           int clientId = rdr.GetInt32(0);
           Client newClient = new Client(clientName, stylistId, clientId);
           allClients.Add(newClient);
         }
         if (rdr != null)
         {
           rdr.Close();
         }
         if (conn != null)
         {
           conn.Close();
         }
         return allClients;
       }


          public void Delete()
             {
               SqlConnection conn = DB.Connection();
               conn.Open();
               SqlCommand cmd = new SqlCommand ("DELETE FROM Clients WHERE id =@clientId;", conn);

               SqlParameter stylistIdParameter = new SqlParameter();
               stylistIdParameter.ParameterName = "@stylistId";
               stylistIdParameter.Value=this._id;
               Console.WriteLine(this._id);
               cmd.Parameters.Add(stylistIdParameter);
               cmd.ExecuteNonQuery();
               if (conn !=null)
               {
                 conn.Close();
               }
             }
             public static void DeleteAll()
             {

             }


    public static Client Find(int id)
     {
       SqlConnection conn = DB.Connection();
       conn.Open();

       SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
       SqlParameter stylistIdParameter = new SqlParameter();
       stylistIdParameter.ParameterName = "@ClientId";
       stylistIdParameter.Value = id.ToString();
       cmd.Parameters.Add(stylistIdParameter);
       SqlDataReader rdr = cmd.ExecuteReader();

       int foundClientId = 0;
       string foundClientName = null;
       int foundClientStylistId = 0;

       while(rdr.Read())
       {
         foundClientId = rdr.GetInt32(0);
         foundClientName = rdr.GetString(1);
         foundClientStylistId = rdr.GetInt32(2);
       }
       Client foundClient = new Client(foundClientName, foundClientStylistId, foundClientId);

       if (rdr != null)
       {
         rdr.Close();
       }
       if (conn != null)
       {
         conn.Close();
       }

       return foundClient;
     }

  }
}

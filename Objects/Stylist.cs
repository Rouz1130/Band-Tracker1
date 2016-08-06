using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSaloon
{
  public class Stylist
{
  private string _name;
  private int _id;

  public Stylist(string name, int id=0 )
  {
    _name = name;
    _id = id;
  }

  public string GetName()
  {
    return _name;
  }

  public int GetId()
  {
    return _id;
  }

  public void SetName(string newName)
  {
    _name = newName;
  }

  public override bool Equals(System.Object otherStylist)
  {
    if(!(otherStylist is Stylist))
    {
      return false;
    }
    else
    {
      Stylist newStylist = (Stylist) otherStylist;
      return this.GetName().Equals(newStylist.GetName());
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

    SqlCommand cmd = new SqlCommand("INSERT INTO stylists(name)OUTPUT INSERTED.id VALUES (@stylistName);", conn);
    SqlParameter nameParameter = new SqlParameter();
    nameParameter.ParameterName = "@stylistName";
    nameParameter.Value = this.GetName();
    cmd.Parameters.Add(nameParameter);

    SqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._id = rdr.GetInt32(0);
    }
    if (rdr !=null)
    {
      rdr.Close();
    }
    if (conn !=null)
    {
      conn.Close();
    }
  }

  public static List<Stylist> GetAll()
  {
    List<Stylist> allStylists = new List<Stylist>{};

   SqlConnection conn = DB.Connection();
   conn.Open();
   SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
   SqlDataReader rdr  = cmd.ExecuteReader();

   while(rdr.Read())
   {
   int stylistId = rdr.GetInt32(0);
   string stylistName = rdr.GetString(1);
   Stylist newStylist = new Stylist(stylistName,stylistId);
   allStylists.Add(newStylist);
   }
   if (rdr != null)
   {
     rdr.Close();
   }
   if (conn != null)
   {
     conn.Close();
   }
   return allStylists;
  }


    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Stylists WHERE id = @stylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName =  "@stylistId";
      stylistIdParameter.Value = id.ToString();
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int findStylistId = 0;
      string findStylistName = null;
      while(rdr.Read())
      {
        findStylistId = rdr.GetInt32(0);
        findStylistName = rdr.GetString(1);

      }
      Stylist findStylist = new Stylist(findStylistName,findStylistId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return findStylist;

    }


    public void Update(string Name)
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("UPDATE Stylists SET name =@stylistName output inserted.name WHERE id =@stylistId;", conn);
     SqlParameter StylistNameParameter = new SqlParameter();
     StylistNameParameter.ParameterName = "@stylistName";
     StylistNameParameter.Value = Name;

     SqlParameter StylistIdParameter = new SqlParameter();
     StylistIdParameter.ParameterName = "@stylistId";
     StylistIdParameter.Value = this.GetId();

     cmd.Parameters.Add(StylistNameParameter);
     cmd.Parameters.Add(StylistIdParameter);

     SqlDataReader rdr = cmd.ExecuteReader();

     while(rdr.Read())
     {
       this._name = rdr.GetString(0);
     }

     if (rdr != null)
     {
       rdr.Close();
     }

     if (rdr != null)
     {
       conn.Close();
     }
   }





  public static void DeleteAll()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();
    SqlCommand cmd = new SqlCommand ("DELETE FROM stylists;",conn);
    cmd.ExecuteNonQuery();
    conn.Close();
  }

 }
}

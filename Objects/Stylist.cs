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

  public void Save()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();
  }
  public static List<Stylist> GetAll()
  {
    return new List<Stylist>();
  }


 }
}

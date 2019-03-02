using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
   private string _description;
   private static List<Client> _instances = new List<Client> {};

    public Client (string description)
      {
        _description = description;
        _instances.Add(this);
      }

    public string GetDescription()
      {
        return _description;
      }

    public void SetDescription(string newDescription)
      {
        _description = newDescription;
      }

    public static List<Client> GetAll()
    {
        return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

  }
}
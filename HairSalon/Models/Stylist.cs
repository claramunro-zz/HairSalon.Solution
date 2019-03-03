using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    private static List<Stylist> _instances = new List<Stylist> {};
    private string _name;
    private int _id;
    private List<Client> _clients;

    public Stylist(string stylistName)
    {
      _name = stylistName;
      _instances.Add(this);
      _id = _instances.Count;
      _clients = new List<Client>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
        _instances.Clear();
    }

    public static List<Stylist> GetAll()
    {
      return _instances;
    }

    public static Stylist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public List<Client> GetClients()
    {
        return _clients;
    }

    public void AddClient(Client client)
    {
        _clients.Add(client);
    }


  }
}
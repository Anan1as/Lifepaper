namespace Lifepaper.Models
{
  public class Recipient
  {
    public string Correo { get; set; }
    public string Name { get; set; }

    public Recipient(string correo)
    {
      Correo = correo;
    }
  }
}

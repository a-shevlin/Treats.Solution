namespace Treats.Models
{
  public class TreatFlavors
  {
    public int TreatFlavorId {get; set;}
    public int TreatId {get; set;}
    public int FlavorId {get; set;}
    public virtual Treat Treat {get; set;}
    public virtual Flavor Flavor {get; set;}
  }
}
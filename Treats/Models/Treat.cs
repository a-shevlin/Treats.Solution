using System.Collections.Generic;

namespace Treats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<TreatFlavor>();
    }

    public int TreatId {get; set;}
    public string TreatName {get; set;}
    public string Description {get; set;}

    public virtual ICollection<TreatFlavor> JoinEntities {get;}
  }
}
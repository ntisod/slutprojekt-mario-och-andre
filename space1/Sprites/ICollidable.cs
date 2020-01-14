using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space1.Sprites
{
    // att sprites kan kollidera 
  public interface ICollidable
  {
    void OnCollide(Sprite sprite);
  }
}

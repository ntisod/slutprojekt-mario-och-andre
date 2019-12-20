using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space1.Sprites
{
  public interface ICollidable
  {
    void OnCollide(Sprite sprite);
  }
}

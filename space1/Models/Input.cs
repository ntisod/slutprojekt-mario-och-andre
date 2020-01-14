using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space1.Models
{
  public class Input
  {
        // bevarar tangent tryck sen get och tar dem 
    public Keys Up { get; set; }

    public Keys Down { get; set; }

    public Keys Left { get; set; }

    public Keys Right { get; set; }

    public Keys Shoot { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Luyks.Jonas
{
    public abstract class Character
    {
        public Texture2D texture { get; set; }

        public int walkSpeedx { get; set; }
        public int runSpeedx { get; set; }
    }
}

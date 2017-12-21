using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Luyks.Jonas
{
    public abstract class Character
    {
        public Texture2D Texture { get; set; }

        public int WalkSpeedx { get; set; }
        public int RunSpeedx { get; set; }
        public int FallSpeed { get; set; }
        public int ClimbSpeed { get; set; }
        public int SpeedY { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public abstract void HandleCollision(GameTime gameTime);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    public abstract class LevelAsset
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    public class Toilet : LevelAsset
    {
        public Toilet(Vector2 vector2)
        {
            Position = vector2;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: new Rectangle(0, 200, 31, 40), color: Color.White, scale: new Vector2((float)1.4, (float)1.4));
        }
    }
}

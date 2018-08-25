using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Door : LevelAsset
    {
        public Door(Vector2 vector2)
        {
            Position = vector2;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: new Rectangle(0, 0, 70, 70), color: Color.White, scale: new Vector2((float)0.71, (float)0.71));
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Key : LevelAsset
    {
        public Key(Vector2 vector2)
        {
            Position = vector2;
            CollisionRectangle = new Rectangle((int)Position.X + 10, (int)Position.Y + 10, 30, 30);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: new Rectangle(0, 0, 70, 70), color: Color.White, scale: new Vector2((float)0.71, (float)0.71));
        }
    }
}

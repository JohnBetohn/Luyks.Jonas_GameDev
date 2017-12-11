using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Block : LevelAsset
    {
        public Block(Vector2 position)
        {
            Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, 50, 50) , Color.White);
        }
    }
}

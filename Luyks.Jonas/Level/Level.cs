using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Level
    {
        private List<Block> blocks = new List<Block>();

        public List<Block> Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        private List<Ladder> ladders = new List<Ladder>();

        public List<Ladder> Ladders
        {
            get { return ladders; }
            set { ladders = value; }
        }


        public int Height { get; set; }
        public int Width { get; set; }

        public Level()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            // Iterate over list and draw all assets in spritebatch
            for (int i = 0; i < Blocks.Count; i++)
            {
                blocks[i].Draw(spritebatch);
            }

            for (int i = 0; i < Ladders.Count; i++)
            {
                Ladders[i].Draw(spritebatch);
            }
        }

        public void AddBlock(List<Block> blocks)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                this.blocks.Add(blocks[i]);
            }
        }

        public void AddLadder(List<Ladder> ladders)
        {
            for (int i = 0; i < ladders.Count; i++)
            {
                this.ladders.Add(ladders[i]);
            }
        }

        public List<Rectangle> getLevelCollision()
        {
            List<Rectangle> collision = new List<Rectangle>();
            for (int i = 0; i < Blocks.Count; i++)
            {
                collision.Add(Blocks[i].CollisionRectangle);
            }
            return collision;
        }
    }
}

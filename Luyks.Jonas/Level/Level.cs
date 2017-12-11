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
        private Block[] blocks;

        public Block[] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        public int Height { get; set; }
        public int Width { get; set; }

        public Level()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            // Iterate over list and draw all assets in spritebatch
            for (int i = 0; i < Blocks.Length; i++)
            {
                blocks[i].Draw(spritebatch);
            }
        }

        public void Add(Block[] blocks) => this.blocks = blocks;
    }
}

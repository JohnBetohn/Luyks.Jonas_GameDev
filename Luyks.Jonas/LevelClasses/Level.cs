using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
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
        public List<Enemy> Enemies { get; set; }
        public TileMap ActiveMap { get; set;  }
        public AIHandler AIHandler { get; set; }
        public Map Map { get; set; }

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
        public bool GoalReached { get; set; }
        public bool Finished { get; set; }

        public Level()
        {
            Map = new Map();
            SetActiveMap(0);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Draw(spritebatch);
            }
            for (int i = 0; i < Ladders.Count; i++)
            {
                Ladders[i].Draw(spritebatch);
            }
        }

        public List<Rectangle> GetLevelCollision()
        {
            List<Rectangle> Collision = new List<Rectangle>();
            for (int i = 0; i < Blocks.Count; i++)
            {
                Collision.Add(Blocks[i].CollisionRectangle);
            }
            return Collision;
        }

        public void SetActiveMap(int x)
        {
            switch (x)
            {
                case 0:
                    ActiveMap = Map.LevelMap1;
                    break;

                case 1:
                    ActiveMap = Map.LevelMap2;
                    break;
            }
        }

        public void LoadMap(Texture2D WallTexture, Texture2D FloorTexture, Texture2D LadderTexture)
        {
            Block Block;
            Ladder Ladder;
            for (int i = 0; i < ActiveMap.Map.GetLength(0); i++)
            {
                for (int j = 0; j < ActiveMap.Map.GetLength(1); j++)
                {
                    switch (ActiveMap.Map[i, j])
                    {
                        case 0:
                            break;

                        case 1:
                            Block = new Block(new Vector2(j * 50, i * 50));
                            if (i == 0)
                            {
                                Block.Texture = FloorTexture;
                            } else if (ActiveMap.Map[i - 1, j] == 0)
                            {
                                Block.Texture = FloorTexture;
                            } else
                            {
                                Block.Texture = WallTexture;
                            }
                            Blocks.Add(Block);
                            break;
                        case 2:
                            Ladder = new Ladder(new Vector2(j * 50, i * 50))
                            {
                                Texture = LadderTexture
                            };
                            Ladders.Add(Ladder);
                            break;
                    }
                }
            }
        }
    }
}

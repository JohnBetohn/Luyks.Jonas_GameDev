using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Luyks.Jonas
{
    class Level
    {
        public Texture2D EnemyTexture { get; set; }
        public List<Enemy> Enemies { get; set; }
        public TileMap ActiveMap { get; set;  }
        public Map Map { get; set; }
        public List<Node> Nodes { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

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
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spritebatch);
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

        public void SetActiveMap(int x, Texture2D WallTexture, Texture2D FloorTexture, Texture2D LadderTexture, Texture2D enemyTexture)
        {
            switch (x)
            {
                case 0:
                    ActiveMap = Map.LevelMap1;
                    Enemies = Map.EnemyList1;
                    break;

                case 1:
                    ActiveMap = Map.LevelMap2;
                    Enemies = Map.EnemyList2;
                    break;
            }
            Blocks = new List<Block>();
            Ladders = new List<Ladder>();
            Nodes = new List<Node>();
            EnemyTexture = enemyTexture;
            LoadMap(WallTexture, FloorTexture, LadderTexture, EnemyTexture);
            Width = ActiveMap.Map.GetLength(1) * 50;
            Height = ActiveMap.Map.GetLength(0) * 50;
        }

        public void LoadMap(Texture2D WallTexture, Texture2D FloorTexture, Texture2D LadderTexture, Texture2D EnemyTexture)
        {
            Block Block;
            Ladder Ladder;
            Node Node;
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
                                Node = new Node(new Vector2(j * 50, (i - 1) * 50));
                                Nodes.Add(Node);
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
                            Node = new Node(new Vector2(j * 50, i * 50));
                            Nodes.Add(Node);
                            if (ActiveMap.Map[i - 1, j] == 0)
                            {
                                Node = new Node(new Vector2(j * 50, (i - 1) * 50));
                                Nodes.Add(Node);
                            }
                            break;
                    }
                }
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                Debug.WriteLine(i + ". " + Nodes[i].Position);
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Texture = EnemyTexture;
            }
        }

        public void IssueCommands()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Command(i);
            }
        }

        public void Command(int i)
        {
            Vector2 destination = Enemies[i].Destinations[Enemies[i].CurrentDestination];
            Enemies[i].Controls.ResetMove();
            if (/*destination.Y == Enemies[i].Position.Y*/ true)
            {
                if(destination.X == Enemies[i].Position.X)
                {
                    Enemies[i].NextDestination();
                }
                else if (destination.X < Enemies[i].Position.X)
                {
                    Enemies[i].Controls.walkLeft = true;
                    Debug.WriteLine("I,m trying to go LEFT");
                }
                else
                {
                    Enemies[i].Controls.walkRight = true;
                    Debug.WriteLine("I,m trying to go RIGHT");
                }
            }
            //else if (destination.Y < Enemies[i].Position.Y)
            //{
            //    Enemies[i].Controls.Down = true;
            //    Debug.WriteLine("I,m trying to go DOWN");
            //}
            //else if (destination.Y > Enemies[i].Position.Y)
            //{
            //    Enemies[i].Controls.Up = true;
            //    Debug.WriteLine("I,m trying to go UP");
            //}

            #region Remnant of pathfinding code
            //if (FindFastestPathTo(enemy.CurrentDestination, enemy.CurrentNode, enemy))
            //{
            //    Node NextInPath = enemy.Path[enemy.Path.Count - 2];
            //    Node Current = enemy.CurrentNode;
            //    Debug.WriteLine("I am at" + Current.Position);
            //    Debug.WriteLine("Next step is" + NextInPath.Position);
            //    enemy.Controls.ResetMove();
            //    if (NextInPath.Position.X < Current.Position.X)
            //    {
            //        Debug.WriteLine("Hello < X");
            //        enemy.Controls.walkLeft = true;
            //    }
            //    if (NextInPath.Position.X > Current.Position.X)
            //    {
            //        Debug.WriteLine("Hello > X");
            //        enemy.Controls.walkRight = true;
            //    }
            //    if (NextInPath.Position.Y < Current.Position.Y)
            //    {
            //        Debug.WriteLine("Hello < Y");
            //        enemy.Controls.Down = true;
            //    }
            //    if (NextInPath.Position.Y > Current.Position.Y)
            //    {
            //        Debug.WriteLine("Hello > Y");
            //        enemy.Controls.Up = true;
            //    }
            //}
            #endregion
        }
    }
}

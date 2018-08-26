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

        private Texture2D WallTexture;
        private Texture2D FloorTexture;
        private Texture2D LadderTexture;
        private Texture2D enemyTexture;
        private Texture2D keyTexture;
        private Texture2D doorTextureTop;
        private Texture2D doorTexture;
        private Texture2D starTexture;
        private Texture2D toiletTexture;
        private Texture2D flagTexture;
        private Texture2D fenceTexture;

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

        private List<Star> stars = new List<Star>();

        public List<Star> Stars
        {
            get { return stars; }
            set { stars = value; }
        }

        private List<Door> doors = new List<Door>();

        public List<Door> Doors
        {
            get { return doors; }
            set { doors = value; }
        }

        private List<Block> fences;

        public List<Block> Fences
        {
            get { return fences; }
            set { fences = value; }
        }


        public Toilet Goal { get; set; }
        public Key key { get; set; }
        public Flag Flag { get; set; }
        public bool KeyCollected { get; set; }
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
            foreach (Door door in Doors)
            {
                door.Draw(spritebatch);
            }
            foreach (Star star in Stars)
            {
                star.Draw(spritebatch);
            }
            foreach (Block fence in Fences)
            {
                fence.Draw(spritebatch);
            }
            Goal.Draw(spritebatch);
            if (key != null)
            {
                key.Draw(spritebatch);
            }
            if (GoalReached)
            {
                Flag.Draw(spritebatch);
            }
        }

        public List<Rectangle> GetLevelCollision()
        {
            List<Rectangle> Collision = new List<Rectangle>();
            for (int i = 0; i < Blocks.Count; i++)
            {
                Collision.Add(Blocks[i].CollisionRectangle);
            }
            foreach (Door door in Doors)
            {
                Collision.Add(door.CollisionRectangle);
            }
            return Collision;
        }

        public void SetActiveMap(int x, Texture2D WallTexture, Texture2D FloorTexture, Texture2D LadderTexture, Texture2D enemyTexture, Texture2D keyTexture, Texture2D doorTextureTop, Texture2D doorTexture, Texture2D starTexture, Texture2D toiletTexture, Texture2D flagTexture, Texture2D fenceTexture)
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
            Fences = new List<Block>();
            Nodes = new List<Node>();
            KeyCollected = false;
            GoalReached = false;
            Finished = false;
            EnemyTexture = enemyTexture;

            this.WallTexture = WallTexture;
            this.FloorTexture = FloorTexture;
            this.LadderTexture = LadderTexture;
            this.keyTexture = keyTexture;
            this.doorTextureTop = doorTextureTop;
            this.doorTexture = doorTexture;
            this.starTexture = starTexture;
            this.toiletTexture = toiletTexture;
            this.flagTexture = flagTexture;
            this.fenceTexture = fenceTexture;

            LoadMap();
            Width = ActiveMap.Map.GetLength(1) * 50;
            Height = ActiveMap.Map.GetLength(0) * 50;
        }

        public void LoadMap()
        {
            Blocks = new List<Block>();
            Ladders = new List<Ladder>();
            Doors = new List<Door>();
            Nodes = new List<Node>();
            if (!KeyCollected)
            {
                stars = new List<Star>();
            }
            key = null;
            Block Block;
            Ladder Ladder;
            Toilet Toilet;
            Star Star;
            Door Door;
            Key Key;
            Block Fence;
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
                            } else if (ActiveMap.Map[i - 1, j] != 1)
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
                        case 3: //toilet
                            Toilet = new Toilet(new Vector2(j * 50, i * 50))
                            {
                                Texture = toiletTexture
                            };
                            Goal = Toilet;
                            break;
                        case 4: //end

                            break;
                        case 5: //key
                            if (!KeyCollected)
                            {
                                Key = new Key(new Vector2(j * 50, i * 50))
                                {
                                    Texture = keyTexture
                                };
                                key = Key;
                            }
                            break;
                        case 6: //star
                            if (!KeyCollected)
                            {
                                Star = new Star(new Vector2(j * 50, i * 50))
                                {
                                    Texture = starTexture
                                };
                                Stars.Add(Star);
                            }
                            break;
                        case 7: //door
                            if (!KeyCollected)
                            {
                                if (ActiveMap.Map[i + 1, j] == 7)
                                {
                                    Door = new Door(new Vector2(j * 50, i * 50))
                                    {
                                        Texture = doorTextureTop
                                    };
                                }
                                else
                                {
                                    Door = new Door(new Vector2(j * 50, i * 50))
                                    {
                                        Texture = doorTexture
                                    };
                                }
                                Doors.Add(Door);
                            }
                            break;
                        case 8:
                            Flag = new Flag(new Vector2(j * 50, i * 50))
                            {
                                Texture = flagTexture
                            };
                            break;
                        case 9:
                            Fence = new Block(new Vector2(j * 50, i * 50))
                            {
                                Texture = fenceTexture
                            };
                            Fences.Add(Fence);
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
            if(destination.X == Enemies[i].Position.X)
            {
                Enemies[i].NextDestination();
            }
            else if (destination.X < Enemies[i].Position.X)
            {
                Enemies[i].Controls.walkLeft = true;
            }
            else
            {
                Enemies[i].Controls.walkRight = true;
            }

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

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Map
    {
        public List<Enemy> EnemyList1 { get; set; }
        public List<Enemy> EnemyList2 { get; set; }

        private TileMap levelMap1;
        public TileMap LevelMap1
        {
            get { return levelMap1; }
            set { levelMap1 = value; }
        }

        private TileMap levelMap2;

        public TileMap LevelMap2
        {
            get { return levelMap2; }
            set { levelMap2 = value; }
        }

        public Map()
        {
            levelMap1 = new TileMap
            {

                Map = new int[,] {{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1},
                                  {1,6,0,0,0,0,0,0,0,0,0,0,0,7,6,1,0,6,1,1,1,1,1,0,5,1,0,0,0,0,0,0,0,1,1},
                                  {1,0,0,0,0,0,0,0,0,0,0,0,0,7,0,1,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1},
                                  {1,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,2,1,1,1,1,1,1,2,1,1,0,0,0,0,0,0,0,1,1},
                                  {1,1,1,2,1,1,1,1,1,1,1,1,2,0,0,0,2,0,0,0,0,6,1,2,0,0,0,0,0,0,0,0,0,1,1},
                                  {1,6,0,2,0,0,0,0,0,0,0,1,2,0,0,0,2,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,1,1},
                                  {1,0,0,2,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,2,2,1,1,1,1,1},
                                  {1,0,0,2,0,0,0,0,6,0,0,1,1,1,1,1,0,0,0,0,2,0,0,0,0,7,0,0,2,2,0,0,6,1,1},
                                  {1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,0,6,0,0,2,0,0,0,6,7,0,0,2,2,0,0,0,1,1},
                                  {1,0,0,0,0,0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,2,0,0,0,0,1,1,1,1,1,2,2,1,1,1},
                                  {1,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,2,0,0,1},
                                  {1,0,8,0,0,0,0,0,0,1,6,1,1,1,1,1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,2,0,0,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,7,0,0,0,0,0,0,0,0,0,0,2,2,1,1,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,0,7,0,0,0,0,0,0,0,0,0,0,2,2,1,1,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                        }
            };

            Vector2[] destinationsEnemy1 = new Vector2[] { new Vector2(150, 50 ), new Vector2(500, 50 ) };
            Enemy enemy1 = new Enemy(new Vector2(300, 150), destinationsEnemy1);
            Vector2[] destinationsEnemy2 = new Vector2[] { new Vector2(60, 350), new Vector2(270, 350) };
            Enemy enemy2 = new Enemy(new Vector2(100, 350), destinationsEnemy2);
            Vector2[] destinationsEnemy3 = new Vector2[] { new Vector2(640, 200), new Vector2(1030, 100) };
            Enemy enemy3 = new Enemy(new Vector2(630, 230), destinationsEnemy3);
            Vector2[] destinationsEnemy4 = new Vector2[] { new Vector2(820, 350), new Vector2(1630, 350) };
            Enemy enemy4 = new Enemy(new Vector2(800, 500), destinationsEnemy4);
            Vector2[] destinationsEnemy5 = new Vector2[] { new Vector2(1570, 350), new Vector2(1310, 350) };
            Enemy enemy5 = new Enemy(new Vector2(1410, 400), destinationsEnemy5);
            Vector2[] destinationsEnemy6 = new Vector2[] { new Vector2(820, 350), new Vector2(1630, 350) };
            Enemy enemy6 = new Enemy(new Vector2(1570, 520), destinationsEnemy6);
            Vector2[] destinationsEnemy7 = new Vector2[] { new Vector2(1020, 350), new Vector2(1480, 350) };
            Enemy enemy7 = new Enemy(new Vector2(1030, 670), destinationsEnemy7);

            EnemyList1 = new List<Enemy>();
            EnemyList1.Add(enemy1);
            EnemyList1.Add(enemy2);
            EnemyList1.Add(enemy3);
            EnemyList1.Add(enemy4);
            EnemyList1.Add(enemy5);
            EnemyList1.Add(enemy6);
            EnemyList1.Add(enemy7);

            levelMap2 = new TileMap
            {
                Map = new int[,] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                  {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,8},
                                  {1,1,1,1,1,1,1,1,1,1,1,7,7,7,7,7,1,1,1,1,1,1,1,1,1,1,1},
                                  {1,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,1},
                                  {1,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,1,0,0,0,0,0,0,0,0,3,1},
                                  {1,1,1,2,1,1,1,2,0,0,1,2,2,2,2,2,1,0,0,0,0,0,1,1,1,1,1},
                                  {1,0,0,2,0,0,1,0,0,0,1,2,2,2,2,2,1,2,1,1,1,1,1,0,0,0,1},
                                  {1,0,0,2,0,0,1,0,0,0,1,2,2,2,2,2,1,2,0,0,0,0,0,0,0,0,1},
                                  {1,1,1,2,1,1,1,0,0,0,1,2,2,2,2,2,1,2,0,0,0,0,0,0,0,0,1},
                                  {1,0,0,2,0,0,1,1,0,0,1,2,2,2,2,2,1,2,0,0,0,0,0,0,0,0,1},
                                  {1,0,0,2,0,0,1,0,0,0,1,2,2,2,2,2,1,1,1,0,0,1,0,0,1,2,1},
                                  {1,1,1,2,1,1,1,0,0,1,1,2,2,2,2,2,1,0,0,0,0,0,0,0,0,2,1},
                                  {1,0,0,2,0,0,1,0,0,0,1,2,2,2,2,2,1,0,0,0,0,0,0,0,0,2,1},
                                  {1,0,0,2,0,0,1,0,0,0,1,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,1},
                                  {1,1,1,2,1,1,1,1,0,0,1,2,2,2,2,2,1,0,1,0,1,0,1,0,0,0,1},
                                  {1,5,0,2,0,0,1,0,0,0,0,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,1},
                                  {1,0,0,2,0,0,1,0,0,0,0,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1,2,1},
                                  {1,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,7,0,0,0,0,0,0,0,0,2,1},
                                  {1,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,7,0,0,0,0,0,0,0,0,2,1},
                                  {1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1},
                                        }
            };

            Vector2[] destinationsEnemy8 = new Vector2[] { new Vector2(60, 50), new Vector2(240, 50) };
            Enemy enemy8 = new Enemy(new Vector2(60, 410), destinationsEnemy8)
            {
                WalkSpeedx = 2
            };
            Enemy enemy9 = new Enemy(new Vector2(160, 520), destinationsEnemy8);
            Enemy enemy10 = new Enemy(new Vector2(160, 680), destinationsEnemy8)
            {
                WalkSpeedx = 2
            };
            Vector2[] destinationsEnemy11 = new Vector2[] { new Vector2(900, 50), new Vector2(1190, 50) };
            Enemy enemy11 = new Enemy(new Vector2(900, 800), destinationsEnemy11);

            EnemyList2 = new List<Enemy>();
            EnemyList2.Add(enemy8);
            EnemyList2.Add(enemy9);
            EnemyList2.Add(enemy10);
            EnemyList2.Add(enemy11);
        }

    }
}

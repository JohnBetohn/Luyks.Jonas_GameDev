using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class AIHandler
    {
        public List<Enemy> EnemyList { get; set; }
        public Vector2 PlayerPosition { get; set; }
        public List<Node> Nodes { get; set; }

        public void CurrentNode()
        {
            // find currentNode of certain enemy
        }

        public bool FindFastetPathTo(Node Destination, Node _current)
        {
            //Console.WriteLine("Now I will search for a path.");
            Node Current = _current;
            if (Current != null)
            {
                Current.GScore = 0;
                Current.FScore = Estimate(Current, Destination);


                List<Node> ClosedSet = new List<Node>();

                List<Node> OpenSet = new List<Node>
                {

                    return true;
                }

                OpenSet.Remove(Current);
                ClosedSet.Add(Current);

                while (OpenSet.Count > 0)
                {
                    Node neighbor = Current.Neighbors[i];
                    Console.WriteLine("Checking neighbors...");
                    if (!ClosedSet.Contains(neighbor) && !OpenSet.Contains(neighbor))
                    {
                        enemy.Path = ReconstructPath(Current.CameFrom, Current);
                        Console.WriteLine("I has Found Se PAths");
                        return true;
                    }

                    OpenSet.Remove(Current);
                    ClosedSet.Add(Current);

                    for (int i = 0; i < Current.Neighbors.Count; i++)
                    {
                        Node neighbor = Current.Neighbors[i];
                        Console.WriteLine("Checking neighbors...");
                        if (!ClosedSet.Contains(neighbor) && !OpenSet.Contains(neighbor))
                        {
                            OpenSet.Add(neighbor);
                        }

                        double temp_GScore = Current.GScore + 50;
                        if (temp_GScore < neighbor.GScore)
                        {
                            //Console.WriteLine("Checking if viable path");
                            neighbor.CameFrom = Current;
                            neighbor.GScore = temp_GScore;
                            neighbor.FScore = temp_GScore + Estimate(neighbor, Destination);
                        }
                    }
                }
            }

            return false;

        }

        public bool MoveToNode(Node Pathstep)
        {
            return true;
        }

        public double Estimate(Node current, Node destination)
        {
            double est;
            double x = (int)current.Position.X - (int)destination.Position.X;
            double y = (int)current.Position.Y - (int)destination.Position.Y;
            est = Math.Sqrt( x + y );
            return est;
        }

        public List<Node> ReconstructPath(int Camefrom, Node End)
        {
            List<Node> Path = new List<Node>();
            Node Current = End;
            Path.Add(End);
            while (Current.CameFrom != null)
            {
                Current = Current.CameFrom;
                Path.Add(Current);
            }
            Console.WriteLine(Path.Count);
            return Path;
        }

        public Node FindClosest(List<Node> OpenSet)
        {
            double lowest = 999999;
            Node winner = null;
            for (int i = 0; i < OpenSet.Count; i++)
            {
                if (OpenSet[i].FScore < lowest)
                {
                    lowest = OpenSet[i].FScore;
                    winner = OpenSet[i];
                }
            }
            return winner;
        }

        public void IssueCommands()
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                Command(EnemyList[i]);
            }
        }

        public void Command(Enemy enemy)
        {
            if (FindFastestPathTo(enemy.CurrentDestination, enemy.CurrentNode, enemy))
            {
                Node NextInPath = enemy.Path[enemy.Path.Count - 2];
                Node Current = enemy.CurrentNode;
                Console.WriteLine("I am at" + Current.Position);
                Console.WriteLine("Next step is" + NextInPath.Position);
                enemy.Controls.ResetMove();
                if (NextInPath.Position.X < Current.Position.X)
                {
                    Console.WriteLine("Hello < X");
                    enemy.Controls.walkLeft = true;
                }
                if (NextInPath.Position.X > Current.Position.X)
                {
                    Console.WriteLine("Hello > X");
                    enemy.Controls.walkRight = true;
                }
                if (NextInPath.Position.Y < Current.Position.Y)
                {
                    Console.WriteLine("Hello < Y");
                    enemy.Controls.Down = true;
                }
                if (NextInPath.Position.Y > Current.Position.Y)
                {
                    Console.WriteLine("Hello > Y");
                    enemy.Controls.Up = true;
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    public class Node
    {
        public double GScore { get; set; }

        public double FScore { get; set; }

        public Node CameFrom { get; set; }

        public Vector2 Position { get; set; }

        private Rectangle nodeSize;

        public Rectangle NodeSize
        {
            get { return nodeSize; }
            set { nodeSize = value; }
        }

        public List<Node> Neighbors { get; set; }

        public Node(Vector2 position)
        {
            Position = position;
            nodeSize = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
            FScore = 9999;
            GScore = 9999;
            Neighbors = new List<Node>();
        }

        public void FindNeighbor(List<Node> Nodes)
        {
            Console.WriteLine(Position + " Is searching for neighbors...");
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (IsNeighbor(Nodes[i]))
                {
                    Console.WriteLine("Found One! " + Nodes[i].Position + " is a neighbor!");
                    Neighbors.Add(Nodes[i]);
                }
            }
        }

        public bool IsNeighbor(Node potNeighbor)
        {
            if ((potNeighbor.Position.X - 50 == Position.X && potNeighbor.Position.Y == Position.Y) || (potNeighbor.Position.X + 50 == Position.X && potNeighbor.Position.Y == Position.Y)) {
                return true;
            }
            if((potNeighbor.Position.Y + 50 == Position.Y && potNeighbor.Position.X == Position.X) || (potNeighbor.Position.Y - 50 == Position.Y && potNeighbor.Position.X == Position.X))
            {
                return true;
            }
            return false;
        }
    }
}

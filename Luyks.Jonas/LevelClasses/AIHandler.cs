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
        public List<int[,]> Destinations { get; set; }
    }
}

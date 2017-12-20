﻿using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class CollisionManager
    {
        public List<Rectangle> CollisionRectangles { get; set; }
        public bool HasCollLeft { get; set; }
        public bool HasCollRight { get; set; }
        public bool HasCollBot { get; set; }
        public bool HasCollTop { get; set; }
        public CollisionManager(List<Rectangle> collisionRectangles)
        {
            CollisionRectangles = new List<Rectangle>();
            for (int i = 0; i < collisionRectangles.Count; i++)
            {
                this.CollisionRectangles.Add(collisionRectangles[i]);
            }
            ResetColl();
        }

        public Rectangle CheckCollsionHorizontal(Rectangle CollisionRectangle)
        {
            for (int i = 0; i < CollisionRectangles.Count; i++)
            {
                if (CollisionRight(CollisionRectangle, CollisionRectangles[i]))
                {
                    HasCollRight = true;
                    return CollisionRectangles[i];
                }
                
                if (CollisionLeft(CollisionRectangle, CollisionRectangles[i]))
                {
                    HasCollLeft = true;
                    return CollisionRectangles[i];
                }
            }
            return new Rectangle(0,0,0,0);
        }

        public Rectangle CheckCollisionVertical(Rectangle CollisionRectangle)
        {
            for (int i = 0; i < CollisionRectangles.Count; i++)
            {
                if (CollisionTop(CollisionRectangle, CollisionRectangles[i]))
                {
                    HasCollTop = true;
                    return CollisionRectangles[i];
                }

                if (CollisionBottom(CollisionRectangle, CollisionRectangles[i]))
                {
                    HasCollBot = true;
                    return CollisionRectangles[i];
                }
            }
            return new Rectangle(0, 0, 0, 0);

        }

        public bool CollisionLeft(Rectangle OwnCollRect, Rectangle OtherCollRect)
        {
            if (OwnCollRect.Left <= OtherCollRect.Right && OwnCollRect.Left >= OtherCollRect.Right - OtherCollRect.Width / 3 && OwnCollRect.Bottom >= OtherCollRect.Top + 5 && OwnCollRect.Top <= OtherCollRect.Bottom)
            {
                return true;
            }
            return false;
        }

        public bool CollisionRight(Rectangle OwnCollRect, Rectangle OtherCollRect)
        {
            if (OwnCollRect.Right >= OtherCollRect.Left && OwnCollRect.Right <= OtherCollRect.Left + OtherCollRect.Width / 3 && OwnCollRect.Bottom >= OtherCollRect.Top + 5 && OwnCollRect.Top <= OtherCollRect.Bottom)
            {
                return true;
            }
            return false;
        }

        public bool CollisionTop(Rectangle OwnCollRect, Rectangle OtherCollRect)
        {
            if (OwnCollRect.Top <= OtherCollRect.Bottom && OwnCollRect.Top >= OtherCollRect.Bottom - OtherCollRect.Height / 3 && OwnCollRect.Left <= OtherCollRect.Right /*- OtherCollRect.Width / 4*/ && OwnCollRect.Right >= OtherCollRect.Left /*+ OtherCollRect.Width / 4*/)
            {
                return true;
            }
            return false;
        }

        public bool CollisionBottom(Rectangle OwnCollRect, Rectangle OtherCollRect)
        {
            if (OwnCollRect.Bottom >= OtherCollRect.Top && OwnCollRect.Bottom <= OtherCollRect.Top + OtherCollRect.Height / 3 && OwnCollRect.Left <= OtherCollRect.Right /*- OtherCollRect.Width / 4*/ && OwnCollRect.Right >= OtherCollRect.Left /*+ OtherCollRect.Width / 4*/)
            {
                return true;
            }
            return false;
        }

        public void ResetColl()
        {
            HasCollBot = false;
            HasCollLeft = false;
            HasCollRight = false;
            HasCollTop = false;
        }

    }
}

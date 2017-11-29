using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Player
    {
        //Properties
        private Texture2D edTexture;

        public Texture2D EdTexture
        {
            get { return edTexture; }
            set { edTexture = value; }
        }

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int speedx;

        public int Speedx
        {
            get { return speedx; }
            set { speedx = value; }
        }

        private Animation run; //running animation

        #region Movement Properties

        private bool moveLeft;

        public bool MoveLeft
        {
            get { return moveLeft; }
            set { moveLeft = value; }
        }

        private bool moveRight;

        public bool MoveRight
        {
            get { return moveRight; }
            set { moveRight = value; }
        }

        #endregion

        public Player()
        {
            
        }
        
        public void CkeckInputs()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Q))
            {
                moveLeft = true;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                moveRight = true;
            }
            //if (stateKey.IsKeyUp(Keys.Left))
            //{
            //    left = false;
            //}
            //if (stateKey.IsKeyUp(Keys.Right))
            //{
            //    right = false;
            //}
            //if (stateKey.IsKeyDown(Keys.Space))
            //{
            //    ChangeState(jumping);
            //    jump = true;
            //    startJump = true;
            //}
        }

        public void Move()
        {
            if (moveLeft)
            {
                x = x - speedx;
            }

            if (moveRight)
            {
                x = x + speedx;
            }

            ResetMove();
        }

        public void ResetMove()
        {
            moveRight = false;
            moveLeft = false;
        }

    }
}

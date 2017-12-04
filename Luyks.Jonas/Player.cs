using Microsoft.Xna.Framework;
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


        #region Movement Properties

        private bool walkLeft;

        public bool WalkLeft
        {
            get { return walkLeft; }
            set { walkLeft = value; }
        }

        private bool walkRight;

        public bool WalkRight
        {
            get { return walkRight; }
            set { walkRight = value; }
        }

        private int walkspeedx = 5;

        public int WalkSpeedx
        {
            get { return walkspeedx; }
            set { walkspeedx = value; }
        }

        #endregion

        public Player()
        {
            initAnimations();
        }
        
        public void CkeckInputs()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Q))
            {
                walkLeft = true;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                walkRight = true;
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

        public void Move(GameTime gameTime)
        {
            if (walkLeft)
            {
                x = x - walkspeedx;
            }

            if (walkRight)
            {
                x = x + walkspeedx;
                walk.Update(gameTime);
            }

            ResetMove();
        }

        public void ResetMove()
        {
            walkRight = false;
            walkLeft = false;
        }

        #region Animations

        private List<Animation> animations = new List<Animation>();

        public List<Animation> Animations
        {
            get { return animations; }
            set { animations = value; }
        }


        private Animation stance = new Animation();
        private Animation turning = new Animation();
        private Animation walk = new Animation();
        private Animation walkslide = new Animation();
        private Animation run = new Animation();
        private Animation runslide = new Animation();
        private Animation ladder = new Animation();
        private Animation waiting = new Animation();
        private Animation jump = new Animation();
        private Animation falling = new Animation();
        private Animation hardhitfloor = new Animation();
        private Animation dizzy = new Animation();
        private Animation gettingup = new Animation();
        private Animation died = new Animation();
        
        protected void initAnimations()
        {
            walk.AddFrame(new Rectangle(11, 125, 44, 60));
            walk.AddFrame(new Rectangle(55, 125, 49, 60));
            walk.AddFrame(new Rectangle(104, 125, 55, 60));
            walk.AddFrame(new Rectangle(159, 125, 49, 60));
            walk.AddFrame(new Rectangle(208, 125, 48, 60));
            walk.AddFrame(new Rectangle(256, 125, 43, 60));
            walk.AddFrame(new Rectangle(299, 125, 44, 60));
            walk.AddFrame(new Rectangle(343, 125, 45, 60));
            walk.AddFrame(new Rectangle(392, 125, 42, 60));
            walk.FramesPerSecond = 15;
        }

        #endregion


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EdTexture, new Vector2(x, 250), walk.CurrentFrame.SourceRectangle, Color.White);
        }

    }
}

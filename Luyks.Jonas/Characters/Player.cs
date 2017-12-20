using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Player : Character
    {
        //Properties
        private CollisionManager collManager;

        public CollisionManager CollManager
        {
            get { return collManager; }
            set { collManager = value; }
        }


        #region Movement

        public Controls Controls { get; set; }

        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public override void HandleCollision(GameTime gameTime)
        {
            Rectangle collidedV = CollManager.CheckCollisionVertical(CollisionRectangle);
            Rectangle collidedH = CollManager.CheckCollsionHorizontal(CollisionRectangle);

            if (CollManager.HasCollLeft)
            {
                position.X = collidedH.Right;
            }

            if (CollManager.HasCollRight)
            {
                position.X = collidedH.Left - CollisionRectangle.Width;
            }

            if (CollManager.HasCollTop)
            {
                position.Y = collidedV.Bottom;
                SpeedY = 0;
            }

            if (CollManager.HasCollBot)
            {
                Controls.Falling = false;
                position.Y = collidedV.Top - CollisionRectangle.Height;
            }
            
            if (!CollManager.HasCollBot)
            {
                if (!Controls.Falling)
                {
                    Controls.LastTouch = gameTime.ElapsedGameTime.TotalSeconds;
                }
                Controls.Falling = true;                
            }
        }

        #endregion

        public Player(Vector2 position)
        {
            Position = position;
            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 50, 60);
            WalkSpeedx = 5;
            RunSpeedx = 10;
            SpeedY = 0;
            FallSpeed = 1;
            initAnimations();
            SetActiveAnimation(0);
        }

        public void Move(GameTime gameTime)
        {
            Controls.CheckInputs();

            if (Controls.walkLeft)
            {
                position.X = Position.X - WalkSpeedx;
                SetActiveAnimation(2);
                activeAnimation.Update(gameTime);
            }

            if (Controls.walkRight)
            {
                position.X = Position.X + WalkSpeedx;
                SetActiveAnimation(2);
                activeAnimation.Update(gameTime);
            }

            if (Controls.runLeft)
            {
                position.X = Position.X - RunSpeedx;
                SetActiveAnimation(4);
                activeAnimation.Update(gameTime);
            }

            if (Controls.runRight)
            {
                position.X = Position.X + RunSpeedx;
                SetActiveAnimation(4);
                activeAnimation.Update(gameTime);
            }

            if (Controls.Jump && !Controls.Falling && SpeedY != -15)
            {
                SpeedY = -15;
                position.Y = position.Y + SpeedY;
            }

            if (Controls.Falling)
            {
                if (SpeedY < 15)
                {
                    SpeedY = SpeedY + FallSpeed;
                }
                position.Y = position.Y + SpeedY;
            }

            if (!Controls.Falling && SpeedY >= 0)
            {
                SpeedY = 0;
            }

            if (!Controls.runRight && !Controls.walkRight && !Controls.runLeft && !Controls.walkLeft)
            {
                SetActiveAnimation(0);
            }

            MoveCollisionRectangle();
        }

        public void MoveCollisionRectangle()
        {
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
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
            animations.Add(stance);
            animations.Add(turning);
            animations.Add(walk);
            animations.Add(walkslide);
            animations.Add(run);
            animations.Add(ladder);
            animations.Add(waiting);
            animations.Add(jump);
            animations.Add(falling);
            animations.Add(hardhitfloor);
            animations.Add(dizzy);
            animations.Add(gettingup);
            animations.Add(died);

            stance.AddFrame(new Rectangle(14, 36, 36, 57));

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

            run.AddFrame(new Rectangle(12, 210, 50, 50));
            run.AddFrame(new Rectangle(73, 210, 47, 50));
            run.AddFrame(new Rectangle(127, 210, 53, 50));
            run.AddFrame(new Rectangle(187, 210, 50, 50));
            run.AddFrame(new Rectangle(260, 210, 56, 50));
            run.AddFrame(new Rectangle(324, 210, 47, 50));
            run.AddFrame(new Rectangle(440, 210, 50, 50));
            run.AddFrame(new Rectangle(502, 210, 59, 50));
            run.AddFrame(new Rectangle(568, 210, 58, 50));
            run.FramesPerSecond = 15;

        }

        private Animation activeAnimation;

        public Animation ActiveAnimation
        {
            get { return activeAnimation; }
            set { activeAnimation = value; }
        }

        public void SetActiveAnimation(int x)
        {
            activeAnimation = animations[x];
        }

        #endregion


        public void Draw(SpriteBatch spriteBatch)
        {
            if (Controls.walkLeft || Controls.runLeft)
            {
                spriteBatch.Draw(Texture, Position, null, activeAnimation.CurrentFrame.SourceRectangle, null, 0, null, Color.White, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, activeAnimation.CurrentFrame.SourceRectangle, Color.White);
            }

        }

    }
}

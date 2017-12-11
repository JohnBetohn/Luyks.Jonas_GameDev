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
    class Player : Character , ICollide
    {
        //Properties
        private Rectangle collisionRectangle;

        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            set { collisionRectangle = value; }
        }

        #region Movement Properties

        public Controls controls { get; set; }

        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        public Player()
        {
            Position = new Vector2(10, 250);
            walkSpeedx = 5;
            runSpeedx = 10;
            initAnimations();
            setActiveAnimation(0);
        }

        public void Move(GameTime gameTime)
        {
            controls.CheckInputs();

            if (controls.walkLeft)
            {
                position.X = Position.X - walkSpeedx;
                setActiveAnimation(2);
                activeAnimation.Update(gameTime);
            }

            if (controls.walkRight)
            {
                position.X = Position.X + walkSpeedx;
                setActiveAnimation(2);
                activeAnimation.Update(gameTime);
            }

            if (controls.runLeft)
            {
                position.X = Position.X - runSpeedx;
                setActiveAnimation(4);
                activeAnimation.Update(gameTime);
            }

            if (controls.runRight)
            {
                position.X = Position.X + runSpeedx;
                setActiveAnimation(4);
                activeAnimation.Update(gameTime);
            }

            if (!controls.runRight && !controls.walkRight && !controls.runLeft && !controls.walkLeft)
            {
                setActiveAnimation(0);
            }
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

        public void setActiveAnimation(int x)
        {
            activeAnimation = animations[x];
        }

        #endregion


        public void Draw(SpriteBatch spriteBatch)
        {
            if(controls.walkLeft || controls.runLeft)
            {
                spriteBatch.Draw(texture, Position, null, activeAnimation.CurrentFrame.SourceRectangle, null, 0, null, Color.White, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(texture, Position, activeAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
                
        }

        public Rectangle GetCollisionRectangle()
        {
            return collisionRectangle;
        }

    }
}

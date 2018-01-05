using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Luyks.Jonas
{
    public abstract class Character
    {
        public Texture2D Texture { get; set; }

        public int WalkSpeedx { get; set; }
        public int RunSpeedx { get; set; }
        public int FallSpeed { get; set; }
        public int ClimbSpeed { get; set; }
        public int SpeedY { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Controls Controls { get; set; }
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private CollisionManager collManager;

        public CollisionManager CollManager
        {
            get { return collManager; }
            set { collManager = value; }
        }

        private List<Animation> animations = new List<Animation>();

        public List<Animation> Animations
        {
            get { return animations; }
            set { animations = value; }
        }

        public Animation ActiveAnimation { get; set; }

        public abstract void HandleCollision(GameTime gameTime);
        public abstract void InitAnimations();
        public void SetActiveAnimation(int x)
        {
            ActiveAnimation = animations[x];
        }

        public void Move(GameTime gameTime)
        {
            Controls.CheckInputs();

            if (Controls.walkLeft)
            {
                position.X = Position.X - WalkSpeedx;
                SetActiveAnimation(2);
                ActiveAnimation.Update(gameTime);
            }

            if (Controls.walkRight)
            {
                position.X = Position.X + WalkSpeedx;
                SetActiveAnimation(2);
                ActiveAnimation.Update(gameTime);
            }

            if (Controls.RunLeft)
            {
                position.X = Position.X - RunSpeedx;
                SetActiveAnimation(4);
                ActiveAnimation.Update(gameTime);
            }

            if (Controls.RunRight)
            {
                position.X = Position.X + RunSpeedx;
                SetActiveAnimation(4);
                ActiveAnimation.Update(gameTime);
            }

            if (Controls.Jump && !Controls.Falling && SpeedY >= 0)      // Jump only when you are not in the air
            {
                SpeedY = -15;
                position.Y = position.Y + SpeedY;
            }

            if (Controls.Falling && !Controls.OnLadder)
            {
                if (SpeedY < 15)                    // Stop accelerating after SpeedY >= 15
                {
                    SpeedY = SpeedY + FallSpeed;
                    //SetActiveAnimation(7);
                }
                position.Y = position.Y + SpeedY;
            }

            if (!Controls.Falling && SpeedY >= 0) // Stop falling, you're on the ground
            {
                SpeedY = 0;
            }

            if (!Controls.RunRight && !Controls.walkRight && !Controls.RunLeft && !Controls.walkLeft)  // Stand still
            {
                SetActiveAnimation(0);
            }

            if (Controls.Up && Controls.OnLadder)
            {
                position.Y = position.Y - ClimbSpeed;
            }

            if (Controls.Down && Controls.OnLadder)
            {
                position.Y = position.Y + ClimbSpeed;
            }
        }

        public void MoveCollisionRectangle()
        {
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, ActiveAnimation.CurrentFrame.SourceRectangle.Width, ActiveAnimation.CurrentFrame.SourceRectangle.Height);
        }

        public abstract void Update(GameTime gameTime);
    }
}

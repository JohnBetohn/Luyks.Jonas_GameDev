using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Player : Character
    {
        #region Movement

        public override void HandleCollision(GameTime gameTime)
        {
            Rectangle collidedV = CollManager.CheckCollisionVertical(CollisionRectangle);
            Rectangle collidedH = CollManager.CheckCollsionHorizontal(CollisionRectangle);
            Controls.OnLadder = CollManager.CheckLadder(CollisionRectangle);

            if (CollManager.HasCollLeft)
            {
                Position = new Vector2(collidedH.Right + 5, Position.Y);
            }

            if (CollManager.HasCollRight)
            {
                Position = new Vector2(collidedH.Left - CollisionRectangle.Width + 5, Position.Y);
            }

            if (CollManager.HasCollTop)
            {
                Position = new Vector2(Position.X, collidedV.Bottom);
                SpeedY = 0;
            }

            if (CollManager.HasCollBot)
            {
                Controls.Falling = false;
                Position = new Vector2(Position.X, collidedV.Top - CollisionRectangle.Height);
            }
            
            if (!CollManager.HasCollBot && !Controls.OnLadder)
            {
                Controls.Falling = true;                
            }
        }

        public override void Update(GameTime gameTime, List<Node> Nodes)
        {
            FindCurrentNode(Nodes);
            Move(gameTime);
            MoveCollisionRectangle();
            HandleCollision(gameTime);
            CollManager.ResetColl();
        }

        #endregion

        public Player(Vector2 position)
        {
            Position = position;
            WalkSpeedx = 3;
            ClimbSpeed = 3;
            RunSpeedx = 6;
            SpeedY = 0;
            FallSpeed = 1;
            InitAnimations();
            SetActiveAnimation(0);
            Controls = new ControlsWASD();
        }
        #region Animations

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

        public override void InitAnimations()
        {
            Animations.Add(stance);
            Animations.Add(turning);
            Animations.Add(walk);
            Animations.Add(walkslide);
            Animations.Add(run);
            Animations.Add(ladder);
            Animations.Add(waiting);
            Animations.Add(jump);
            Animations.Add(falling);
            Animations.Add(hardhitfloor);
            Animations.Add(dizzy);
            Animations.Add(gettingup);
            Animations.Add(died);

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



            jump.AddFrame(new Rectangle(18, 468, 48, 53));
            jump.AddFrame(new Rectangle(65, 467, 48, 54));
            jump.AddFrame(new Rectangle(118, 468, 53, 34));
            jump.AddFrame(new Rectangle(186, 467, 48, 44));
            jump.FramesPerSecond = 4;
        }
        #endregion


        public void Draw(SpriteBatch spriteBatch)
        {
            if (Controls.walkLeft || Controls.RunLeft)
            {
                spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: ActiveAnimation.CurrentFrame.SourceRectangle, color: Color.White, effects: SpriteEffects.FlipHorizontally);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, ActiveAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
        }

    }
}

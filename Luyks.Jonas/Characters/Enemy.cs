using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Enemy : Character
    {
        public List<Node> Destinations { get; set; }
        public Node Current {get; set; }
        public Enemy(Vector2 position)
        {
            Position = position;
            WalkSpeedx = 3;
            ClimbSpeed = 3;
            FallSpeed = 1;
            SpeedY = 0;
            Controls = new ControlsAI();
            InitAnimations();
        }

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

        public new void MoveCollisionRectangle()
        {
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)(ActiveAnimation.CurrentFrame.SourceRectangle.Width * 0.66), (int)(ActiveAnimation.CurrentFrame.SourceRectangle.Height * 0.66));
        }
        #endregion

        #region Animations
        private Animation stance = new Animation();
        private Animation walk = new Animation();
        private Animation ladder = new Animation();
        private Animation looking = new Animation();
        private Animation jump = new Animation();
        private Animation falling = new Animation();
        private Animation hardhitfloor = new Animation();
        private Animation dudanimation = new Animation();

        public override void InitAnimations()
        {
            Animations.Add(stance);
            Animations.Add(dudanimation);
            Animations.Add(walk);
            Animations.Add(dudanimation);
            Animations.Add(dudanimation);
            Animations.Add(ladder);
            Animations.Add(looking);
            Animations.Add(jump);

            stance.AddFrame(new Rectangle(0, 190, 66, 92));
            stance.FramesPerSecond = 1;

            walk.AddFrame(new Rectangle(3, 1, 66, 91));
            walk.AddFrame(new Rectangle(75, 1, 66, 90));
            walk.AddFrame(new Rectangle(146, 0, 66, 90));
            walk.AddFrame(new Rectangle(1, 95, 69, 88));
            walk.AddFrame(new Rectangle(72, 95, 69, 89));
            walk.AddFrame(new Rectangle(143, 96, 68, 89));
            walk.AddFrame(new Rectangle(215, 1, 66, 92));
            walk.AddFrame(new Rectangle(285, 2, 67, 92));
            walk.AddFrame(new Rectangle(1, 95, 69, 88));
            walk.AddFrame(new Rectangle(1, 95, 69, 88));
            walk.AddFrame(new Rectangle(357, 2, 66, 92));
            walk.FramesPerSecond = 15;

            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(67, 190, 66, 91));
            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.AddFrame(new Rectangle(0, 190, 66, 92));
            looking.FramesPerSecond = 8;

        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            MoveCollisionRectangle();
            HandleCollision(gameTime);
            CollManager.ResetColl();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Controls.walkLeft)
            {
                spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: ActiveAnimation.CurrentFrame.SourceRectangle, color: Color.White, effects: SpriteEffects.FlipHorizontally, scale: new Vector2((float)0.66, (float)0.66));
            }
            else
            {
                spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: ActiveAnimation.CurrentFrame.SourceRectangle, color: Color.White, scale: new Vector2((float)0.66, (float)0.66));
            }
        }
    }
}

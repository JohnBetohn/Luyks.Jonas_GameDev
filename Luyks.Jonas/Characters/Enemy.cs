using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas.Characters
{
    class Enemy : Character
    {
        private CollisionManager collManager;

        public CollisionManager CollManager
        {
            get { return collManager; }
            set { collManager = value; }
        }

        public ControlsAI Controls { get; set; }

        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Enemy(Vector2 position)
        {
            Position = position;
            WalkSpeedx = 3;
            ClimbSpeed = 3;
            SpeedY = 0;
            FallSpeed = 1;
        }

        #region Movement
        public void Move()
        {

        }

        public void MoveCollisionRectangle()
        {

        }

        public override void HandleCollision(GameTime gameTime)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Animations
        public Animation ActiveAnimation { get; set; }
        public List<Animation> Animations { get; set; }

        private Animation stance = new Animation();
        private Animation walk = new Animation();
        private Animation ladder = new Animation();
        private Animation looking = new Animation();
        private Animation jump = new Animation();
        private Animation falling = new Animation();
        private Animation hardhitfloor = new Animation();

        public override void InitAnimations()
        {
            Animations.Add(stance);
            Animations.Add(walk);
            Animations.Add(ladder);
            Animations.Add(looking);

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

        public override void SetActiveAnimation(int x)
        {
            ActiveAnimation = Animations[x];
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Controls.walkLeft)
            {
                spriteBatch.Draw(texture: Texture, position: Position, sourceRectangle: ActiveAnimation.CurrentFrame.SourceRectangle, color: Color.White, effects: SpriteEffects.FlipHorizontally, scale: new Vector2((float)0.66, (float)0.66));
            }
            else
            {
                spriteBatch.Draw(Texture, Position, ActiveAnimation.CurrentFrame.SourceRectangle, color: Color.White, scale: new Vector2((float)0.66, (float)0.66));
            }
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Luyks.Jonas
{
    public class Animation
    {
        public List<Animation_Frame> frames;
        public Animation_Frame CurrentFrame { get; set; }
        public int FramesPerSecond { get; set; }

        public bool AnimationComplete { get; set; }

        public int counter = 0;

        public double x = 0;

        public int _totalWidth = 0;

        public Animation()
        {
            frames = new List<Animation_Frame>();
            FramesPerSecond = 1;
        }
        public void AddFrame(Rectangle rectangle)
        {
            Animation_Frame newFrame = new Animation_Frame()
            {
                SourceRectangle = rectangle
            };

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            foreach (Animation_Frame f in frames)
                _totalWidth += f.SourceRectangle.Width;
        }


        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceRectangle.Width / FramesPerSecond)
            {
                Debug.WriteLine(x);
                x = 0;
                counter++;
                AnimationComplete = false;
                if (counter >= frames.Count)
                {
                    counter = 0;
                    AnimationComplete = true;
                } 
                CurrentFrame = frames[counter];
            }
        }
    }
}

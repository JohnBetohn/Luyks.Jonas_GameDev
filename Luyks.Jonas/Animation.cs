using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    class Animation
    {
        private List<Animation_Frame> frames;
        public Animation_Frame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconde { get; set; }

        private int counter = 0;

        private double x = 0;
        public double offset { get; set; }

        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<Animation_Frame>();
            AantalBewegingenPerSeconde = 1;
        }
        public void AddFrame(Rectangle rectangle)
        {
            Animation_Frame newFrame = new Animation_Frame()
            {
                SourceRectangle = rectangle,
                //Duration = duration
            };

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            offset = CurrentFrame.SourceRectangle.Width;
            foreach (Animation_Frame f in frames)
                _totalWidth += f.SourceRectangle.Width;
        }


        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceRectangle.Width / AantalBewegingenPerSeconde)
            {
                Console.WriteLine(x);
                x = 0;
                counter++;
                if (counter >= frames.Count)
                    counter = 0;
                CurrentFrame = frames[counter];
                offset += CurrentFrame.SourceRectangle.Width;
            }
            if (offset >= _totalWidth)
                offset = 0;


        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyks.Jonas
{
    public abstract class Controls
    {
        public bool walkLeft { get; set; }
        public bool walkRight { get; set; }
        public bool runLeft { get; set; }
        public bool runRight { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Jump { get; set; }
        public bool Falling { get; set; }
        public bool OnLadder { get; set; }

        public abstract void CheckInputs();
        public void ResetMove()
        {
            walkLeft = false;
            walkRight = false;
            runLeft = false;
            runRight = false;
            Jump = false;
        }
    }

    public class ControlsWASD : Controls
    {
        public override void CheckInputs()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Q) && stateKey.IsKeyUp(Keys.LeftShift))
            {
                walkLeft = true;
            }
            if (stateKey.IsKeyDown(Keys.D) && stateKey.IsKeyUp(Keys.LeftShift))
            {
                walkRight = true;
            }
            if (stateKey.IsKeyDown(Keys.Q) && stateKey.IsKeyDown(Keys.LeftShift))
            {
                runLeft = true;
            }
            if (stateKey.IsKeyDown(Keys.D) && stateKey.IsKeyDown(Keys.LeftShift))
            {
                runRight = true;
            }
            if (stateKey.IsKeyDown(Keys.Space) && !Falling)
            {
                Jump = true;
            }
            if (stateKey.IsKeyDown(Keys.Z))
            {
                Up = true;
            }
            if (stateKey.IsKeyDown(Keys.S))
            {
                Down = true;
            }
            if (stateKey.IsKeyUp(Keys.Q))
            {
                walkLeft = false;
                runLeft = false;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                walkRight = false;
                runRight = false;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Jump = false;
            }
            if (stateKey.IsKeyUp(Keys.Z))
            {
                Up = false;
            }
            if (stateKey.IsKeyUp(Keys.S))
            {
                Down = false;
            }

            if (walkLeft && walkRight || runLeft && runRight)
            {
                ResetMove();
            }
        }
    }

    public class ControlsAI : Controls
    {
        public override void CheckInputs()
        {
            throw new NotImplementedException();
        }
    }
}

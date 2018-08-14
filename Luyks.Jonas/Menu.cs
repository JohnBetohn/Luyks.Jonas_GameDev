using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Luyks.Jonas
{
    class Menu
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        Color color = new Color(255, 255, 255, 255);
        public Vector2 size;
        public Menu(Texture2D _texture)
        {
            texture = _texture;
            size = new Vector2(200, 100);
        }

        private bool down;
        public bool click;

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouseRectangle.Intersects(rectangle))
            {
                if (color.A == 255)
                {
                    down = false;
                }
                if (color.A == 120)
                {
                    down = true;
                }
                if (down == true)
                {
                    color.A += 3;
                }
                else
                {
                    color.A -= 3;
                }
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    click = true;
                }
            }
            else if (color.A < 255)
            {
                color.A += 3;
                click = false;
            }
        }

        public void pos(Vector2 _position)
        {
            position = _position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), color);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Luyks.Jonas
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Initialize Objects
        private Player player = new Player(new Vector2(70, 100));
        private Enemy enemy = new Enemy(new Vector2(150, 100));
        private Level level1 = new Level();
        private Block floor0 = new Block(new Vector2(0, 400));
        private Block floor1 = new Block(new Vector2(50, 400));
        private Block floor2 = new Block(new Vector2(100, 400));
        private Block floor3 = new Block(new Vector2(150, 400));
        private Block floor4 = new Block(new Vector2(200, 400));
        private Block floor5 = new Block(new Vector2(250, 400));
        private Block floor6 = new Block(new Vector2(300, 400));
        private Block floor7 = new Block(new Vector2(350, 400));
        private Block floor8 = new Block(new Vector2(400, 400));
        private Block floor9 = new Block(new Vector2(300, 200));
        private List<Block> floor;

        private Block wall0 = new Block(new Vector2(0, 350));
        private Block wall1 = new Block(new Vector2(250, 350));
        private List<Block> walls;

        private Ladder ladder0 = new Ladder(new Vector2(250, 300));
        private Ladder ladder1 = new Ladder(new Vector2(250, 250));
        private Ladder ladder2 = new Ladder(new Vector2(250, 200));
        private List<Ladder> ladders;

        private CollisionManager collisionManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            floor = new List<Block> {floor0, floor1, floor2, floor3, floor4, floor5, floor6, floor7, floor8, floor9};
            walls = new List<Block> {wall0, wall1};
            ladders = new List<Ladder> { ladder0, ladder1, ladder2 };
            level1.AddBlock(floor);
            level1.AddBlock(walls);
            level1.AddLadder(ladders);

            collisionManager = new CollisionManager(level1.getLevelCollision(), ladders);
            player.CollManager = collisionManager;
            enemy.CollManager = collisionManager;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.Texture = Content.Load<Texture2D>("Ed");   //Sprite from http://spritedatabase.net/file/2967/Ed

            enemy.Texture = Content.Load<Texture2D>("Enemy");
            Texture2D floortexture = Content.Load<Texture2D>("castleMID");
            Texture2D walltexture = Content.Load<Texture2D>("castleCenter");
            Texture2D ladderTexture = Content.Load<Texture2D>("ladder_Mid");

            for (int i = 0; i < floor.Count; i++)
            {
                floor[i].Texture = floortexture;
            }

            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Texture = walltexture;
            }


            for (int i = 0; i < ladders.Count; i++)
            {
                ladders[i].Texture = ladderTexture;
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            enemy.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            level1.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        Player player;
        Camera2D camera;

        private Level level = new Level();

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
            player = new Player(new Vector2(70, 100));
            camera = new Camera2D(GraphicsDevice.Viewport);

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

            Texture2D enemyTexture = Content.Load<Texture2D>("Enemy");
            Texture2D floortexture = Content.Load<Texture2D>("castleMID");
            Texture2D walltexture = Content.Load<Texture2D>("castleCenter");
            Texture2D ladderTexture = Content.Load<Texture2D>("ladder_Mid");

            level.SetActiveMap(0, walltexture, floortexture, ladderTexture, enemyTexture);
            collisionManager = new CollisionManager(level.GetLevelCollision(), level.Ladders);
            player.CollManager = collisionManager;

            for (int i = 0; i < level.Nodes.Count; i++)
            {
                level.Nodes[i].FindNeighbor(level.Nodes);
            }

            AIHandler aIHandler = new AIHandler();
            Node testStart = level.Nodes[2];
            Node testENd = level.Nodes[6];
            Debug.WriteLine( aIHandler.FindFastetPathTo(testENd, testStart) );
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
            player.Update(gameTime, level.Nodes);
            camera.Update(player.Position, level.Width, level.Height);
            //enemy.Update(gameTime, level.Nodes);

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
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            level.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

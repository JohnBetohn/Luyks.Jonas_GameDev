using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        List<SoundEffect> soundEffects;

        enum GameState
        {
            MainMenu,
            Game,
            GameOver,
            Finished
        }

        //Menu
        private GameState gameState = GameState.MainMenu;
        private Menu btnQuit, btnQwerty, btnAzerty;

        private Texture2D gameOver;
        private Texture2D pausedTexture;
        private Rectangle pausedRectangle;
        private Texture2D end;

        private SpriteFont scoreFont;

        private Level level = new Level();

        private CollisionManager collisionManager;

        private int lives = 5;
        private Vector2 Respawn;
        private bool levelCompleted;

        private int starsTotal = 0;
        private int starsCollected = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
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
            player = new Player(new Vector2(70, 500), 0); //y = 500 in level 1
            Respawn = player.Position;
            camera = new Camera2D(GraphicsDevice.Viewport);
            soundEffects = new List<SoundEffect>();

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

            Texture2D ladderTexture = Content.Load<Texture2D>("ladder_mid");

            //level1 textures
            Texture2D floortexture = Content.Load<Texture2D>("castleMID");
            Texture2D walltexture = Content.Load<Texture2D>("castleCenter");
            Texture2D fenceTexture = Content.Load<Texture2D>("fence");

            //Menu textures
            Texture2D azerty = Content.Load<Texture2D>("azerty");
            Texture2D qwerty = Content.Load<Texture2D>("qwerty");
            gameOver = Content.Load<Texture2D>("game-over");
            end = Content.Load<Texture2D>("end");

            //Key texture
            Texture2D keyTexture = Content.Load<Texture2D>("keyYellow");

            //Door textures
            Texture2D doorTextureTop = Content.Load<Texture2D>("door_closedTop");
            Texture2D doorTexture = Content.Load<Texture2D>("door_closedMid");

            //Star texture
            Texture2D starTexture = Content.Load<Texture2D>("star");

            //Toilet texture
            Texture2D toiletTexture = Content.Load<Texture2D>("toilet");

            //Flag texture
            Texture2D flagTexture = Content.Load<Texture2D>("flagRed");

            //font
            scoreFont = Content.Load<SpriteFont>("Score");

            //soundeffects
            soundEffects.Add(Content.Load<SoundEffect>("Toiletflush"));
            soundEffects.Add(Content.Load<SoundEffect>("tada"));

            IsMouseVisible = true;

            btnAzerty = new Menu(azerty);
            btnAzerty.pos(new Vector2(250, 325));

            btnQwerty = new Menu(qwerty);
            btnQwerty.pos(new Vector2(750, 325));

            pausedTexture = Content.Load<Texture2D>("Paused");
            pausedRectangle = new Rectangle(340, 160, 150, 150);

            btnQuit = new Menu(Content.Load<Texture2D>("Quit"));
            btnQuit.pos(new Vector2(graphics.PreferredBackBufferWidth - 125, graphics.PreferredBackBufferHeight - 75));


            //tempcode for testing
            //this needs to be done more elegantly
            level.SetActiveMap(0, walltexture, floortexture, ladderTexture, enemyTexture, keyTexture, doorTextureTop, doorTexture, starTexture, toiletTexture, flagTexture, fenceTexture);
            starsTotal = level.Stars.Count;
            collisionManager = new CollisionManager(level.GetLevelCollision(), level.Ladders);
            player.CollManager = collisionManager;
            foreach (Enemy enemy in level.Enemies)
            {
                enemy.CollManager = collisionManager;
            }

            //for (int i = 0; i < level.Nodes.Count; i++)
            //{
            //    level.Nodes[i].FindNeighbor(level.Nodes);
            //}
            //Node testStart = level.Nodes[2];
            //Node testENd = level.Nodes[6];
            //Debug.WriteLine( aIHandler.FindFastetPathTo(testENd, testStart) );
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

            MouseState mouse = Mouse.GetState();

            switch (gameState)
            {
                case GameState.MainMenu:
                    if (btnAzerty.click == true)
                    {
                        player.Controls = new ControlsZQSD();
                        gameState = GameState.Game;
                    }
                    if (btnQwerty.click == true)
                    {
                        player.Controls = new ControlsWASD();
                        gameState = GameState.Game;
                    }
                    btnAzerty.Update(mouse);
                    btnQwerty.Update(mouse);

                    if (Keyboard.GetState().IsKeyDown(Keys.E))
                    {
                        gameState = GameState.Finished;
                    }

                    break;
                case GameState.Game:
                    IsMouseVisible = false;

                    if (Keyboard.GetState().IsKeyDown(Keys.F2))
                    {
                        lives = 5;
                        NextLevel(0);
                    }

                    level.IssueCommands();

                    player.Update(gameTime);
                    if (player.CheckDeath(level.Enemies))
                    {
                        if (lives == 0)
                        {
                            gameState = GameState.GameOver;
                        }
                        lives--;
                        player.Position = Respawn;

                    }

                    if (player.CheckItem(level.key))
                    {
                        level.KeyCollected = true;
                        Respawn = level.key.Position;
                        level.LoadMap();
                        collisionManager = new CollisionManager(level.GetLevelCollision(), level.Ladders);
                        player.CollManager = collisionManager;
                    }

                    for (int i = 0; i < level.Stars.Count; i++)
                    {
                        Star star = level.Stars[i];
                        if (player.CheckItem(star))
                        {
                            level.Stars.Remove(star);
                            starsCollected++;
                        }
                    }

                    if (player.CheckItem(level.Goal) && !level.GoalReached)
                    {
                        level.GoalReached = true;
                        soundEffects[0].CreateInstance().Play();
                        Respawn = level.Goal.Position;
                    }

                    if (player.CheckItem(level.Flag) && level.GoalReached)
                    {
                        if (starsCollected == starsTotal)
                        {
                            lives = lives + 5;
                        }
                        if (!levelCompleted)
                        {
                            NextLevel(1);
                            levelCompleted = true;
                        }
                        else
                        {
                            gameState = GameState.Finished;
                        }
                        soundEffects[1].CreateInstance().Play();
                    }

                    camera.Update(player.Position, level.Width, level.Height);
                    foreach (Enemy enemy in level.Enemies)
                    {
                        enemy.Update(gameTime);
                        if (level.GoalReached && ((enemy.Position.X % 2) == 0))
                        {
                            enemy.WalkSpeedx = 2;
                        }
                    }
                    break;
                case GameState.GameOver:
                    if (Keyboard.GetState().IsKeyDown(Keys.F2))
                    {
                        lives = 5;
                        levelCompleted = false;
                        NextLevel(0);
                    }
                    break;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(94, 129, 162));

            // TODO: Add your drawing code here

            switch (gameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Content.Load<Texture2D>("keyboardlayout"), new Rectangle(graphics.PreferredBackBufferWidth / 2 - 200, 200, 400, 75), Color.White);
                    btnAzerty.Draw(spriteBatch);
                    btnQwerty.Draw(spriteBatch);
                    break;
                case GameState.Game:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
                    level.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    spriteBatch.DrawString(scoreFont, "Stars left to collect: " + (starsTotal - starsCollected), new Vector2(camera.Centre.X - (graphics.PreferredBackBufferWidth / 2), camera.Centre.Y - (graphics.PreferredBackBufferHeight / 2)), Color.Black);
                    spriteBatch.DrawString(scoreFont, "Lives left: " + lives, new Vector2(camera.Centre.X - (graphics.PreferredBackBufferWidth / 2), camera.Centre.Y - ((graphics.PreferredBackBufferHeight / 2) - 30)), Color.Black);
                    break;
                case GameState.GameOver:
                    spriteBatch.Begin();
                    spriteBatch.Draw(gameOver, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                    break;
                case GameState.Finished:
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture: end, position: new Vector2((float)graphics.PreferredBackBufferWidth/2 - 250, (float)graphics.PreferredBackBufferHeight/2 - 250), color: Color.White, scale: new Vector2((float)5, (float)5));
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void NextLevel(int i)
        {
            Texture2D enemyTexture = Content.Load<Texture2D>("Enemy");

            Texture2D ladderTexture = Content.Load<Texture2D>("ladder_mid");

            //level1 textures
            Texture2D floortexture = Content.Load<Texture2D>("castleMID");
            Texture2D walltexture = Content.Load<Texture2D>("castleCenter");

            //Key texture
            Texture2D keyTexture = Content.Load<Texture2D>("keyYellow");

            //Door textures
            Texture2D doorTextureTop = Content.Load<Texture2D>("door_closedTop");
            Texture2D doorTexture = Content.Load<Texture2D>("door_closedMid");
            Texture2D fenceTexture = Content.Load<Texture2D>("fence");

            //Star texture
            Texture2D starTexture = Content.Load<Texture2D>("star");

            //Toilet texture
            Texture2D toiletTexture = Content.Load<Texture2D>("toilet");

            //Flag texture
            Texture2D flagTexture = Content.Load<Texture2D>("flagRed");

            level.SetActiveMap(i, walltexture, floortexture, ladderTexture, enemyTexture, keyTexture, doorTextureTop, doorTexture, starTexture, toiletTexture, flagTexture, fenceTexture);
            starsTotal = level.Stars.Count;
            starsCollected = 0;
            collisionManager = new CollisionManager(level.GetLevelCollision(), level.Ladders);
            player.CollManager = collisionManager;
            if (i == 1)
            {
                Respawn = new Vector2(70, 950);
            }
            if (i == 0)
            {
                Respawn = new Vector2(70, 500);
            }
            player.Position = Respawn;
            foreach (Enemy enemy in level.Enemies)
            {
                enemy.CollManager = collisionManager;
            }
        }
    }
}

using _2D_Physics_Library.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ParallaxLibrary;
using System.Linq;

namespace _580GameProject7
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Player player;
        Obstacle obstacle;
        ParallaxLayer frontLayer;

        public int score;

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
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

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
            font = Content.Load<SpriteFont>("font");

            var playerSheet = Content.Load<Texture2D>("playerSheet");
            SpriteSheet playerSprites = new SpriteSheet(playerSheet, 64, 64);
            player = new Player(this);
            player.spritesheet = playerSheet;
            var l = (from index in Enumerable.Range(4, 8) select playerSprites[index]).ToList();
            l.AddRange((from index in Enumerable.Range(41, 6) select playerSprites[index]).ToList());
            player.sprites = l.ToArray();
            var testPixel = Content.Load<Texture2D>("bricksx64");
            obstacle = new Obstacle(this);
            obstacle.spritesheet = testPixel;

            frontLayer = new ParallaxLayer(this);
            frontLayer.Sprites.Add(player);
            frontLayer.Sprites.Add(obstacle);
            frontLayer.DrawOrder = 8;
            frontLayer.ScrollController = new AutoScrollController(0.0f);
            Components.Add(frontLayer);

            var backgroundTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("layer_08"),
                Content.Load<Texture2D>("layer_07_1")
            };
            var backgroundSprites = new StaticSprite[]
            {
                new StaticSprite(backgroundTextures[0]),
                new StaticSprite(backgroundTextures[1])
            };
            var backgroundLayer = new ParallaxLayer(this);
            backgroundLayer.Sprites.AddRange(backgroundSprites);
            backgroundLayer.DrawOrder = 1;
            Components.Add(backgroundLayer);

            var cloudLayerTexture = Content.Load<Texture2D>("layer_07_2");
            var cloudLayerSprite = new StaticSprite(cloudLayerTexture);
            var cloudLayer = new ParallaxLayer(this);
            cloudLayer.Sprites.Add(cloudLayerSprite);
            cloudLayer.DrawOrder = 2;
            cloudLayer.ScrollController = new AutoScrollController(10f);
            Components.Add(cloudLayer);

            var midSkylineTexture1 = Content.Load<Texture2D>("layer_06");
            var midSkylineSprite1 = new StaticSprite(midSkylineTexture1);
            var midSkylineLayer1 = new ParallaxLayer(this);
            midSkylineLayer1.Sprites.Add(midSkylineSprite1);
            midSkylineLayer1.DrawOrder = 3;
            midSkylineLayer1.ScrollController = new AutoScrollController(10f);
            Components.Add(midSkylineLayer1);

            var midSkylineTexture2 = Content.Load<Texture2D>("layer_05");
            var midSkylineSprite2 = new StaticSprite(midSkylineTexture2);
            var midSkylineLayer2 = new ParallaxLayer(this);
            midSkylineLayer2.Sprites.Add(midSkylineSprite2);
            midSkylineLayer2.DrawOrder = 4;
            midSkylineLayer2.ScrollController = new AutoScrollController(10f);
            Components.Add(midSkylineLayer2);

            var midSkylineTexture3 = Content.Load<Texture2D>("layer_04");
            var midSkylineSprite3 = new StaticSprite(midSkylineTexture3);
            var midSkylineLayer3 = new ParallaxLayer(this);
            midSkylineLayer3.Sprites.Add(midSkylineSprite3);
            midSkylineLayer3.DrawOrder = 5;
            midSkylineLayer3.ScrollController = new AutoScrollController(10f);
            Components.Add(midSkylineLayer3);

            var midSkylineTexture4 = Content.Load<Texture2D>("layer_03");
            var midSkylineSprite4 = new StaticSprite(midSkylineTexture4);
            var midSkylineLayer4 = new ParallaxLayer(this);
            midSkylineLayer4.Sprites.Add(midSkylineSprite4);
            midSkylineLayer4.DrawOrder = 6;
            midSkylineLayer4.ScrollController = new AutoScrollController(10f);
            Components.Add(midSkylineLayer4);

            var foregroundTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("layer_02"),
                Content.Load<Texture2D>("layer_01")
            };
            var foregroundSprites = new StaticSprite[]
            {
                new StaticSprite(foregroundTextures[0]),
                new StaticSprite(foregroundTextures[1])
            };
            var foregroundLayer = new ParallaxLayer(this);
            foregroundLayer.Sprites.AddRange(foregroundSprites);
            foregroundLayer.DrawOrder = 7;
            Components.Add(foregroundLayer);

            midSkylineLayer1.ScrollController = new AutoScrollController(15);
            midSkylineLayer2.ScrollController = new AutoScrollController(20);
            midSkylineLayer3.ScrollController = new AutoScrollController(25);
            midSkylineLayer4.ScrollController = new AutoScrollController(35);
            foregroundLayer.ScrollController = new AutoScrollController(100);
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
            obstacle.Update(gameTime);

            if (Collides.IsColliding(player.bounds, obstacle.bounds))
            {
                score = 0;
                obstacle.Reset();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            var scoreStringSize = font.MeasureString($"Score: {score}");
            spriteBatch.DrawString(font, $"Score: {score}", new Vector2(graphics.PreferredBackBufferWidth / 2 - scoreStringSize.X / 2, 10), Color.White);
            spriteBatch.End();

            
        }
    }
}

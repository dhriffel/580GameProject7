using _2D_Physics_Library.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParallaxLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _580GameProject7
{
    class Obstacle : ISprite
    {
        Game1 game;
        public PhysicsRectangle bounds;
        Vector2 velocity = new Vector2(0);
        float leftGravity;

        public Texture2D spritesheet;

        Random rand = new Random();

        public Obstacle(Game1 game)
        {
            this.game = game;
            Reset();
        }

        public Rectangle getBounds()
        {
            return (Rectangle)bounds;
        }

        public void Reset()
        {
            int randWidth = rand.Next(50,500);
            int randHeight = rand.Next(100, 200);
            this.bounds = new PhysicsRectangle(new Vector2(game.GraphicsDevice.Viewport.Bounds.Width + randWidth, game.GraphicsDevice.Viewport.Bounds.Height - randHeight / 2), randWidth,  randHeight);
            velocity = new Vector2(0);
            leftGravity = rand.Next(2,7)*0.1f;
        }

        public void Update(GameTime gameTime)
        {
            velocity.X += leftGravity;
            bounds.origin -= velocity;

            if (bounds.origin.X+bounds.halfWidth < game.GraphicsDevice.Viewport.Bounds.X)
            {
                Reset();
                game.score += 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle s)
        {
            /*var source = new Rectangle(            
                frame * FRAME_WIDTH, // X value 
                frame % 8 * FRAME_HEIGHT, // Y value
                FRAME_WIDTH, // Width 
                FRAME_HEIGHT // Height
                );*/

            //spriteBatch.Draw(spritesheet, bounds, Color.White);
            spriteBatch.Draw(spritesheet, bounds, new Rectangle(0,0,(int)bounds.halfWidth*2,(int)bounds.halfHeight*2), Color.White);


            //spriteBatch.Draw(spritesheet, bounds, source, Color.White, 0, spriteOrigin, 1f, SpriteEffects.None, 0.7f);
        }
    }
}
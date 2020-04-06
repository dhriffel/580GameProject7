using _2D_Physics_Library.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ParallaxLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _580GameProject7
{
    public class Player : ISprite
    {
        const int ANIMATION_FRAME_RATE = 124;
        const int FRAME_WIDTH = 64;
        const int FRAME_HEIGHT = 64;
        int scale = 3;

        Game1 game;
        public PhysicsRectangle bounds;
        Vector2 velocity = new Vector2(0);
        float jumpPower = 20f;
        float gravityForce = 0.7f;
        bool inAir = false;

        public Texture2D spritesheet;
        public Sprite[] sprites;
        Vector2 spriteOrigin = new Vector2(0);
        TimeSpan timer;
        int frame;

        public Player(Game1 game)
        {
            this.game = game;
            timer = new TimeSpan(0);
            frame = 0;
            bounds = new PhysicsRectangle(new Vector2(game.GraphicsDevice.Viewport.Bounds.X + FRAME_WIDTH*scale, game.GraphicsDevice.Viewport.Bounds.Height - FRAME_HEIGHT / 2*scale), FRAME_WIDTH*scale, FRAME_HEIGHT*scale);
        }

        public Rectangle getBounds()
        {
            return (Rectangle)bounds;
        }

        public void Update(GameTime gameTime)
        {
            if (!inAir)
            {
                var keyboard = Keyboard.GetState();
                if (keyboard.IsKeyDown(Keys.Space))
                {
                    velocity.Y += jumpPower;
                    inAir = true;
                    frame = 8;
                }
            }

            if (inAir)
            {
                bounds.origin -= velocity;
                velocity.Y -= gravityForce;
            }

            if((bounds.origin.Y+bounds.halfHeight) > game.GraphicsDevice.Viewport.Bounds.Height)
            {
                velocity = new Vector2(0);
                bounds.origin.Y = game.GraphicsDevice.Viewport.Bounds.Height - bounds.halfHeight;
                inAir = false;
            }

            // Update the player animation timer when the player is moving
            
            timer += gameTime.ElapsedGameTime;

            // Determine the frame should increase.  Using a while 
            // loop will accomodate the possiblity the animation should 
            // advance more than one frame.
            while (timer.TotalMilliseconds > ANIMATION_FRAME_RATE)
            {
                // increase by one frame
                frame++;
                // reduce the timer by one frame duration
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
            }
            if (!inAir)
            {
                // Keep the frame within bounds (there are eight frames)
                frame %= 8;
            }
            else
            {
                if (frame >= sprites.Length)
                    frame = 8;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle s)
        {
            //var source = new Rectangle(
            //    frame * FRAME_WIDTH, // X value 
            //    frame % 8 * FRAME_HEIGHT, // Y value
            //    FRAME_WIDTH, // Width 
            //    FRAME_HEIGHT // Height
            //    );


            spriteBatch.Draw(spritesheet, bounds, sourceRectangle: (sprites[frame].source), Color.White, 0f, spriteOrigin, SpriteEffects.None, 0.7f);

            //spriteBatch.Draw(spritesheet, bounds, source, Color.White, 0, spriteOrigin, 1f, SpriteEffects.None, 0.7f);
        }
    }
}

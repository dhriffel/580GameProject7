using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxLibrary
{
    /// <summary>
    /// A class representing a texture to render with a SpriteBatch
    /// </summary>
    public class StaticSprite : ISprite
    {
        /// <summary>
        /// The sprite's position in the game world
        /// </summary>
        public Vector2 position = Vector2.Zero;

        /// <summary>
        /// The texture this sprite uses
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// Creates a new static sprite
        /// </summary>
        /// <param name="texture">The texture to use</param>
        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        /// <summary>
        /// Creates a new static sprite
        /// </summary>
        /// <param name="texture">the texture to use</param>
        /// <param name="position">the upper-left hand corner of the sprite</param>
        public StaticSprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch.  This
        /// method should be invoked between SpriteBatch.Begin() 
        /// and SpriteBatch.End() calls.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle source)
        {
            spriteBatch.Draw(texture, position, source, Color.White);
            //spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

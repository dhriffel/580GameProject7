﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _580GameProject7
{
    public struct Sprite
    {
        // The sprite's source rectangle
        public Rectangle source;

        // The sprite's texture
        private Texture2D texture;

        /// <summary>
        /// Gets the sprite's width
        /// </summary>
        public int Width => source.Width;

        /// <summary>
        /// Gets teh sprite's height
        /// </summary>
        public int Height => source.Height;


        /// <summary>
        /// Constructs a new Sprite
        /// </summary>
        /// <param name="source"></param>
        /// <param name="texture"></param>
        public Sprite(Rectangle source, Texture2D texture)
        {
            this.texture = texture;
            this.source = source;
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch 
        /// This method should should be called between 
        /// spriteBatch.Begin() and spriteBatch.End()
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        /// <param name="destinationRectangle">The rectangle to draw the sprite into</param>
        /// <param name="color">The color</param>
        /// <param name="rotation">Rotation about the origin (in radians)</param>
        /// <param name="origin">A vector2 to the origin</param>
        /// <param name="effects">The SpriteEffects</param>
        /// <param name="layerDepth">The sorting layer of the sprite</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, destinationRectangle, source, color, rotation, origin, effects, layerDepth);
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch 
        /// This method should should be called between 
        /// spriteBatch.Begin() and spriteBatch.End()
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        /// <param name="destinationRectangle">The rectangle to draw the sprite into</param>
        /// <param name="color">The color</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteBatch.Draw(texture, destinationRectangle, source, color);
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch 
        /// This method should should be called between 
        /// spriteBatch.Begin() and spriteBatch.End()
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        /// <param name="position">A Vector2 for position</param>
        /// <param name="color">The color</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, position, source, color);
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch 
        /// This method should should be called between 
        /// spriteBatch.Begin() and spriteBatch.End()
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        /// <param name="position">A Vector2 for position</param>
        /// <param name="color">The color</param>
        /// <param name="rotation">Rotation about the origin (in radians)</param>
        /// <param name="origin">A vector2 to the origin</param>
        /// <param name="scale">The scale of the sprite centered on the origin</param>
        /// <param name="effects">The SpriteEffects</param>
        /// <param name="layerDepth">The sorting layer of the sprite</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, position, source, color, rotation, origin, scale, effects, layerDepth);
        }
    }
}
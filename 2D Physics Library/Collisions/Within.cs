using _2D_Physics_Library.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Physics_Library.Collisions
{
    public static class Within
    {
        public static bool pointInCircle(Vector2 point, PhysicsCircle circle)
        {
            var dx = point.X - circle.Origin.X;
            var dy = point.Y - circle.Origin.Y;

            return (((dx * dx) + (dy * dy)) <= (circle.Radius * circle.Radius));
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Physics_Library.Shapes
{
    public class PhysicsCircle
    {
        public float Radius { get; protected set; }
        public Vector2 Origin { get; protected set; }

        public PhysicsCircle(Vector2 origin, float radius)
        {
            this.Origin = origin;
            this.Radius = radius;
        }

    }
}

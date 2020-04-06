using _2D_Physics_Library.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Physics_Library.Collisions
{
    public static class Collides
    {
        public static bool IsColliding(PhysicsRectangle rect1, PhysicsRectangle rect2)
        {
            if (Math.Abs(rect1.origin.X - rect2.origin.X) > rect1.halfWidth + rect2.halfWidth)
                return false;
            if (Math.Abs(rect1.origin.Y - rect2.origin.Y) > rect1.halfHeight + rect2.halfHeight)
                return false;

            return true;
        }

        public static bool IsColliding(PhysicsCircle circle, PhysicsRectangle rect)
        {
            var point = Nearest.pointOnRectangle(circle.Origin, rect);
            return Within.pointInCircle(point, circle);
        }

        public static bool CirclevsCircleOptimized(PhysicsCircle a, PhysicsCircle b)
        {
            float r = a.Radius + b.Radius;
            float X = (a.Origin.X + b.Origin.X);
            float Y = (a.Origin.Y + b.Origin.Y);
            r *= r;
            return r < ((X * X) + (Y * Y));
        }

        public static bool IsColliding(PhysicsCircle circle1, PhysicsCircle circle2)
        {
            return Within.pointInCircle(circle1.Origin, new PhysicsCircle(circle2.Origin, circle1.Radius + circle2.Radius));
        }
    }
}

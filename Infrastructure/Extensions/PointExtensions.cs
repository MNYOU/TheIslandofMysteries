using System.Drawing;

namespace Infrastructure.Extensions;

public static class PointExtensions
{
    public static Point Add(this Point point, Point other)
    {
        return new Point(point.X + other.X, point.Y + other.Y);
    }
}
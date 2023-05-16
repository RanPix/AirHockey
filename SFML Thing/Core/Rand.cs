namespace PingPong.Core;

public static class Rand
{
    public static Random rand = new Random();

    public static float Next(float a, float b)
    {
        return (float)rand.Next((int)a, (int) b);
    }
}

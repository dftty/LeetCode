using System;

public class Test_1
{

    public struct Num
    {
        public int x;
        public int y;
        public int num;

        public Num(int x, int y, int num)
        {
            this.x = x;
            this.y = y;
            this.num = num;
        }
    }

    public int GetNumFromCoor(int x, int y)
    {
        int level = Math.Max(Math.Abs(x), Math.Abs(y));

        if (level == 0) return 1;

        Num[] points = new Num[4];

        int rightUpNum = (int)Math.Pow(GetOddNum(level), 2);
        points[0] = new Num(level, 0 - level, rightUpNum);
        points[1] = new Num(level, level, rightUpNum - 6 * level);
        points[2] = new Num(0 - level, level, rightUpNum - 4 * level);
        points[3] = new Num(0 - level, 0 - level, rightUpNum - 2 * level);


        return 0;
    }

    public int GetOddNum(int level)
    {
        if (level == 0)
        {
            return 1;
        }

        return GetOddNum(level - 1) + 2;
    }
}
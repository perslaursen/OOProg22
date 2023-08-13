
public class CircleCompareByX : IComparer<Circle>
{
    public int Compare(Circle? c1, Circle? c2)
    {
        if (c1 != null && c2 != null)
        {
            if (c1.X > c2.X) return 1;
            if (c1.X < c2.X) return -1;
        }
        else
        {
            if (c1 == null && c2 == null) return 0;
            if (c1 != null && c2 == null) return 1;
            if (c1 == null && c2 != null) return -1;
        }

        return 0;
    }
}

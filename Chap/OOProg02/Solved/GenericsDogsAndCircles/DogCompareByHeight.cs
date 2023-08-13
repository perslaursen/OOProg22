
public class DogCompareByHeight : IComparer<Dog>
{
    public int Compare(Dog? dog1, Dog? dog2)
    {
        if (dog1 != null && dog2 != null)
        {
            if (dog1.Height > dog2.Height) return 1;
            if (dog1.Height < dog2.Height) return -1;
        }
        else
        {
            if (dog1 == null && dog2 == null) return 0;
            if (dog1 != null && dog2 == null) return 1;
            if (dog1 == null && dog2 != null) return -1;
        }

        return 0;
    }
}

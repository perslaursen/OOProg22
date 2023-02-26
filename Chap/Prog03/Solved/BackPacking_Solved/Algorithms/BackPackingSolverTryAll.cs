using System.Collections;

/// <summary>
/// This class solves the problem by trying all combinations!
/// </summary>
public class BackPackingSolverTryAll : BackPackingSolverBase
{
    public BackPackingSolverTryAll(List<BackPackItem> items, double capacity) 
        : base(items, capacity)
    {
    }

    public override void Solve(ItemVault theItemVault, BackPack theBackPack)
    {
        int noOfItems = theItemVault.Items.Count;
        int noOfCombinations = Exp2(noOfItems);

        bool[,] combinations = new bool[noOfCombinations, noOfItems];

        for (int i = 0; i < noOfCombinations; i++)
        {
            bool[] bits = ToBits(i);

            for (int j = 0; j < noOfItems; j++)
            {
                combinations[i, j] = bits[j];
            }
        }

        int bestSolution = 0;
        double bestValueSum = 0;

        for (int i = 0; i < noOfCombinations; i++)
        {
            double weightSum = 0;
            double valueSum = 0;


            for (int j = 0; j < noOfItems; j++)
            {
                if (combinations[i, j])
                {
                    weightSum += theItemVault.Items[j].Weight;
                    valueSum += theItemVault.Items[j].Value;
                }
            }

            if (weightSum <= theBackPack.WeightCapacity && valueSum > bestValueSum)
            {
                bestSolution = i;
                bestValueSum = valueSum;
            }
        }

        for (int j = 0; j < noOfItems; j++)
        {
            if (combinations[bestSolution, j])
            {
                theBackPack.AddItem(theItemVault.Items[j]);
            }
        }

        foreach (BackPackItem item in theBackPack.Items)
        {
            theItemVault.RemoveItem(item.Description);
        }
    }

    private int Exp2(int n)
    {
        int exp = 1;

        for (int i = 0; i < n; i++)
        {
            exp *= 2;
        }

        return exp;
    }

    private bool[] ToBits(int n)
    {
        BitArray b = new BitArray(new int[] { n });

        bool[] bits = new bool[b.Count];
        b.CopyTo(bits, 0);

        return bits;
    }
}

namespace Woodstix.Fundamentals;

public class HandyHelmets
{
    public static (int min, int max) GetMinMax(List<int> list)
    {
        int min = 0;
        int max = 0;
        bool iterated = false;
        foreach (int val in list)
        {
            if (!iterated)
            {
                min = val;
                max = val;
                iterated = true;
            }

            if (val < min) min = val;
            if (val > max) max = val;
        }

        return (min, max);

    }

    public static List<int>[] Boxidize(List<int> list)
    {
        (int minSize, int maxSize) = GetMinMax(list);
        int number_of_buckets = maxSize - minSize + 1;
        //Console.WriteLine(number_of_buckets);

        List<int>[] buckets;
        buckets = new List<int>[number_of_buckets];
        
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<int>();
        }

        bool negativemode = minSize <= 0;
        foreach (int helmet in list)
        {
            if (negativemode) buckets[helmet+(-minSize)].Add(helmet);
            else
            {
                buckets[helmet-1].Add(helmet);
            }
            
        }
        
        
        return buckets;

    }

    public static List<int> BoxSort(List<int> list)
    {
        if (list.Count == 0) return list;
        List<int>[] buckets;
        buckets = Boxidize(list);
        List<int> sorted = new List<int>();
        foreach (List<int> helmet in buckets)
        {
            foreach (int coucou in helmet)
            {
                sorted.Add(coucou);
            }
        } 
        return sorted;
    }
    
}
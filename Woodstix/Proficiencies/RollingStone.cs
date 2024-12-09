namespace Woodstix.Proficiencies;

public class RollingStone
{
    public static void Swap(List<int> arr, int left, int right)
    {
        (arr[left], arr[right]) = (arr[right], arr[left]);
    }

    public static int Partition(List<int> arr, int left, int right)
    {
        if (left > right) throw new ArgumentException();
        int pivot = arr[right]; 
        int i = left - 1; // Index of the smaller element

        for (int j = left; j < right; j++)
        {
            if (arr[j] <= pivot)
            {
                i++; 
                Swap(arr, i, j); 
            }
        }

        Swap(arr, i + 1, right);

        return i + 1;
    }

    public static void IterativeQuickSort(List<int> arr)
    {
        if (arr == null || arr.Count <= 1)
            return;

        Stack<(int left, int right)> laPileDeLaVerite = new Stack<(int left, int right)>();
        laPileDeLaVerite.Push((0, arr.Count - 1));

        while (laPileDeLaVerite.Count > 0)
        {
            var (left, right) = laPileDeLaVerite.Pop();

            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                
                laPileDeLaVerite.Push((left, pivotIndex - 1));
                laPileDeLaVerite.Push((pivotIndex + 1, right));
            }
        }
        
    }
}
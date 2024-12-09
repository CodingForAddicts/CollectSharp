namespace Woodstix.Fundamentals;

public class Warmup
{
    public static Dictionary<string, int> MakeInventory(List<string> list)
    {
        var inventory = new Dictionary<string, int>();
        foreach (string elem in list)
        {
            if (inventory.ContainsKey(elem)) inventory[elem] += 1;
            else inventory.Add(elem,1);
        }

        return inventory;
    }

    private static void ReverseHelp(List<int> list, int changes)
    {
        if (changes*2 < list.Count)
        {
            (list[changes], list[list.Count - changes - 1]) = (list[list.Count - changes - 1], list[changes]);
            
            ReverseHelp(list, changes + 1);
        }
    }

    public static void ReversePlaylist(List<int> list)
    {
        ReverseHelp(list, 0);
    }
}
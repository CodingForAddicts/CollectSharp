namespace Woodstix.Proficiencies;

public class Toolkit
{
    public static (Dictionary<int, string> cache, List<int> keys) CreateCache(int capacity)
    {
        var cache = new Dictionary<int, string>(capacity);
        var keys = new List<int>(capacity);
        
        return (cache, keys);
    }

    public static void Put(int key, string value, (Dictionary<int, string> cache, List<int> keys) cacheTuple)
    {
        var (cache, keys) = cacheTuple;
        
        if (cache.ContainsKey(key))
        {
            cache[key] = value;
            
            keys.Remove(key);  
            keys.Insert(0, key);
        }
        else
        {
            if (cache.Count >= keys.Capacity)
            {
                int lruKey = keys[keys.Count - 1];
                
                cache.Remove(lruKey);
                keys.RemoveAt(keys.Count - 1);
            }
            
            cache[key] = value;
            keys.Insert(0, key);
        }
        
    }

    public static string Get(int key, (Dictionary<int, string> cache, List<int> keys) cacheTuple)
    {
        var (cache, keys) = cacheTuple;
        
        if (!cache.ContainsKey(key))
        {
            throw new ArgumentOutOfRangeException();
        }
        
        string tool = cache[key];
        
        keys.Remove(key); 
        keys.Insert(0, key);
        
        return tool;
        
    }
    
    
}
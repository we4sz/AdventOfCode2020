using System.IO;
using System.Linq;
using System.Reflection;

namespace Inputs
{
    public  class Utils
    {
        public static int[] GetAsIntArray(int day)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"day{day}.txt");
            
            return File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
        }
        
        public static string[] GetAsStringArray(int day)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"day{day}.txt");
            
            return File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }
        
    }
}
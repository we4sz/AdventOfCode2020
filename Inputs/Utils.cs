using System.IO;
using System.Linq;
using System.Reflection;

namespace Inputs
{
    public  class Utils
    {
        public static int[] GetAsIntArray(int day, int part)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $"Day{day}", $"input{part}.txt");
            
            return File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
        }
        
        
    }
}
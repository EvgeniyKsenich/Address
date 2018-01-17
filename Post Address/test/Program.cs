using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var List = CSVReader.GetList(@"C:\Users\Женя\Documents\Visual Studio 2017\Projects\Post Address\res\houses.csv");
            Console.WriteLine(List[0].city);
        }
    }
}

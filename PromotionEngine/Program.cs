using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Logging;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInfo.LogMessage("***********Starting Promotion Engine************");
            Console.WriteLine("#### Welcome to Promotion Engine, We need SKU Units From You, to Calculate Total Order Value ####");
            PromotionEngine objEngine = new PromotionEngine();
            objEngine.StartPromotionEngine();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Logging;

namespace PromotionEngine.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                LogInfo.LogMessage("***********Starting Promotion Engine************");
                Console.WriteLine("#### Welcome to Promotion Engine, We Need SKU Units From You, to Calculate Total Order Value ####");

                Program objEngine = new Program();
                objEngine.StartPromotionEngine();

                Console.WriteLine("\n Thank You For Using Promotion Engine, Please Press 'ENTER' Key to Exit");

                LogInfo.LogMessage("***********Ending Promotion Engine************");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while running promotion engine:" + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Entity;
using PromotionEngine.BLL;
using PromotionEngine.Logging;

namespace PromotionEngine
{

    /// <summary>
    /// Class to feed Program.cs by interacting with business Layer
    /// </summary>
    public class PromotionEngine
    {
        MakeSKUDataAvailable objData;
        ProcessSKUCart objSKUs;
        PromotionApplied objPromotion;
        List<SKUCartEntity> objCart;

        //instantiate LoadData, in default constructor
        public PromotionEngine()
        {
            objData = new MakeSKUDataAvailable();
        }

        public void StartPromotionEngine()
        {
            Console.WriteLine("\n Please Provide Your Input");
            objCart = ReadSKUInput();
            Console.WriteLine("\n Applying Promotions...");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SKUCartEntity> ReadSKUInput()
        {
            List<SKUCartEntity> objCart = new List<SKUCartEntity>();
            List<SKUEntity> lstSKU = objData.GetAvilableSKUs();
            try
            {
                foreach (SKUEntity item in lstSKU)
                {
                    Console.WriteLine(" Please Enter Units for " + item.SKU_ID);
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    objCart.Add(new SKUCartEntity()
                    {
                        SKU_ID = item.SKU_ID,
                        SKU_Unit = quantity,
                        SKU_DefaultPrice = item.SKU_UnitPrice
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Reading User Input, Please Reach to Administrator");
                LogInfo.LogMessage("Error while reading user Input in #ReadSKUInput#: " + ex.Message);
            }
            return objCart;
        }
    }
}

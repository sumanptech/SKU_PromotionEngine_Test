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
            objPromotion = ApplyPromotions(objCart);
            Console.WriteLine("\n Thanks for your Patience, Calculating Final Price For You");
            CalculateCheckoutPrice(objPromotion);
            Console.ReadKey();
        }

        /// <summary>
        /// Read User Input
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
                Console.WriteLine("Error while reading user input, Please contact administrator");
                LogInfo.LogMessage("Error while reading user Input in #ReadSKUInput#: " + ex.Message);
            }
            return objCart;
        }

        /// <summary>
        /// Check and Apply all promotions on given SKUs
        /// </summary>
        /// <returns>returns All SKUs and checkout price, after applying promotions</returns>
        public PromotionApplied ApplyPromotions(List<SKUCartEntity> objCart)
        {
            objPromotion = new PromotionApplied();
            objSKUs = new ProcessSKUCart();
            try
            {
                objPromotion = objSKUs.ApplyPromotionsOnSKUs(objCart, objData.GetAvailablePromotionTypes());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Applying Promotions, Please Reach to Administrator");
                LogInfo.LogMessage("Error while applying promotions in #ApplyPromotions#: " + ex.Message);
            }
            return objPromotion;
        }

        /// <summary>
        /// Calculate Final Checkout Price
        /// </summary>
        /// <returns>return 'true' if price calculated successfully</returns>
        public bool CalculateCheckoutPrice(PromotionApplied objPromotion)
        {
            bool retVal = false;
            try
            {
                Console.WriteLine(" SKU-ID" + " | " + "SKU-Unit" + " | " + "FinalPrice" + " | " + "PromotionApplied");
                foreach (var item in objPromotion.CartCheckout)
                {
                    Console.WriteLine(" " + item.SKU_ID + " . . . . " + item.SKU_Unit + " . . . . . " + item.SKU_FinalPrice + " . . . . " + (item.HasOffer == true ? "Yes" : "No"));
                }
                Console.WriteLine(" Checkout Price After Applying Promotions is: " + objPromotion.CheckoutPrice);
                retVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while Applying Promotions, Please Reach to Administrator");
                LogInfo.LogMessage("Error while applying promotions in #CalculateCheckoutPrice#: " + ex.Message);
            }
            return retVal;
        }

    }
}

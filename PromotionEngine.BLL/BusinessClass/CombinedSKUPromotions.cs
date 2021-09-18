using System;
using System.Collections.Generic;
using PromotionEngine.Entity;
using System.Linq;
using PromotionEngine.HelperModule;
using PromotionEngine.Logging;

namespace PromotionEngine.BLL
{
   public  class CombinedSKUPromotions: ISKUPromotions
    {

        private PromotionTypeEntity objPromotion;
        private SKUCartEntity objSKU;
        List<SKUCartEntity> productCheckouts;
        /// <summary>
        ///  Check what promotion is applicable on cart
        /// </summary>
        /// <param name="objLocalSKU">SKU List</param>
        /// <param name="lstPromotionTypes">List of promotion Types</param>
        /// <param name="objReturnSKU">output parameter to return SKU list</param>
        /// <returns>returns 'true' if promotion is applicable</returns>
        public double FetchSKUPrice(List<SKUCartEntity> objCart, PromotionTypeEntity objReturnProduct)
        {
            productCheckouts = new List<SKUCartEntity>();

            double finalPrice = 0;
            try
            {
                string[] str = objReturnProduct.SKU_ID.Split(';').ToArray();
                foreach (SKUCartEntity item in objCart)
                {
                    if (str.Contains(item.SKU_ID))
                    {
                        productCheckouts.Add(item);
                        item.IsValidated = true;
                    }
                }

                int quantity_first = 0;
                int quantity_second = 0;
                if (productCheckouts.Count > 1)
                {
                    quantity_first = productCheckouts[0].SKU_Unit;
                    quantity_second = productCheckouts[1].SKU_Unit;
                }

                if (quantity_first == 0 || quantity_second == 0)
                {
                    return objSKU.SKU_DefaultPrice;

                }

                if (quantity_first == quantity_second)
                {
                    finalPrice = objReturnProduct.Promotion_Price * quantity_first;
                }
                else if (quantity_first > quantity_second)
                {
                    int additionalItems = quantity_first - quantity_second;
                    finalPrice = (objSKU.SKU_DefaultPrice * additionalItems) + (objReturnProduct.Promotion_Price * quantity_second);
                }
                else if (quantity_first < quantity_second)
                {
                    int additionalItems = quantity_second - quantity_first;
                    finalPrice = (objSKU.SKU_DefaultPrice * additionalItems) + (objReturnProduct.Promotion_Price * quantity_first);
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while executing  Combined Promotions #FetchSKUPrice# :" + ex.Message);
            }
            return finalPrice;
        }

        /// <summary>
        /// Calculate Final Price
        /// </summary>
        /// <param name="objCart">List of SKUs in Cart</param>
        /// <param name="objReturnProduct">Promotion Type specifc to Input</param>
        /// <returns></returns>
        public bool IsApplicable(SKUCartEntity objLocalSKU, List<PromotionTypeEntity> objPromotionTypes, out PromotionTypeEntity objReturnSKU)
        {
            objReturnSKU = new PromotionTypeEntity();
            try
            {
                objSKU = objLocalSKU;
                objPromotion = objPromotionTypes.Where(x => x.SKU_ID.Split(';').Contains(objLocalSKU.SKU_ID)).FirstOrDefault();
                if (objPromotion != null && !objLocalSKU.IsValidated && objPromotion.Promotion_Type == EngineHelper.CombinedPromotions)
                {
                    objReturnSKU = objPromotion;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while executing Combined Promotions #IsApplicable# :" + ex.Message);
            }
            objReturnSKU = objPromotion;
            return false;
        }
    }
}

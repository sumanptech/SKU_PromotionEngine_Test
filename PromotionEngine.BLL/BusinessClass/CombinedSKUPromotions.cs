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
            throw new NotImplementedException();
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

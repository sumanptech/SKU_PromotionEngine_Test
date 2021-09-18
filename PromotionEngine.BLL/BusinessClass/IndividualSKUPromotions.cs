using System;
using System.Collections.Generic;
using PromotionEngine.Entity;
using PromotionEngine.Logging;
using System.Linq;
using PromotionEngine.HelperModule;

namespace PromotionEngine.BLL
{
    public class IndividualSKUPromotions: ISKUPromotions
    {
        private PromotionTypeEntity objAppliedPromotion;
        private SKUCartEntity objSKU;

        public IndividualSKUPromotions()
        {
            objAppliedPromotion = new PromotionTypeEntity();
            objSKU = new SKUCartEntity();
        }

        /// <summary>
        ///  Check what promotion is applicable on cart
        /// </summary>
        /// <param name="objLocalSKU">SKU List</param>
        /// <param name="lstPromotionTypes">List of promotion Types</param>
        /// <param name="objReturnSKU">output parameter to return SKU list</param>
        /// <returns>returns 'true' if promotion is applicable</returns>
        public double FetchSKUPrice(List<SKUCartEntity> objCart, PromotionTypeEntity objReturnProduct)
        {
            double finalPrice = 0;
            try
            {
                int skuCount = objSKU.SKU_Unit / objReturnProduct.SKU_Unit;
                int residueSKU = objSKU.SKU_Unit % objReturnProduct.SKU_Unit;

                finalPrice = (objReturnProduct.Promotion_Price * skuCount)
                                    + (residueSKU * (objSKU.SKU_DefaultPrice));

            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while executing  Individual Promotions #FetchSKUPrice# :" + ex.Message);
            }
            return finalPrice;
        }

        /// <summary>
        /// Calculate Final Price
        /// </summary>
        /// <param name="objCart">List of SKUs in Cart</param>
        /// <param name="objReturnProduct">Promotion Type specific to Input</param>
        /// <returns></returns>
        public bool IsApplicable(SKUCartEntity objLocalSKU, List<PromotionTypeEntity> lstPromotionTypes, out PromotionTypeEntity objReturnSKU)
        {
            objAppliedPromotion = new PromotionTypeEntity();
            try
            {
                objSKU = objLocalSKU;
                objAppliedPromotion = lstPromotionTypes.Where(x => x.SKU_ID == objLocalSKU.SKU_ID).FirstOrDefault();
                if (objAppliedPromotion != null && objAppliedPromotion.Promotion_Type == EngineHelper.IndividualPromotions)
                {
                    objLocalSKU.IsValidated = true;
                    objReturnSKU = objAppliedPromotion;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while executing Individual Promotions #IsApplicable# :" + ex.Message);
            }
            objReturnSKU = objAppliedPromotion;
            return false;
        }
    }
}

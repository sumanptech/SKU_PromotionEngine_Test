using System;
using System.Collections.Generic;
using PromotionEngine.Entity;
using PromotionEngine.Logging;

namespace PromotionEngine.BLL
{
    /// <summary>
    /// class defining operation to calculate checkout price
    /// </summary>
    public class ProcessSKUCart : IProcessSKUCart
    {
        /// <summary>
        /// Method to calculate Final Checkout Price
        /// </summary>
        /// <param name="objCart">Cart having all SKUs</param>
        /// <param name="promotionList">List of promotions</param>
        /// <returns></returns>
        public PromotionApplied ApplyPromotionsOnSKUs(List<SKUCartEntity> objCart, List<PromotionTypeEntity> promotionList)
        {
            PromotionApplied promoApplied = new PromotionApplied();
            PromotionTypeEntity objAppliedPromotion = new PromotionTypeEntity();
            List<ISKUPromotions> promotionTypes = new List<ISKUPromotions>();
            promotionTypes.Add(new IndividualSKUPromotions());            
            try
            {
                foreach (SKUCartEntity item in objCart)
                {
                    if (item.SKU_Unit > 0)
                    {
                        foreach (var promotion in promotionTypes)
                        {
                            if (promotion.IsApplicable(item, promotionList, out objAppliedPromotion))
                            {
                                item.SKU_FinalPrice = promotion.FetchSKUPrice(objCart, objAppliedPromotion);
                                item.HasOffer = true;
                                promoApplied.CheckoutPrice += item.SKU_FinalPrice;
                                break;
                            }
                        }
                    }
                }
                promoApplied.CartCheckout = objCart;
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error Applying Promotion in #ApplyPromotionsOnSKUs#:" + ex.Message);
            }
            return promoApplied;
        }
    }
}

using System;
using System.Collections.Generic;
using PromotionEngine.Entity;

namespace PromotionEngine.BLL.BusinessClass
{
   public  class CombinedSKUPromotions
    {
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
        public bool IsApplicable(SKUCartEntity objCart, List<PromotionTypeEntity> promotionList, out PromotionTypeEntity objReturnProduct)
        {
            throw new NotImplementedException();
        }
    }
}

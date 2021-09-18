using System;
using System.Collections.Generic;
using PromotionEngine.Entity;

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

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using PromotionEngine.Entity;

namespace PromotionEngine.BLL
{
    public class IndividualSKUPromotions: ISKUPromotions
    {
        public double FetchSKUPrice(List<SKUCartEntity> objCart, PromotionTypeEntity objReturnProduct)
        {
            throw new NotImplementedException();
        }

       public bool IsApplicable(SKUCartEntity objCart, List<PromotionTypeEntity> promotionList, out PromotionTypeEntity objReturnProduct)
        {
            throw new NotImplementedException();
        }
    }
}

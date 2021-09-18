using PromotionEngine.Entity;
using System.Collections.Generic;

namespace PromotionEngine.BLL
{
    /// <summary>
    /// Interface declaring operation for different SKU Promotions
    /// A class can Implement it basis to new Promotion Type
    /// </summary>
    public interface ISKUPromotions
    {
        double FetchSKUPrice(List<SKUCartEntity> objCart, PromotionTypeEntity objReturnProduct);

        bool IsApplicable(SKUCartEntity objCart, List<PromotionTypeEntity> promotionList, out PromotionTypeEntity objReturnProduct);
    }
}

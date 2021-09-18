
using System.Collections.Generic;
using PromotionEngine.Entity;

namespace PromotionEngine.BLL
{
    /// <summary>
    /// Interface declaring operation to calculate checkout price
    /// </summary>
    public interface IProcessSKUCart
    {
        PromotionApplied ApplyPromotionsOnSKUs(List<SKUCartEntity> objCart, List<PromotionTypeEntity> promotionList);
    }
}

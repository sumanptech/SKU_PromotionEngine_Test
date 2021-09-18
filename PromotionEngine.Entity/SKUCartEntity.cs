using System.Collections.Generic;

/// <summary>
/// Entity for Product Cart
/// </summary>
namespace PromotionEngine.Entity
{
   public class SKUCartEntity
    {

        public int SKU_Unit { get; set; }
        public string SKU_ID { get; set; }      
        public double SKU_FinalPrice { get; set; }
        public double SKU_DefaultPrice { get; set; }
        public bool HasOffer { get; set; }
        public bool IsValidated { get; set; }

    }


    /// <summary>
    /// Generic Entity for product cart 
    /// </summary>
    public class PromotionApplied
    {
        public double CheckoutPrice { get; set; }
        public List<SKUCartEntity> CartCheckout { get; set; }
        
    }
}

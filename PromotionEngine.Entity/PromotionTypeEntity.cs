/// <summary>
/// Entity for Promotion Types
/// </summary>
namespace PromotionEngine.Entity
{
    public class PromotionTypeEntity
    {
        public int Promotion_Id { get; set; }
        public string Promotion_Type { get; set; }
        public double Promotion_Price { get; set; }
        public int SKU_Unit { get; set; }
        public string SKU_ID { get; set; }  
        
    }
}

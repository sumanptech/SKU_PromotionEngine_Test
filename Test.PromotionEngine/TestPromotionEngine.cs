using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PromotionEngine.Entity;
using PromotionEngine.BLL;

namespace Test.PromotionEngine
{
    [TestClass]
    public class TestPromotionEngine
    {
        List<SKUCartEntity> objCart = null;
        IProcessSKUCart objSKUs = null;
        // objects instantiation
        List<PromotionTypeEntity> promotionList =
            new List<PromotionTypeEntity> {
          new PromotionTypeEntity{ Promotion_Type = "Individual", SKU_ID = "A", Promotion_Price = 130, SKU_Unit = 3 },
          new PromotionTypeEntity{ Promotion_Type = "Individual", SKU_ID = "B", Promotion_Price = 45, SKU_Unit = 2 },
          new PromotionTypeEntity{ Promotion_Type = "Combined", SKU_ID = "C;D", Promotion_Price = 30, SKU_Unit = 3 }
            };



        //Scenario 0
        //0	* A	50
        //0	* B	30
        //0	* C	20
        //Total 0

        [TestMethod]
        public void Scenario_NoSKUSelected()
        {
            objCart = new List<SKUCartEntity>
            {
                new SKUCartEntity{ SKU_ID = "A", SKU_Unit = 0, SKU_DefaultPrice = 50 },
                new SKUCartEntity{ SKU_ID = "B", SKU_Unit = 0, SKU_DefaultPrice = 30 },
                new SKUCartEntity{ SKU_ID = "C", SKU_Unit = 0, SKU_DefaultPrice = 20 }
            };
            objSKUs = new ProcessSKUCart();

            double expectedResult = 0;
            double actualResult = objSKUs.ApplyPromotionsOnSKUs(objCart, promotionList).CheckoutPrice;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

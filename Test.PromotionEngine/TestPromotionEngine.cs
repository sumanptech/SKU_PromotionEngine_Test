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



        // Deafult Testcase
        //0	* A	50        //0	* B	30        //0	* C	20        //Total 0
        [TestMethod]
        public void NoSKUSelectedTest()
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




        //Scenario A
        //1	* A	50      //1	* B	30          //1	* C	20         //Total 100

        [TestMethod]
        public void ABC_OneUnitEachSelectedTest()
        {
            objCart = new List<SKUCartEntity>
            {
                new SKUCartEntity{ SKU_ID = "A", SKU_Unit = 1, SKU_DefaultPrice = 50 },
                new SKUCartEntity{ SKU_ID = "B", SKU_Unit = 1, SKU_DefaultPrice = 30 },
                new SKUCartEntity{ SKU_ID = "C", SKU_Unit = 1, SKU_DefaultPrice = 20 }
            };

            objSKUs = new ProcessSKUCart();
            double expectedResult = 100;
            double actualResult = objSKUs.ApplyPromotionsOnSKUs(objCart, promotionList).CheckoutPrice;
            Assert.AreEqual(expectedResult, actualResult);
        }


        //Scenario B
        //5 * A	 130 + 2*50      //5 * B		45 + 45 + 30     //1 * C		28 
        //Total	370
        [TestMethod]
        public void SKU_5A_5B_1C_SelectedTest()
        {
            objCart = new List<SKUCartEntity>
            {
                new SKUCartEntity { SKU_ID = "A", SKU_Unit = 5, SKU_DefaultPrice = 50 },
                new SKUCartEntity { SKU_ID = "B", SKU_Unit = 5, SKU_DefaultPrice = 30 },
                new SKUCartEntity { SKU_ID = "C", SKU_Unit = 1, SKU_DefaultPrice = 20 }
            };

            objSKUs = new ProcessSKUCart();
            double expectedResult = 370;
            double actualResult = objSKUs.ApplyPromotionsOnSKUs(objCart, promotionList).CheckoutPrice;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Scenario C
        //3	* A	130        //5	* B	45 + 45 + 1 * 30        //1	* C	-        //1	* D	30
        //Total	280
        [TestMethod]
        public void SKU_3A_5B_1C_1D_SelectedTest()
        {
            objCart = new List<SKUCartEntity>
            {
                new SKUCartEntity { SKU_ID = "A", SKU_Unit = 3, SKU_DefaultPrice = 50 },
                new SKUCartEntity { SKU_ID = "B", SKU_Unit = 5, SKU_DefaultPrice = 30 },
                new SKUCartEntity { SKU_ID = "C", SKU_Unit = 1, SKU_DefaultPrice = 20 },
                new SKUCartEntity { SKU_ID = "D", SKU_Unit = 1, SKU_DefaultPrice = 15}
            };

            objSKUs = new ProcessSKUCart();
            double expectedResult = 280;
            double actualResult = objSKUs.ApplyPromotionsOnSKUs(objCart, promotionList).CheckoutPrice;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

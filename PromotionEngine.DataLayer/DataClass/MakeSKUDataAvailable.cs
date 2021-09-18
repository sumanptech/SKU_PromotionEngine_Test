using PromotionEngine.Entity;
using System.Collections.Generic;

namespace PromotionEngine.DataLayer.DataClass
{
    public class MakeSKUDataAvailable
    {
        LoadSKUData objData=null;

        /// <summary>
        /// default constructor
        /// </summary>
        public MakeSKUDataAvailable()
        {
            objData = new LoadSKUData();
        }

        /// <summary>
        /// Load AvilableProducts
        /// </summary>
        /// <returns></returns>
        public List<SKUEntity> GetAvilableSKUs()
        {
            return objData.GetAllSKUs();
        }
    }
}

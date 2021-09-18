using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.DataLayer;

namespace PromotionEngine.BLL
{
    /// <summary>
    /// Class defining operation To load SKU and Promotion Data from DataLayer
    /// </summary>
   public class MakeSKUDataAvailable
    {
        LoadSKUData objData;

        /// <summary>
        /// defaul constructor
        /// </summary>
        public MakeSKUDataAvailable()
        {
            objData = new LoadSKUData();
        }
    }
}

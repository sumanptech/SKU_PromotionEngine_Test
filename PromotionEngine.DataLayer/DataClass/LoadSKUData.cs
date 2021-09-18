using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entity;

namespace PromotionEngine.DataLayer
{
    /// <summary>
    /// Class defining operation To load SKU and Promotion Data from JSON/DataLayer
    /// </summary>
    class LoadSKUData : ILoadSKUData
    {
        public LoadSKUData()
        {

        }

        /// <summary>
        /// Reads all available SKUs from data source
        /// </summary>
        /// <returns>returns list of all available SKUs</returns>
        public List<SKUEntity> GetAllSKUs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads all available promotion types from data source
        /// </summary>
        /// <returns>List of available promotion types</returns>
        public List<PromotionTypeEntity> GetAllAvailablePromotionTypes()
        {
            throw new NotImplementedException();
        }
   }   
}

using PromotionEngine.Entity;
using System.Collections.Generic;

namespace PromotionEngine.DataLayer
{
    /// <summary>
    /// Interface declaring operation to load SKU and Promotion Data, from JSON/DataLayer
    /// </summary>
   public interface ILoadSKUData
    {
        /// <summary>
        /// Reads all available SKUs from data source
        /// </summary>
        /// <returns>returns list of all available SKUs</returns>
        List<SKUEntity> GetAllSKUs();

        /// <summary>
        /// Reads all available promotion types from data source
        /// </summary>
        /// <returns>List of available promotion types</returns>
        List<PromotionTypeEntity> GetAllAvailablePromotionTypes();
    }
}

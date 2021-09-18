using PromotionEngine.DataLayer;
using PromotionEngine.Entity;
using PromotionEngine.Logging;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Load All SKUs
        /// </summary>
        /// <returns></returns>
        public List<SKUEntity> GetAvilableSKUs()
        {
            List<SKUEntity> objSKU = new List<SKUEntity>();
            try
            {

                objSKU = objData.GetAllSKUs();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Errror while getting available SKUs #GetAvilableSKUs#: " + ex.Message);
            }
            return objSKU;
        }

        /// <summary>
        /// Reads all available promotion types from data layer
        /// </summary>
        /// <returns>List of available promotion types</returns>
        public List<PromotionTypeEntity> GetAvailablePromotionTypes()
        {
            List<PromotionTypeEntity> objPromotionTypes = new List<PromotionTypeEntity>();
            try
            {
                objPromotionTypes = objData.GetAllAvailablePromotionTypes();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Errror while getting available Promotion Types #GetAvailablePromotionTypes#: " + ex.Message);
            }
            return objPromotionTypes;
        }
    }
}

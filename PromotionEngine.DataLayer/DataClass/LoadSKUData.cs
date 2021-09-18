using Microsoft.Extensions.Configuration;
using PromotionEngine.Entity;
using PromotionEngine.HelperModule;
using PromotionEngine.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace PromotionEngine.DataLayer
{
    /// <summary>
    /// Class defining operation To load SKU and Promotion Data from JSON/DataLayer
    /// </summary>
    class LoadSKUData : ILoadSKUData
    {
        IConfiguration objLoadData;
        public LoadSKUData()
        {
            try
            {
                //base path for Datastore (SKUData.JSON) at the moment is "....Promotion_Engine\SKU_PromotionEngine\PromotionEngine.User\bin\Debug"
                //which can be changed by changing the base path and Introducing new path via configuration file 
                var objJsonFile = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(EngineHelper.DataSourceName, false);
                objLoadData = objJsonFile.Build();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage("Error while Loading Data Source :" + ex.Message);
            }
        }

        /// <summary>
        /// Reads all available SKUs from data source
        /// </summary>
        /// <returns>returns list of all available SKUs</returns>
        public List<SKUEntity> GetAllSKUs()
        {
            List<SKUEntity> lstSKU = new List<SKUEntity>();

            foreach (var item in objLoadData.GetSection(EngineHelper.SKU).GetChildren())
            {
                SKUEntity product = new SKUEntity();
                objLoadData.GetSection(item.Path).Bind(product);
                lstSKU.Add(product);
            }
            return lstSKU;
        }

        /// <summary>
        /// Reads all available promotion types from data source
        /// </summary>
        /// <returns>List of available promotion types</returns>
        public List<PromotionTypeEntity> GetAllAvailablePromotionTypes()
        {
            List<PromotionTypeEntity> lstPromotionTypes = new List<PromotionTypeEntity>();
            foreach (var item in objLoadData.GetSection(EngineHelper.Promotion_Types).GetChildren())
            {
                PromotionTypeEntity objProduct = new PromotionTypeEntity();
                objLoadData.GetSection(item.Path).Bind(objProduct);
                lstPromotionTypes.Add(objProduct);
            }
            return lstPromotionTypes;
        }
   }   
}

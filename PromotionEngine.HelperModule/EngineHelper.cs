/// <summary>
/// Helper class to store common features between 2 libraries, to avoid circular dependency
/// </summary>
namespace PromotionEngine.HelperModule
{
    public class EngineHelper
    {
        //Log file name can be changed as needed, 
        //this can be moved to app.config as well, if need is to avoid re-packaging, after change in name
        public const string LogFileName = "Promotion_Engine.log";
        public const string DataSourceName = "SKUData.json";


        //Json Nodes, in case changes, it can be changed here 
        public const string SKU = "SKU";
        public const string Promotion_Types = "Promotion_Types";
        //promotion types
        public const string IndividualPromotions = "Individual";
        public const string CombinedPromotions = "Combined";
    }
}

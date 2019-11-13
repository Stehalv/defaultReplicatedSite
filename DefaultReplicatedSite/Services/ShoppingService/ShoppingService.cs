using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public partial class ShoppingService
    {
        public ItemService _itemService = new ItemService();
        public List<ProductLineViewModel> GetProductLines()
        {

            return new List<ProductLineViewModel> {
                new AmberProductLineViewModel(),
                new TechTureProductLineViewModel()
            };
        }
        public ProductLineViewModel GetProductLine(string key)
        {
            var line = GetProductLines().FirstOrDefault(c => c.Key == key);
            line.Categories = GetProductLineCategories(line.ID);
            return line;
        }
        public List<WebCategoryViewModel> GetAllCategories()
        {
            return new List<WebCategoryViewModel>
            {
                new AmberWebCategoryViewModel(),
                new AmethystWebCategoryViewModel(),
                new AquamarineWebCategoryViewModel(),
                new AventurineWebCategoryViewModel(),
                new DiamondWebCategoryViewModel(),
                new GoldWebCategoryViewModel(),
                new PearlWebCategoryViewModel(),
                new RockCrystalWebCategoryViewModel(),
                new RoseQuartzWebCategoryViewModel(),
                new RubyWebCategoryViewModel(),
                new SapphireWebCategoryViewModel(),

                new SparkLedWebCategoryViewModel(),
                new EMSSkinTighteningWebCategoryViewModel(),
                new SonicNeckMAssagerWebCategoryViewModel(),
                new BodySculptingWebCategoryViewModel(),
                new LuminousBoostWebCategoryViewModel(),
                new SuperSonicSkinScrubberWebCategoryViewModel(),
                new SuperSonicScrubberWebCategoryViewModel()
            };
        }
        public List<WebCategoryViewModel> GetProductLineCategories(int productLineID)
        {
            return GetAllCategories().Where(c => c.ProductLineId == productLineID).ToList();

        }
        public IWebCategoryViewModel GetCategory(string key)
        {
            return GetAllCategories().FirstOrDefault(c => c.Key == key);
        }
    }
}
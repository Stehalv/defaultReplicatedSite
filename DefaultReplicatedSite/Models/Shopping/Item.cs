using MakoLibrary.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DefaultReplicatedSite.Models
{
    public class Item : ItemContract
    {
        public Item()
        {
            
        }
        public decimal Quantity { get; set; }
        public IOrderConfiguration Configuration { get; set; }
        public ItemPriceContract ItemPrice
        {
            get
            {
                if(ItemPricing != null && Configuration != null)
                {
                    return ItemPricing.FirstOrDefault(c => c.PriceType == Configuration.PriceTypeID && c.CountryCode == Configuration.CountryCode);
                }
                return null;
            }
        }
        public Item(ItemContract model, IOrderConfiguration config)
        {
            ItemId = model.ItemId;
            MasterItemId = model.MasterItemId;
            ItemCode = model.ItemCode;
            FullItemCode = model.FullItemCode;
            SupplierItemCode = model.SupplierItemCode;
            KeyWords = model.KeyWords;
            ItemType = model.ItemType;
            ItemTypeDescr = model.ItemTypeDescr;
            ItemTaxCategoryType = model.ItemTaxCategoryType;
            ItemTaxCategoryTypeDescr = model.ItemTaxCategoryTypeDescr;
            Title = model.Title;
            Descr = model.Descr;
            WeightMetric = model.WeightMetric;
            HeightImperial = model.HeightImperial;
            LargeImage = model.LargeImage;
            MediumImage = model.MediumImage;
            SmallImage = model.SmallImage;
            TinyImage = model.TinyImage;
            IsMasterItem = model.IsMasterItem;
            IsEligibleForAutoOrder = model.IsEligibleForAutoOrder;
            DoNotShip = model.DoNotShip;
            ShowBillOfMaterials = model.ShowBillOfMaterials;
            UseKitItemsForPricing = model.UseKitItemsForPricing;
            HideFromWeb = model.HideFromWeb;
            HideFromAdmin = model.HideFromAdmin;
            WeightImperial = model.WeightImperial;
            ShortDescr = model.ShortDescr;
            Notes = model.Notes;
            HeightMetric = model.HeightMetric;
            OtherValues = model.OtherValues;
            WidthMetric = model.WidthMetric;
            LengthImperial = model.LengthImperial;
            LengthMetric = model.LengthMetric;
            WeightMetricMeasurementType = model.WeightMetricMeasurementType;
            WeightMetricMeasurementTypeDescr = model.WeightMetricMeasurementTypeDescr;
            VolumeMetricMeasurementType = model.VolumeMetricMeasurementType;
            VolumeMetricMeasurementTypeDescr = model.VolumeMetricMeasurementTypeDescr;
            WeightImperialMeasurementType = model.WeightImperialMeasurementType;
            WeightImperialMeasurementTypeDescr = model.WeightImperialMeasurementTypeDescr;
            VolumeImperialMeasurementType = model.VolumeImperialMeasurementType;
            VolumeImperialMeasurementTypeDescr = model.VolumeImperialMeasurementTypeDescr;
            ItemPricing = model.ItemPricing;
            StoreFronts = model.StoreFronts;
            WidthImperial = model.WidthImperial;
            OtherFields = model.OtherFields;
            ItemOptionGroup1 = model.ItemOptionGroup1;
            ItemOptionGroup1Details = model.ItemOptionGroup1Details;
            ItemOptionGroup2 = model.ItemOptionGroup2;
            ItemOptionGroup2Details = model.ItemOptionGroup2Details;
            ItemOptionGroup3 = model.ItemOptionGroup3;
            ItemOptionGroup3Details = model.ItemOptionGroup3Details;
            ItemOptionGroup4 = model.ItemOptionGroup4;
            ItemOptionGroup4Details = model.ItemOptionGroup4Details;
            ItemOptionGroup5 = model.ItemOptionGroup5;
            ItemOptionGroup5Details = model.ItemOptionGroup5Details;
            IsActive = model.IsActive;
            OtherFlags = model.OtherFlags;
            WebCategories = model.WebCategories;
            Configuration = config;
        }
    }

    public class TestObject
    {
        public List<Item> Items { get; set; }
        public List<WebCategoryContract> Cats { get; set; }
    }
}
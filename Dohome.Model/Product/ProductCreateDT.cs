using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class ProductCreateDT
    {
        public long Id { get; set; }
        public long? ProductCreateHD_ID { get; set; }
        public string Article { get; set; }
        public string Site { get; set; }
        public string DescriptionTH { get; set; }
        public string DescriptionEN { get; set; }
        public string ArticleCategory { get; set; }
        public string GenericArticleCode { get; set; }
        public string MerchandiseCategory { get; set; }
        public string SalesUOM { get; set; }
        public string PicturePath { get; set; }
        public string Weight { get; set; }
        public string Weight_Unit { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Dimension_Unit { get; set; }
        public string NoPacking { get; set; }
        public string FeatureTH { get; set; }
        public string FeatureEN { get; set; }
        public string CharacteristicTH { get; set; }
        public string CharacteristicEN { get; set; }
        public string MaintenanceTH { get; set; }
        public string MaintenanceEN { get; set; }
        public string InstructionTH { get; set; }
        public string InstructionEN { get; set; }
        public string PartsInBoxSetTH { get; set; }
        public string PartsInBoxSetEN { get; set; }
        public string WarrantyTH { get; set; }
        public string WarrantyEN { get; set; }
        public string UpSell { get; set; }
        public string CrossSell { get; set; }
        public string PartsOutBoxSetTH { get; set; }
        public string PartsOutBoxSetEN { get; set; }
        public string Brand { get; set; }
        public string ModelTH { get; set; }
        public string ModelEN { get; set; }
        public string COD { get; set; }
        public string Installment { get; set; }
        public string InstallmentDetail { get; set; }
        public string DoHomeProductType { get; set; }
        public string PreOrderDeliveryDay { get; set; }
        public string MinimumPiecePerOrder { get; set; }
        public string MaximumPiecePerOrder { get; set; }
        public string DummyImagePath { get; set; }
        public string SalesStatus { get; set; }
        public string SloganTH { get; set; }
        public string SloganEN { get; set; }
        public string hasingGroupSiteLevel { get; set; }
        public string PurchasingGroup { get; set; }
        public string OnlineFrom { get; set; }
        public string OnlineTo { get; set; }
        public string SurchargeAddedAlready { get; set; }
        public string DeliveryCondition { get; set; }
        public string EcommerceProductName { get; set; }
        public string EcommerceShortName { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string ExportFlag { get; set; }
        public string ExportDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

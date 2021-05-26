using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Schedule
{
    public class ProductCreate
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://dohome.co.th/ECMInbound/RT")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://dohome.co.th/ECMInbound/RT", IsNullable = false)]
        public partial class MT_RTO001_ArticleMaster
        {

            private ArticleMaster[] articleMasterField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ArticleMaster", Namespace = "")]
            public ArticleMaster[] ArticleMaster
            {
                get
                {
                    return this.articleMasterField;
                }
                set
                {
                    this.articleMasterField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ArticleMaster
        {

            private string articleField;

            private string siteField;

            private string descriptionTHField;

            private string descriptionENField;

            private string articleCategoryField;

            private string genericArticleCodeField;

            private string merchandiseCategoryField;

            private string salesUOMField;

            private string picturePathField;

            private string weightField;

            private string weight_UnitField;

            private string widthField;

            private string lengthField;

            private string heightField;

            private string dimension_UnitField;

            private string noPackingField;

            private string featureTHField;

            private string featureENField;

            private string characteristicTHField;

            private string characteristicENField;

            private string maintenanceTHField;

            private string maintenanceENField;

            private string instructionTHField;

            private string instructionENField;

            private string partsInBoxSetTHField;

            private string partsInBoxSetENField;

            private string warrantyTHField;

            private string warrantyENField;

            private string upSellField;

            private string crossSellField;

            private string partsOutBoxSetTHField;

            private string partsOutBoxSetENField;

            private string brandField;

            private string modelTHField;

            private string modelENField;

            private string cODField;

            private string installmentField;

            private string installmentDetailField;

            private string doHomeProductTypeField;

            private string preOrderDeliveryDayField;

            private string minimumPiecePerOrderField;

            private string maximumPiecePerOrderField;

            private string dummyImagePathField;

            private string salesStatusField;

            private string sloganTHField;

            private string sloganENField;

            private byte purchasingGroupSiteLevelField;

            private byte purchasingGroupField;

            private string onlineFromField;

            private string onlineToField;

            private string surchargeAddedAlreadyField;

            private string deliveryConditionField;

            private string ecommerceProductNameField;

            private string ecommerceShortNameField;

            private string colorField;

            private string priceField;

            /// <remarks/>
            public string Article
            {
                get
                {
                    return this.articleField;
                }
                set
                {
                    this.articleField = value;
                }
            }

            /// <remarks/>
            public string Site
            {
                get
                {
                    return this.siteField;
                }
                set
                {
                    this.siteField = value;
                }
            }

            /// <remarks/>
            public string DescriptionTH
            {
                get
                {
                    return this.descriptionTHField;
                }
                set
                {
                    this.descriptionTHField = value;
                }
            }

            /// <remarks/>
            public string DescriptionEN
            {
                get
                {
                    return this.descriptionENField;
                }
                set
                {
                    this.descriptionENField = value;
                }
            }

            /// <remarks/>
            public string ArticleCategory
            {
                get
                {
                    return this.articleCategoryField;
                }
                set
                {
                    this.articleCategoryField = value;
                }
            }

            /// <remarks/>
            public string GenericArticleCode
            {
                get
                {
                    return this.genericArticleCodeField;
                }
                set
                {
                    this.genericArticleCodeField = value;
                }
            }

            /// <remarks/>
            public string MerchandiseCategory
            {
                get
                {
                    return this.merchandiseCategoryField;
                }
                set
                {
                    this.merchandiseCategoryField = value;
                }
            }

            /// <remarks/>
            public string SalesUOM
            {
                get
                {
                    return this.salesUOMField;
                }
                set
                {
                    this.salesUOMField = value;
                }
            }

            /// <remarks/>
            public string PicturePath
            {
                get
                {
                    return this.picturePathField;
                }
                set
                {
                    this.picturePathField = value;
                }
            }

            /// <remarks/>
            public string Weight
            {
                get
                {
                    return this.weightField;
                }
                set
                {
                    this.weightField = value;
                }
            }

            /// <remarks/>
            public string Weight_Unit
            {
                get
                {
                    return this.weight_UnitField;
                }
                set
                {
                    this.weight_UnitField = value;
                }
            }

            /// <remarks/>
            public string Width
            {
                get
                {
                    return this.widthField;
                }
                set
                {
                    this.widthField = value;
                }
            }

            /// <remarks/>
            public string Length
            {
                get
                {
                    return this.lengthField;
                }
                set
                {
                    this.lengthField = value;
                }
            }

            /// <remarks/>
            public string Height
            {
                get
                {
                    return this.heightField;
                }
                set
                {
                    this.heightField = value;
                }
            }

            /// <remarks/>
            public string Dimension_Unit
            {
                get
                {
                    return this.dimension_UnitField;
                }
                set
                {
                    this.dimension_UnitField = value;
                }
            }

            /// <remarks/>
            public string NoPacking
            {
                get
                {
                    return this.noPackingField;
                }
                set
                {
                    this.noPackingField = value;
                }
            }

            /// <remarks/>
            public string FeatureTH
            {
                get
                {
                    return this.featureTHField;
                }
                set
                {
                    this.featureTHField = value;
                }
            }

            /// <remarks/>
            public string FeatureEN
            {
                get
                {
                    return this.featureENField;
                }
                set
                {
                    this.featureENField = value;
                }
            }

            /// <remarks/>
            public string CharacteristicTH
            {
                get
                {
                    return this.characteristicTHField;
                }
                set
                {
                    this.characteristicTHField = value;
                }
            }

            /// <remarks/>
            public string CharacteristicEN
            {
                get
                {
                    return this.characteristicENField;
                }
                set
                {
                    this.characteristicENField = value;
                }
            }

            /// <remarks/>
            public string MaintenanceTH
            {
                get
                {
                    return this.maintenanceTHField;
                }
                set
                {
                    this.maintenanceTHField = value;
                }
            }

            /// <remarks/>
            public string MaintenanceEN
            {
                get
                {
                    return this.maintenanceENField;
                }
                set
                {
                    this.maintenanceENField = value;
                }
            }

            /// <remarks/>
            public string InstructionTH
            {
                get
                {
                    return this.instructionTHField;
                }
                set
                {
                    this.instructionTHField = value;
                }
            }

            /// <remarks/>
            public string InstructionEN
            {
                get
                {
                    return this.instructionENField;
                }
                set
                {
                    this.instructionENField = value;
                }
            }

            /// <remarks/>
            public string PartsInBoxSetTH
            {
                get
                {
                    return this.partsInBoxSetTHField;
                }
                set
                {
                    this.partsInBoxSetTHField = value;
                }
            }

            /// <remarks/>
            public string PartsInBoxSetEN
            {
                get
                {
                    return this.partsInBoxSetENField;
                }
                set
                {
                    this.partsInBoxSetENField = value;
                }
            }

            /// <remarks/>
            public string WarrantyTH
            {
                get
                {
                    return this.warrantyTHField;
                }
                set
                {
                    this.warrantyTHField = value;
                }
            }

            /// <remarks/>
            public string WarrantyEN
            {
                get
                {
                    return this.warrantyENField;
                }
                set
                {
                    this.warrantyENField = value;
                }
            }

            /// <remarks/>
            public string UpSell
            {
                get
                {
                    return this.upSellField;
                }
                set
                {
                    this.upSellField = value;
                }
            }

            /// <remarks/>
            public string CrossSell
            {
                get
                {
                    return this.crossSellField;
                }
                set
                {
                    this.crossSellField = value;
                }
            }

            /// <remarks/>
            public string PartsOutBoxSetTH
            {
                get
                {
                    return this.partsOutBoxSetTHField;
                }
                set
                {
                    this.partsOutBoxSetTHField = value;
                }
            }

            /// <remarks/>
            public string PartsOutBoxSetEN
            {
                get
                {
                    return this.partsOutBoxSetENField;
                }
                set
                {
                    this.partsOutBoxSetENField = value;
                }
            }

            /// <remarks/>
            public string Brand
            {
                get
                {
                    return this.brandField;
                }
                set
                {
                    this.brandField = value;
                }
            }

            /// <remarks/>
            public string ModelTH
            {
                get
                {
                    return this.modelTHField;
                }
                set
                {
                    this.modelTHField = value;
                }
            }

            /// <remarks/>
            public string ModelEN
            {
                get
                {
                    return this.modelENField;
                }
                set
                {
                    this.modelENField = value;
                }
            }

            /// <remarks/>
            public string COD
            {
                get
                {
                    return this.cODField;
                }
                set
                {
                    this.cODField = value;
                }
            }

            /// <remarks/>
            public string Installment
            {
                get
                {
                    return this.installmentField;
                }
                set
                {
                    this.installmentField = value;
                }
            }

            /// <remarks/>
            public string InstallmentDetail
            {
                get
                {
                    return this.installmentDetailField;
                }
                set
                {
                    this.installmentDetailField = value;
                }
            }

            /// <remarks/>
            public string DoHomeProductType
            {
                get
                {
                    return this.doHomeProductTypeField;
                }
                set
                {
                    this.doHomeProductTypeField = value;
                }
            }

            /// <remarks/>
            public string PreOrderDeliveryDay
            {
                get
                {
                    return this.preOrderDeliveryDayField;
                }
                set
                {
                    this.preOrderDeliveryDayField = value;
                }
            }

            /// <remarks/>
            public string MinimumPiecePerOrder
            {
                get
                {
                    return this.minimumPiecePerOrderField;
                }
                set
                {
                    this.minimumPiecePerOrderField = value;
                }
            }

            /// <remarks/>
            public string MaximumPiecePerOrder
            {
                get
                {
                    return this.maximumPiecePerOrderField;
                }
                set
                {
                    this.maximumPiecePerOrderField = value;
                }
            }

            /// <remarks/>
            public string DummyImagePath
            {
                get
                {
                    return this.dummyImagePathField;
                }
                set
                {
                    this.dummyImagePathField = value;
                }
            }

            /// <remarks/>
            public string SalesStatus
            {
                get
                {
                    return this.salesStatusField;
                }
                set
                {
                    this.salesStatusField = value;
                }
            }

            /// <remarks/>
            public string SloganTH
            {
                get
                {
                    return this.sloganTHField;
                }
                set
                {
                    this.sloganTHField = value;
                }
            }

            /// <remarks/>
            public string SloganEN
            {
                get
                {
                    return this.sloganENField;
                }
                set
                {
                    this.sloganENField = value;
                }
            }

            /// <remarks/>
            public byte PurchasingGroupSiteLevel
            {
                get
                {
                    return this.purchasingGroupSiteLevelField;
                }
                set
                {
                    this.purchasingGroupSiteLevelField = value;
                }
            }

            /// <remarks/>
            public byte PurchasingGroup
            {
                get
                {
                    return this.purchasingGroupField;
                }
                set
                {
                    this.purchasingGroupField = value;
                }
            }

            /// <remarks/>
            public string OnlineFrom
            {
                get
                {
                    return this.onlineFromField;
                }
                set
                {
                    this.onlineFromField = value;
                }
            }

            /// <remarks/>
            public string OnlineTo
            {
                get
                {
                    return this.onlineToField;
                }
                set
                {
                    this.onlineToField = value;
                }
            }

            /// <remarks/>
            public string SurchargeAddedAlready
            {
                get
                {
                    return this.surchargeAddedAlreadyField;
                }
                set
                {
                    this.surchargeAddedAlreadyField = value;
                }
            }

            /// <remarks/>
            public string DeliveryCondition
            {
                get
                {
                    return this.deliveryConditionField;
                }
                set
                {
                    this.deliveryConditionField = value;
                }
            }

            /// <remarks/>
            public string EcommerceProductName
            {
                get
                {
                    return this.ecommerceProductNameField;
                }
                set
                {
                    this.ecommerceProductNameField = value;
                }
            }

            /// <remarks/>
            public string EcommerceShortName
            {
                get
                {
                    return this.ecommerceShortNameField;
                }
                set
                {
                    this.ecommerceShortNameField = value;
                }
            }

            /// <remarks/>
            public string Color
            {
                get
                {
                    return this.colorField;
                }
                set
                {
                    this.colorField = value;
                }
            }

            public string Price
            {
                get
                {
                    return this.priceField;
                }
                set
                {
                    this.priceField = value;
                }
            }
        }
    }
}

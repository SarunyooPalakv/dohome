using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Dohome.Model.Schedule
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://dohome.co.th/ECMInbound/RT")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://dohome.co.th/ECMInbound/RT", IsNullable = false)]
    public partial class MT_RTO001_Pricing
    {

        private Pricing[] pricingField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Pricing", Namespace = "")]
        public Pricing[] Pricing
        {
            get
            {
                return this.pricingField;
            }
            set
            {
                this.pricingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Pricing
    {

        private string articleField;

        private string siteField;

        private string salesOrganizationField;

        private string distributionChannelField;

        private string uOMCodeField;

        private string uPCField;

        private string conversionField;

        private string unitWeightField;

        private string conditionTypeField;

        private string promotionNumberField;

        private string validFromField;

        private string validToField;

        private string priceField;

        private string agentPriceField;

        private string projectPriceField;

        private string currencyField;

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
        public string SalesOrganization
        {
            get
            {
                return this.salesOrganizationField;
            }
            set
            {
                this.salesOrganizationField = value;
            }
        }

        /// <remarks/>
        public string DistributionChannel
        {
            get
            {
                return this.distributionChannelField;
            }
            set
            {
                this.distributionChannelField = value;
            }
        }

        /// <remarks/>
        public string UOMCode
        {
            get
            {
                return this.uOMCodeField;
            }
            set
            {
                this.uOMCodeField = value;
            }
        }

        /// <remarks/>
        public string UPC
        {
            get
            {
                return this.uPCField;
            }
            set
            {
                this.uPCField = value;
            }
        }

        /// <remarks/>
        public string Conversion
        {
            get
            {
                return this.conversionField;
            }
            set
            {
                this.conversionField = value;
            }
        }

        /// <remarks/>
        public string UnitWeight
        {
            get
            {
                return this.unitWeightField;
            }
            set
            {
                this.unitWeightField = value;
            }
        }

        /// <remarks/>
        public string ConditionType
        {
            get
            {
                return this.conditionTypeField;
            }
            set
            {
                this.conditionTypeField = value;
            }
        }

        /// <remarks/>
        public string PromotionNumber
        {
            get
            {
                return this.promotionNumberField;
            }
            set
            {
                this.promotionNumberField = value;
            }
        }

        /// <remarks/>
        public string ValidFrom
        {
            get
            {
                return this.validFromField;
            }
            set
            {
                this.validFromField = value;
            }
        }

        /// <remarks/>
        public string ValidTo
        {
            get
            {
                return this.validToField;
            }
            set
            {
                this.validToField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        public string AgentPrice
        {
            get
            {
                return this.agentPriceField;
            }
            set
            {
                this.agentPriceField = value;
            }
        }

        /// <remarks/>
        public string ProjectPrice
        {
            get
            {
                return this.projectPriceField;
            }
            set
            {
                this.projectPriceField = value;
            }
        }

        /// <remarks/>
        public string Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }
    }
    
    public class ProductPrice
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Site { get; set; }
        public string SalesOrganization { get; set; }
        public string DistributionChannel { get; set; }
        public string UOMCode { get; set; }
        public string UPC { get; set; }
        public string Conversion { get; set; }
        public string UnitWeight { get; set; }
        public string ConditionType { get; set; }
        public string PromotionNumber { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Price { get; set; }
        public string AgentPrice { get; set; }
        public string ProjectPrice { get; set; }
        public string Currency { get; set; }
        public string ExportFlag { get; set; }
        public string ExportDescription { get; set; }
        public bool ItemFlag { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dohome.Model.Schedule
{
    public class ProductStock
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://dohome.co.th/ECMInbound/RT")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://dohome.co.th/ECMInbound/RT", IsNullable = false)]
        public partial class MT_RTO002_StockDownload
        {

            private Stock[] stockField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Stock", Namespace = "")]
            public Stock[] Stock
            {
                get
                {
                    return this.stockField;
                }
                set
                {
                    this.stockField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Stock
        {

            private string articleField;

            private string siteGroupField;

            private string ecomSiteField;

            private decimal quantityField;

            private decimal reorderPointField;

            private string scaleGroupField;

            private string deliveryDateField;

            private string uOMField;

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
            public string SiteGroup
            {
                get
                {
                    return this.siteGroupField;
                }
                set
                {
                    this.siteGroupField = value;
                }
            }

            /// <remarks/>
            public string EcomSite
            {
                get
                {
                    return this.ecomSiteField;
                }
                set
                {
                    this.ecomSiteField = value;
                }
            }

            /// <remarks/>
            public decimal Quantity
            {
                get
                {
                    return this.quantityField;
                }
                set
                {
                    this.quantityField = value;
                }
            }

            /// <remarks/>
            public decimal ReorderPoint
            {
                get
                {
                    return this.reorderPointField;
                }
                set
                {
                    this.reorderPointField = value;
                }
            }

            /// <remarks/>
            public string ScaleGroup
            {
                get
                {
                    return this.scaleGroupField;
                }
                set
                {
                    this.scaleGroupField = value;
                }
            }

            /// <remarks/>
            public string DeliveryDate
            {
                get
                {
                    return this.deliveryDateField;
                }
                set
                {
                    this.deliveryDateField = value;
                }
            }

            /// <remarks/>
            public string UOM
            {
                get
                {
                    return this.uOMField;
                }
                set
                {
                    this.uOMField = value;
                }
            }
        }


    }
}

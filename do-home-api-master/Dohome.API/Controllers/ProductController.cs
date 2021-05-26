using Dohome.DAL;
using Dohome.Lazada;
using Dohome.Model;
using System.Data;
using System.Web.Http;
using Lazop.Api;
using Newtonsoft.Json;
using System.Collections.Generic;
using Dohome.Model.Product;
using Dohome.Model.Base;
using System.Xml;
using Dohome.Model.Product.Price;
using System;

namespace Dohome.API.Controllers
{
    public class ProductController : BaseController
    {
        #region //--- Properties ---//
        public static helper _helper = null;
        public static helper helper
        {
            get { return (_helper == null) ? _helper = new helper() : _helper; }
        }

        public static LazadaAccess _lazadaAccess = null;
        public static LazadaAccess lazadaAccess
        {
            get { return (_lazadaAccess == null) ? _lazadaAccess = new LazadaAccess(LazadaApiUrl, LazadaAuthApiUrl, LazadaAppkey, LazadaAppSecret) : _lazadaAccess; }
        }

        #endregion

        [HttpGet]
        public ResponseInfo<List<Brands>> GetBrands()
        {
            ResponseInfo<List<Brands>> responseInfo;
            LazopResponse result = lazadaAccess.GetNoAuthen("/brands/get");
            responseInfo = JsonConvert.DeserializeObject<ResponseInfo<List<Brands>>>(result.Body);
            return responseInfo;
        }

        #region //--- List a product on Lazada ---//
        [HttpGet]
        public ResponseInfo<List<CategoryTree>> CategoryTree()
        {
            ResponseInfo<List<CategoryTree>> responseInfo = new ResponseInfo<List<CategoryTree>>();
            LazopResponse result = lazadaAccess.GetAuthen("/category/tree/get");

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<List<CategoryTree>>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<GetCategorySuggestion> GetCategorySuggestion([FromBody] GetCategorySuggestionRequest request)
        {
            ResponseInfo<GetCategorySuggestion> responseInfo = new ResponseInfo<GetCategorySuggestion>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();

            apiParameters.Add(new ApiParameters { key = "product_name", value = request.product_name });

            LazopResponse result = lazadaAccess.GetAuthen("/product/category/suggestion/get", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<GetCategorySuggestion>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<List<CategoryAttributes>> GetCategoryAttributes([FromBody] CategoryAttributesRequest request)
        {
            ResponseInfo<List<CategoryAttributes>> responseInfo = new ResponseInfo<List<CategoryAttributes>>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();
            apiParameters.Add(new ApiParameters { key = "primary_category_id", value = request.primary_category_id });

            LazopResponse result = lazadaAccess.GetNoAuthen("/category/attributes/get", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<List<CategoryAttributes>>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<CreateProduct> CreateProduct([FromBody] CreateProductRequest request)
        {
            ResponseInfo<CreateProduct> responseInfo = new ResponseInfo<CreateProduct>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();

            XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(request), "Request");

            XmlDocument xml = new XmlDocument();
            XmlNode docNode = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(docNode);

            string payload = xml.InnerXml + doc.InnerXml;

            apiParameters.Add(new ApiParameters { key = "payload", value = payload });

            LazopResponse result = lazadaAccess.PostAuthen("/product/create", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<CreateProduct>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
                if (result.Body != null)
                {
                    responseInfo = JsonConvert.DeserializeObject<ResponseInfo<CreateProduct>>(result.Body);
                }
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<CreateProduct> UpdateProduct([FromBody] UpdateProduct request)
        {
            ResponseInfo<CreateProduct> responseInfo = new ResponseInfo<CreateProduct>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();

            XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(request), "Request");

            XmlDocument xml = new XmlDocument();
            XmlNode docNode = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(docNode);

            string payload = xml.InnerXml + doc.InnerXml;

            apiParameters.Add(new ApiParameters { key = "payload", value = payload });

            LazopResponse result = lazadaAccess.PostAuthen("/product/update", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<CreateProduct>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
                if (result.Body != null)
                {
                    responseInfo = JsonConvert.DeserializeObject<ResponseInfo<CreateProduct>>(result.Body);
                }
            }

            return responseInfo;
        }
        #endregion

        [HttpPost]
        public ResponseInfo<ResponseProductItem> GetProductItem([FromBody] RequestProductItem request)
        {
            ResponseInfo<ResponseProductItem> responseInfo = new ResponseInfo<ResponseProductItem>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();
            if (request.item_id > 0)
            {
                apiParameters.Add(new ApiParameters { key = "item_id", value = request.item_id.ToString() });
            }
            apiParameters.Add(new ApiParameters { key = "seller_sku", value = request.seller_sku });

            LazopResponse result = lazadaAccess.GetAuthen("/product/item/get", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<ResponseProductItem>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<ResponseProducts> GetProduct(string offset = "0", string limit = "10")
        {
            ResponseInfo<ResponseProducts> responseInfo = new ResponseInfo<ResponseProducts>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();
            apiParameters.Add(new ApiParameters { key = "filter", value = "all" });
            //apiParameters.Add(new ApiParameters { key = "update_before", value = "" });
            //apiParameters.Add(new ApiParameters { key = "search", value = "" });
            //apiParameters.Add(new ApiParameters { key = "create_before", value = "" });
            //apiParameters.Add(new ApiParameters { key = "create_after", value = "" });
            //apiParameters.Add(new ApiParameters { key = "update_after", value = "" });
            //apiParameters.Add(new ApiParameters { key = "options", value = "" });
            //apiParameters.Add(new ApiParameters { key = "sku_seller_list", value = ""});

            LazopResponse result = lazadaAccess.GetAuthen("/products/get", apiParameters, offset, limit);
            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<ResponseProducts>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<ResponseProducts> GetProductBySearch(string search, string offset = "0", string limit = "10")
        {
            ResponseInfo<ResponseProducts> responseInfo = new ResponseInfo<ResponseProducts>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();
            apiParameters.Add(new ApiParameters { key = "filter", value = "all" });
            //apiParameters.Add(new ApiParameters { key = "update_before", value = "" });
            apiParameters.Add(new ApiParameters { key = "search", value = search });
            //apiParameters.Add(new ApiParameters { key = "create_before", value = "" });
            //apiParameters.Add(new ApiParameters { key = "create_after", value = "" });
            //apiParameters.Add(new ApiParameters { key = "update_after", value = "" });
            //apiParameters.Add(new ApiParameters { key = "options", value = "" });
            //apiParameters.Add(new ApiParameters { key = "sku_seller_list", value = ""});

            LazopResponse result = lazadaAccess.GetAuthen("/products/get", apiParameters, "0", "10");
            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<ResponseProducts>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
            }

            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<object> UpdatePriceQuantity([FromBody] UpdatePriceQuantity request)
        {
            ResponseInfo<object> responseInfo = new ResponseInfo<object>();
            List<ApiParameters> apiParameters = new List<ApiParameters>();

            XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(request), "Request");

            XmlDocument xml = new XmlDocument();
            XmlNode docNode = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(docNode);

            string payload = xml.InnerXml + doc.InnerXml;

            apiParameters.Add(new ApiParameters { key = "payload", value = payload });

            LazopResponse result = lazadaAccess.PostAuthen("/product/price_quantity/update", apiParameters);

            if (result.Code == "0")
            {
                responseInfo = JsonConvert.DeserializeObject<ResponseInfo<object>>(result.Body);
            }
            else
            {
                responseInfo.code = result.Code;
                responseInfo.message = result.Message;
                if (result.Body != null)
                {
                    responseInfo = JsonConvert.DeserializeObject<ResponseInfo<object>>(result.Body);
                }
            }

            return responseInfo;
        }

        [NonAction]
        public bool ExportPriceOld([FromBody] RequestExportXML ImportDate)
        {
            bool result = false;
            List<ProductPriceHD> listProductPriceHD = helper.ExecuteQuery<ProductPriceHD>("sp_Api_Get_ProductHD", new
            {
                ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
            }, System.Data.CommandType.StoredProcedure);

            if (listProductPriceHD.Count > 0)
            {
                //get product from api
                ResponseInfo<ResponseProducts> apiProductList = GetProduct("0", "1");
                List<ProductPriceDT> listProductPriceDT = helper.ExecuteQuery<ProductPriceDT>("sp_Api_Get_ProductDT_Article", null, System.Data.CommandType.StoredProcedure);

                if (apiProductList.code == "0" && apiProductList.data.total_products > 0 && listProductPriceDT.Count > 0)
                {
                    int total_products = apiProductList.data.total_products;

                    UpdatePriceQuantity PriceQuantity = new UpdatePriceQuantity();
                    List<PriceProduct> listProduct = new List<PriceProduct>();
                    for (int lp = 0; lp < total_products; lp++)
                    {
                        if (lp % 20 == 0)
                        {
                            apiProductList = GetProduct(lp.ToString(), "20");
                        }
                        for (int i = 0; i < apiProductList.data.products.Count; i++)
                        {
                            //List<PriceProduct> listProduct = new List<PriceProduct>();
                            string SellerSku = apiProductList.data.products[i].skus[0].SellerSku;
                            int qty = apiProductList.data.products[i].skus[0].quantity;
                            var resultMapping = listProductPriceDT.FindAll((p => p.Article == SellerSku));
                            for (int j = 0; j < resultMapping.Count; j++)
                            {
                                PriceProduct PriceProduct = new PriceProduct
                                {
                                    index = listProduct.Count + 1,
                                    Skus = new PriceSkus
                                    {
                                        Sku = new List<PriceSku> {
                                            new PriceSku {
                                                SellerSku = resultMapping[j].Article,
                                                Price = resultMapping[j].Price,
                                                Quantity = qty.ToString(),
                                                SalePrice = resultMapping[j].Price,
                                                SaleStartDate = resultMapping[j].ValidFrom,
                                                SaleEndDate = resultMapping[j].ValidTo
                                            }
                                        }
                                    }
                                };

                                listProduct.Add(PriceProduct);
                            }
                        }
                    }
                    PriceQuantity.Product = listProduct;


                    ResponseInfo<object> response = null;

                    for (int o = 0; o < PriceQuantity.Product.Count; o++)
                    {
                        UpdatePriceQuantity newPriceQuantity = new UpdatePriceQuantity();
                        List<PriceProduct> newlistProduct = new List<PriceProduct>();
                        newlistProduct.Add(PriceQuantity.Product[o]);
                        newPriceQuantity.Product = newlistProduct;
                        //newPriceQuantity.Product = PriceQuantity.Product.FindAll((p => p.index >= startIndex && p.index <= endIndex));
                        response = UpdatePriceQuantity(newPriceQuantity);
                        string msg = "Success";
                        bool status = true;
                        if (response.code != "0" && response.detail.Count > 0)
                        {
                            msg = response.code + ": " + response.detail[0].message;
                            status = false;
                        }

                        helper.ExecuteNonQuery("update ProductPriceDT set ExportFlag=@ExportFlag , ExportDescription=@ExportDescription, ModifiedBy='system', ModifiedOn=getdate() where Right([Article], 8) = @Article and ExportFlag is null", new
                        {
                            ExportFlag = status,
                            ExportDescription = msg,
                            Article = newPriceQuantity.Product[0].Skus.Sku[0].SellerSku
                        }, CommandType.Text);
                    }


                    //helper.ExecuteNonQuery("update ProductPriceDT set ExportFlag=@ExportFlag , ExportDescription=@ExportDescription, ModifiedBy='system', ModifiedOn= getdate() where Id = @Id", , CommandType.Text);
                }
            }

            return result;
        }

        [HttpPost]
        public bool ExportPrice([FromBody] RequestExportXML ImportDate)
        {
            bool result = false;
            List<ProductPriceHD> listProductPriceHD = helper.ExecuteQuery<ProductPriceHD>("sp_Api_Get_ProductHD", new
            {
                ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
            }, System.Data.CommandType.StoredProcedure);

            if (listProductPriceHD.Count > 0)
            {
                //get product from api
                ResponseInfo<ResponseProducts> apiProductList = GetProduct("0", "1");
                List<ProductPriceDT> listProductPriceDT = helper.ExecuteQuery<ProductPriceDT>("sp_Api_Get_ProductDT_Article", null, System.Data.CommandType.StoredProcedure);

                if (apiProductList.code == "0" && apiProductList.data.total_products > 0 && listProductPriceDT.Count > 0)
                {
                    int total_products = apiProductList.data.total_products;

                    UpdatePriceQuantity PriceQuantity = new UpdatePriceQuantity();
                    List<PriceProduct> listProduct = new List<PriceProduct>();

                    //*************Do this if total_products < listProductPriceDT.Count else Do loop listProductPriceDT.Count *****************
                    if (apiProductList.code == "0" && apiProductList.data.total_products > 0 && listProductPriceDT.Count > 0)
                    {
                        for (int lp = 0; lp < listProductPriceDT.Count; lp++)
                        {
                            apiProductList = GetProductBySearch(listProductPriceDT[lp].Article);

                            if (apiProductList.data.products != null)
                            {
                                string SellerSku = apiProductList.data.products[0].skus[0].SellerSku;
                                int qty = apiProductList.data.products[0].skus[0].quantity;
                                PriceProduct PriceProduct = new PriceProduct
                                {
                                    index = listProduct.Count + 1,
                                    Skus = new PriceSkus
                                    {
                                        Sku = new List<PriceSku> {
                                            new PriceSku {
                                                SellerSku = listProductPriceDT[lp].Article,
                                                Price = listProductPriceDT[lp].Price,
                                                Quantity = qty.ToString(),
                                                SalePrice = listProductPriceDT[lp].Price,
                                                SaleStartDate = listProductPriceDT[lp].ValidFrom,
                                                SaleEndDate = listProductPriceDT[lp].ValidTo
                                            }
                                        }
                                    }
                                };

                                listProduct.Add(PriceProduct);
                            }
                        }
                    }
                    else
                    {
                        for (int lp = 0; lp < total_products; lp++)
                        {
                            if (lp % 20 == 0)
                            {
                                apiProductList = GetProduct(lp.ToString(), "20");
                            }
                            if (apiProductList.data.products != null)
                            {
                                for (int i = 0; i < apiProductList.data.products.Count; i++)
                                {
                                    //List<PriceProduct> listProduct = new List<PriceProduct>();
                                    string SellerSku = apiProductList.data.products[i].skus[0].SellerSku;
                                    int qty = apiProductList.data.products[i].skus[0].quantity;
                                    var resultMapping = listProductPriceDT.FindAll(p => p.Article == SellerSku);
                                    for (int j = 0; j < resultMapping.Count; j++)
                                    {
                                        PriceProduct PriceProduct = new PriceProduct
                                        {
                                            index = listProduct.Count + 1,
                                            Skus = new PriceSkus
                                            {
                                                Sku = new List<PriceSku> {
                                            new PriceSku {
                                                SellerSku = resultMapping[j].Article,
                                                Price = resultMapping[j].Price,
                                                Quantity = qty.ToString(),
                                                SalePrice = resultMapping[j].Price,
                                                SaleStartDate = resultMapping[j].ValidFrom,
                                                SaleEndDate = resultMapping[j].ValidTo
                                            }
                                        }
                                            }
                                        };

                                        listProduct.Add(PriceProduct);
                                    }
                                }
                            }
                        }
                    }

                    PriceQuantity.Product = listProduct;

                    ResponseInfo<object> response = null;

                    for (int o = 0; o < PriceQuantity.Product.Count; o++)
                    {
                        UpdatePriceQuantity newPriceQuantity = new UpdatePriceQuantity();
                        List<PriceProduct> newlistProduct = new List<PriceProduct>();
                        newlistProduct.Add(PriceQuantity.Product[o]);
                        newPriceQuantity.Product = newlistProduct;
                        //newPriceQuantity.Product = PriceQuantity.Product.FindAll((p => p.index >= startIndex && p.index <= endIndex));
                        response = UpdatePriceQuantity(newPriceQuantity);
                        string msg = "Success";
                        bool status = true;
                        if (response.code != "0" && response.detail.Count > 0)
                        {
                            msg = response.code + ": " + response.detail[0].message;
                            status = false;
                        }

                        helper.ExecuteNonQuery("update ProductPriceDT set ExportFlag=@ExportFlag , ExportDescription=@ExportDescription, ModifiedBy='system', ModifiedOn=getdate() where Right([Article], 8) = @Article and ExportFlag is null", new
                        {
                            ExportFlag = status,
                            ExportDescription = msg,
                            Article = newPriceQuantity.Product[0].Skus.Sku[0].SellerSku
                        }, CommandType.Text);
                    }
                }

                //Update no export
                helper.ExecuteNonQuery("sp_Api_Get_ProductDT_Article_EndProcess", new
                {
                    ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
                }, System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        [HttpPost]
        public bool ExportStock([FromBody] RequestExportXML ImportDate)
        {
            bool result = false;
            List<ProductPriceHD> listProductPriceHD = helper.ExecuteQuery<ProductPriceHD>("sp_Api_Get_ProductStockHD", new
            {
                ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
            }, System.Data.CommandType.StoredProcedure);

            if (listProductPriceHD.Count > 0)
            {
                //get product from api
                ResponseInfo<ResponseProducts> apiProductList = GetProduct("0", "1");
                List<ProductStockDT> listProductStockDT = helper.ExecuteQuery<ProductStockDT>("sp_Api_Get_ProductStockDT_Article", null, System.Data.CommandType.StoredProcedure);

                if (apiProductList.code == "0" && apiProductList.data.total_products > 0 && listProductStockDT.Count > 0)
                {
                    int total_products = apiProductList.data.total_products;

                    UpdatePriceQuantity PriceQuantity = new UpdatePriceQuantity();
                    List<PriceProduct> listProduct = new List<PriceProduct>();

                    //*************Do this if total_products < listProductStockDT.Count else Do loop listProductStockDT.Count *****************
                    if (total_products > 0 && listProductStockDT.Count > 0)
                    {
                        for (int lp = 0; lp < listProductStockDT.Count; lp++)
                        {
                            apiProductList = GetProductBySearch(listProductStockDT[lp].Article);

                            if (apiProductList.data.products != null)
                            {
                                string SellerSku = apiProductList.data.products[0].skus[0].SellerSku;
                                decimal Price = 0;
                                decimal SalePrice = 0;
                                string SaleStartDate = "";
                                string SaleEndDate = "";
                                string Article = listProductStockDT[lp].Article;
                                string Quantity = listProductStockDT[lp].Quantity;
                                Price = apiProductList.data.products[0].skus[0].price;
                                SalePrice = apiProductList.data.products[0].skus[0].special_price;
                                SaleStartDate = apiProductList.data.products[0].skus[0].special_from_time;
                                SaleEndDate = apiProductList.data.products[0].skus[0].special_to_time;

                                PriceProduct PriceProduct = new PriceProduct
                                {
                                    index = listProduct.Count + 1,
                                    Skus = new PriceSkus
                                    {
                                        Sku = new List<PriceSku> {
                                            new PriceSku {
                                                SellerSku = Article,
                                                Price = Price.ToString(),
                                                Quantity = Quantity,
                                                SalePrice = SalePrice.ToString(),
                                                SaleStartDate = SaleStartDate,
                                                SaleEndDate = SaleEndDate
                                            }
                                        }
                                    }
                                };

                                listProduct.Add(PriceProduct);
                            }
                        }
                    }
                    else
                    {
                        for (int lp = 0; lp < total_products; lp++)
                        {
                            if (lp % 20 == 0)
                            {
                                apiProductList = GetProduct(lp.ToString(), "20");
                            }
                            if (apiProductList.data.products != null)
                            {
                                for (int i = 0; i < apiProductList.data.products.Count; i++)
                                {
                                    string SellerSku = apiProductList.data.products[i].skus[0].SellerSku;
                                    decimal Price = 0;
                                    decimal SalePrice = 0;
                                    string SaleStartDate = "";
                                    string SaleEndDate = "";
                                    var resultMapping = listProductStockDT.FindAll(p => p.Article == SellerSku);

                                    if (resultMapping.Count > 0)
                                    {
                                        Price = apiProductList.data.products[i].skus[0].price;
                                        SalePrice = apiProductList.data.products[i].skus[0].special_price;
                                        SaleStartDate = apiProductList.data.products[i].skus[0].special_from_time;
                                        SaleEndDate = apiProductList.data.products[i].skus[0].special_to_time;
                                    }
                                    for (int j = 0; j < resultMapping.Count; j++)
                                    {
                                        PriceProduct PriceProduct = new PriceProduct
                                        {
                                            index = listProduct.Count + 1,
                                            Skus = new PriceSkus
                                            {
                                                Sku = new List<PriceSku> {
                                            new PriceSku {
                                                SellerSku = resultMapping[j].Article,
                                                Price = Price.ToString(),
                                                Quantity = resultMapping[j].Quantity,
                                                SalePrice = SalePrice.ToString(),
                                                SaleStartDate = SaleStartDate,
                                                SaleEndDate = SaleEndDate
                                            }
                                        }
                                            }
                                        };
                                        listProduct.Add(PriceProduct);
                                    }
                                }
                            }
                        }
                    }

                    PriceQuantity.Product = listProduct;

                    ResponseInfo<object> response = null;

                    for (int o = 0; o < PriceQuantity.Product.Count; o++)
                    {
                        UpdatePriceQuantity newPriceQuantity = new UpdatePriceQuantity();
                        List<PriceProduct> newlistProduct = new List<PriceProduct>();
                        newlistProduct.Add(PriceQuantity.Product[o]);
                        newPriceQuantity.Product = newlistProduct;
                        response = UpdatePriceQuantity(newPriceQuantity);
                        string msg = "Success ";
                        bool status = true;
                        if (response.code != "0" && response.detail.Count > 0)
                        {
                            msg = response.code + ": " + response.detail[0].message;
                            status = false;
                        }

                        helper.ExecuteNonQuery("update ProductStockDT set ExportFlag=@ExportFlag , ExportDescription=@ExportDescription, ModifiedBy='system', ModifiedOn=getdate() where Right([Article], 8) = @Article and ExportFlag is null", new
                        {
                            ExportFlag = status,
                            ExportDescription = msg + " QTY : " + newPriceQuantity.Product[0].Skus.Sku[0].Quantity,
                            Article = newPriceQuantity.Product[0].Skus.Sku[0].SellerSku
                        }, CommandType.Text);
                    }
                }

                //Update no export
                helper.ExecuteNonQuery("sp_Api_Get_ProductStockDT_Article_EndProcess", new
                {
                    ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
                }, System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        [HttpPost]
        public bool ExportProduct([FromBody] RequestExportXML ImportDate)
        {
            bool result = false;
            List<ProductPriceHD> listProductPriceHD = helper.ExecuteQuery<ProductPriceHD>("sp_Api_Get_ProductCreateHD", new
            {
                ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
            }, System.Data.CommandType.StoredProcedure);

            if (listProductPriceHD.Count > 0)
            {
                List<ProductCreateDT> listProductCreateDT = helper.ExecuteQuery<ProductCreateDT>("sp_Api_Get_ProductCreateDT_Article", null, System.Data.CommandType.StoredProcedure);

                if (listProductCreateDT.Count > 0)
                {
                    for (int i = 0; i < listProductCreateDT.Count; i++)
                    {
                        var productCreate = listProductCreateDT[i];
                        var categorySugg = GetCategorySuggestion(new GetCategorySuggestionRequest { product_name = productCreate.EcommerceProductName });
                        string msg = "Success";
                        bool status = true;
                        string item_id = "";
                        //if (categorySugg.code == "0" && categorySugg.data != null && categorySugg.data.categorySuggestions.Length > 0)
                        //{
                        CreateProductRequest createProduct = new CreateProductRequest();
                        Product product = new Product();
                        product.PrimaryCategory = productCreate.ArticleCategory; //categorySugg.data.categorySuggestions[0].categoryId;
                        product.Attributes = new Attributes
                        {
                            brand = productCreate.Brand,
                            model = productCreate.ModelEN,
                            name = productCreate.EcommerceShortName,
                            name_en = productCreate.EcommerceShortName,
                            description = productCreate.DescriptionTH,
                            description_en = productCreate.DescriptionEN,
                            product_warranty = productCreate.WarrantyTH,
                            product_warranty_en = productCreate.WarrantyEN,
                            warranty = new List<Names> { new Names { name = productCreate.WarrantyEN } },
                            warranty_type = (productCreate.WarrantyEN == "ไม่มี") ? "No Warranty" : "Warranty Available"
                        };
                        product.Skus = new Skus
                        {
                            Sku = new List<Sku>
                                {
                                    new Sku
                                    {
                                        price = (productCreate.Price == "") ? 0 : Convert.ToDecimal(productCreate.Price),
                                        quantity = 0,
                                        SellerSku = productCreate.Article,
                                        color_family = new List<string>{ productCreate.Color },
                                        package_height = (productCreate.Height == "") ? "10" : productCreate.Height,
                                        package_weight = (productCreate.Weight == "") ? "10" : productCreate.Weight,
                                        package_width = (productCreate.Width == "") ? "10" : productCreate.Width,
                                        package_length = (productCreate.Length == "") ? "10" : productCreate.Length,
                                        Images = new List<Images>{ new Images { Image = productCreate.PicturePath } }
                                    }
                                }
                        };

                        createProduct.Product = product;
                        ResponseInfo<CreateProduct> resProduct = CreateProduct(createProduct);

                        if (resProduct.code != "0" && resProduct.detail.Count > 0)
                        {
                            if (resProduct.code == "500" && resProduct.detail[0].message.Contains("duplicate"))
                            {
                                UpdateProduct updateProduct = new UpdateProduct();
                                ProductUpdate productUpdate = new ProductUpdate();
                                productUpdate.Attributes = createProduct.Product.Attributes;
                                productUpdate.Skus = createProduct.Product.Skus;
                                updateProduct.Product = productUpdate;
                                var resUpdate = UpdateProduct(updateProduct);
                                if (resUpdate.code != "0" && resUpdate.detail.Count > 0)
                                {
                                    msg = resUpdate.code + ": " + resUpdate.detail[0].message;
                                    status = false;
                                }
                                else
                                {
                                    item_id = productCreate.Article;
                                    msg = "Update Success";
                                }
                            }
                            else
                            {
                                msg = resProduct.code + ": " + resProduct.detail[0].message;
                                status = false;
                            }
                        }
                        else
                        {
                            item_id = resProduct.data.item_id;
                            //1343918148
                        }
                        //}
                        //else
                        //{

                        //    status = false;
                        //    msg = "No CategorySuggestion";
                        //}

                        helper.ExecuteNonQuery("update ProductCreateDT set ExportFlag=@ExportFlag , ExportDescription=@ExportDescription, ModifiedBy='system', ModifiedOn=getdate() where Right([Article], 8) = @Article and ExportFlag is null", new
                        {
                            ExportFlag = status,
                            ExportDescription = msg + " > item_id : " + item_id,
                            Article = listProductCreateDT[i].Article
                        }, CommandType.Text);
                    }

                }

                //Update no export
                helper.ExecuteNonQuery("sp_Api_Get_ProductCreateDT_Article_EndProcess", new
                {
                    ImportDate = helper.ConvertStringToDateTime(ImportDate.ImportDate)
                }, System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
    }
}

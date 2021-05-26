using Dohome.DAL;
using Dohome.Model;
using Dohome.Model.Base;
using Dohome.Model.Product;
using Dohome.Model.Schedule;
using DohomeSystem.FTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using static Dohome.Model.Schedule.ProductCreate;
using static Dohome.Model.Schedule.ProductStock;

namespace Dohome.API.Controllers
{
    public class ScheduleController : ApiController
    {
        public static helper _helper = null;
        public static helper helper
        {
            get { return (_helper == null) ? _helper = new helper() : _helper; }
        }

        public static ProductController _productController = null;
        public static ProductController productController
        {
            get { return (_productController == null) ? _productController = new ProductController() : _productController; }
        }

        private static string PathFileXML_Price;
        private static string FTP_PathFileXML_Price;
        private static string FTP_PathFileXML_Backup;
        private static string PathFileXML_Stock;
        private static string FTP_PathFileXML_Stock;
        private static string PathFileXML_Product;
        private static string FTP_PathFileXML_Product;

        private static FtpProcess _ftpProcess = null;

        private static FtpProcess ftpProcess
        {
            get
            {
                if (_ftpProcess == null)
                {
                    Config configuration = helper.ExecuteQuery<Config>("sp_Get_SysConfigForEdit", null, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    PathFileXML_Price = configuration.PathFileXML_Price.Replace("\\\\", "\\");
                    FTP_PathFileXML_Price = configuration.FTP_PathFileXML_Price;
                    FTP_PathFileXML_Backup = configuration.FTP_PathFileXML_Backup;
                    PathFileXML_Stock = configuration.PathFileXML_Stock.Replace("\\\\", "\\");
                    FTP_PathFileXML_Stock = configuration.FTP_PathFileXML_Stock;
                    PathFileXML_Product = configuration.PathFileXML_Product.Replace("\\\\", "\\");
                    FTP_PathFileXML_Product = configuration.FTP_PathFileXML_Product;
                    _ftpProcess = new FtpProcess(configuration.Ftp_Host, configuration.Ftp_UserId, configuration.Ftp_Password);
                }
                return _ftpProcess;
            }
        }

        [HttpPost]
        public ResponseInfo<string> ImportPrice()
        {
            ResponseInfo<string> response = new ResponseInfo<string>();
            try
            {
                List<string> pathfile = ftpProcess.GetAllFtpFiles("/" + FTP_PathFileXML_Price);

                // Start directory
                string path = PathFileXML_Price;

                // Iterate through the XML files
                foreach (string fileName in pathfile)
                {
                    //Get datafile from ftp server
                    string dataFile = ftpProcess.GetFileFtpFile("/" + FTP_PathFileXML_Price + "/" + fileName);

                    MT_RTO001_Pricing ListPricing = Deserialize<MT_RTO001_Pricing>(dataFile);

                    if (ListPricing != null && ListPricing.Pricing.Count() > 0)
                    {
                        //check & insert FileName
                        ResponseData InsProductPriceHD = helper.ExecuteQuery<ResponseData>("sp_Ins_ProductPriceHD", new
                        {
                            FileName = fileName,
                            TotalRecord = ListPricing.Pricing.Count(),
                            CreateBy = "Job Schedule ImportPrice"
                        }, System.Data.CommandType.StoredProcedure).FirstOrDefault();

                        if (InsProductPriceHD.RES_CODE == "00")
                        {
                            for (int i = 0; i < ListPricing.Pricing.Count(); i++)
                            {
                                helper.ExecuteNonQuery("sp_Ins_ProductPriceDT", new
                                {
                                    ProductPriceHD_ID = Convert.ToInt64(InsProductPriceHD.RES_DATA), //ProductPriceHD_ID 
                                    Article = ListPricing.Pricing[i].Article,
                                    Site = ListPricing.Pricing[i].Site,
                                    SalesOrganization = ListPricing.Pricing[i].SalesOrganization,
                                    DistributionChannel = ListPricing.Pricing[i].DistributionChannel,
                                    UOMCode = ListPricing.Pricing[i].UOMCode,
                                    UPC = ListPricing.Pricing[i].UPC,
                                    Conversion = ListPricing.Pricing[i].Conversion,
                                    UnitWeight = ListPricing.Pricing[i].UnitWeight,
                                    ConditionType = ListPricing.Pricing[i].ConditionType,
                                    PromotionNumber = ListPricing.Pricing[i].PromotionNumber,
                                    ValidFrom = ListPricing.Pricing[i].ValidFrom,
                                    ValidTo = ListPricing.Pricing[i].ValidTo,
                                    Price = ListPricing.Pricing[i].Price,
                                    AgentPrice = ListPricing.Pricing[i].AgentPrice,
                                    ProjectPrice = ListPricing.Pricing[i].ProjectPrice,
                                    Currency = ListPricing.Pricing[i].Currency,
                                    CreatedBy = "Job Schedule ImportPrice"
                                }, System.Data.CommandType.StoredProcedure);
                            }
                        }
                        else
                        { //01 file existing in db
                          //no process
                        }
                    }

                    //Write file to local
                    string targetPath = ftpProcess.WriteFileToLocal(path, fileName, dataFile);
                    //Ftp move file to backup folder
                    ftpProcess.FtpMovePricingFileToBackUp(FTP_PathFileXML_Backup, FTP_PathFileXML_Price + "/" + fileName, targetPath, fileName);
                }

                response.message = "Successfully";
            }
            catch (Exception ex)
            {
                response.code = "99";
                response.message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        public ResponseInfo<string> ImportStock()
        {
            ResponseInfo<string> response = new ResponseInfo<string>();
            try
            {
                List<string> pathfile = ftpProcess.GetAllFtpFiles("/" + FTP_PathFileXML_Stock);

                // Start directory
                string path = PathFileXML_Stock;

                // Iterate through the XML files
                foreach (string fileName in pathfile)
                {
                    //Get datafile from ftp server
                    string dataFile = ftpProcess.GetFileFtpFile("/" + FTP_PathFileXML_Stock + "/" + fileName);

                    MT_RTO002_StockDownload ListStock = Deserialize<MT_RTO002_StockDownload>(dataFile);

                    if (ListStock != null && ListStock.Stock.Count() > 0)
                    {
                        //check & insert FileName
                        ResponseData InsProductStockHD = helper.ExecuteQuery<ResponseData>("sp_Ins_ProductStockHD", new
                        {
                            FileName = fileName,
                            TotalRecord = ListStock.Stock.Count(),
                            CreateBy = "Job Schedule ImportStock"
                        }, System.Data.CommandType.StoredProcedure).FirstOrDefault();

                        if (InsProductStockHD.RES_CODE == "00")
                        {
                            for (int i = 0; i < ListStock.Stock.Count(); i++)
                            {
                                helper.ExecuteNonQuery("sp_Ins_ProductStockDT", new
                                {
                                    ProductStockHD_ID = Convert.ToInt64(InsProductStockHD.RES_DATA), //ProductPriceHD_ID
                                    Article = ListStock.Stock[i].Article,
                                    SiteGroup = ListStock.Stock[i].SiteGroup,
                                    EcomSite = ListStock.Stock[i].EcomSite,
                                    Quantity = ListStock.Stock[i].Quantity,
                                    ReorderPoint = ListStock.Stock[i].ReorderPoint,
                                    ScaleGroup = ListStock.Stock[i].ScaleGroup,
                                    DeliveryDate = ListStock.Stock[i].DeliveryDate,
                                    UOM = ListStock.Stock[i].UOM,
                                    CreatedBy = "Job Schedule ImportStock"
                                }, System.Data.CommandType.StoredProcedure);
                            }
                        }
                        else
                        { //01 file existing in db
                          //no process
                        }
                    }

                    //Write file to local
                    string targetPath = ftpProcess.WriteFileToLocal(path, fileName, dataFile);
                    //Ftp move file to backup folder
                    ftpProcess.FtpMoveStockFileToBackUp(FTP_PathFileXML_Backup, FTP_PathFileXML_Stock + "/" + fileName, targetPath, fileName);
                }

                response.message = "Successfully";
            }
            catch (Exception ex)
            {
                response.code = "99";
                response.message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        public ResponseInfo<string> ImportProduct()
        {
            ResponseInfo<string> response = new ResponseInfo<string>();
            try
            {
                List<string> pathfile = ftpProcess.GetAllFtpFiles("/" + FTP_PathFileXML_Product);

                // Start directory
                string path = PathFileXML_Product;

                // Iterate through the XML files
                foreach (string fileName in pathfile)
                {
                    //Get datafile from ftp server
                    string dataFile = ftpProcess.GetFileFtpFile("/" + FTP_PathFileXML_Product + "/" + fileName);

                    MT_RTO001_ArticleMaster ListProduct = Deserialize<MT_RTO001_ArticleMaster>(dataFile);

                    if (ListProduct != null && ListProduct.ArticleMaster.Count() > 0)
                    {
                        //check & insert FileName
                        ResponseData InsProductCreateHD = helper.ExecuteQuery<ResponseData>("sp_Ins_ProductCreateHD", new
                        {
                            FileName = fileName,
                            TotalRecord = ListProduct.ArticleMaster.Count(),
                            CreateBy = "Job Schedule ImportProduct"
                        }, System.Data.CommandType.StoredProcedure).FirstOrDefault();

                        if (InsProductCreateHD.RES_CODE == "00")
                        {
                            for (int i = 0; i < ListProduct.ArticleMaster.Count(); i++)
                            {
                                helper.ExecuteNonQuery("sp_Ins_ProductCreateDT", new
                                {
                                    ProductCreateHD_ID = Convert.ToInt64(InsProductCreateHD.RES_DATA) //ProductPriceHD_ID 
                                   ,
                                    Article = ListProduct.ArticleMaster[i].Article
                                   ,
                                    Site = ListProduct.ArticleMaster[i].Site
                                   ,
                                    DescriptionTH = ListProduct.ArticleMaster[i].DescriptionTH
                                   ,
                                    DescriptionEN = ListProduct.ArticleMaster[i].DescriptionEN
                                   ,
                                    ArticleCategory = ListProduct.ArticleMaster[i].ArticleCategory
                                   ,
                                    MerchandiseCategory = ListProduct.ArticleMaster[i].MerchandiseCategory
                                   ,
                                    SalesUOM = ListProduct.ArticleMaster[i].SalesUOM
                                   ,
                                    PicturePath = ListProduct.ArticleMaster[i].PicturePath
                                   ,
                                    Weight = ListProduct.ArticleMaster[i].Weight
                                   ,
                                    Weight_Unit = ListProduct.ArticleMaster[i].Weight_Unit
                                   ,
                                    Width = ListProduct.ArticleMaster[i].Width
                                   ,
                                    Length = ListProduct.ArticleMaster[i].Length
                                   ,
                                    Height = ListProduct.ArticleMaster[i].Height
                                   ,
                                    Dimension_Unit = ListProduct.ArticleMaster[i].Dimension_Unit
                                   ,
                                    NoPacking = ListProduct.ArticleMaster[i].NoPacking
                                   ,
                                    FeatureTH = ListProduct.ArticleMaster[i].FeatureTH
                                   ,
                                    FeatureEN = ListProduct.ArticleMaster[i].FeatureEN
                                   ,
                                    CharacteristicTH = ListProduct.ArticleMaster[i].CharacteristicTH
                                   ,
                                    CharacteristicEN = ListProduct.ArticleMaster[i].CharacteristicEN
                                   ,
                                    MaintenanceTH = ListProduct.ArticleMaster[i].MaintenanceTH
                                   ,
                                    MaintenanceEN = ListProduct.ArticleMaster[i].MaintenanceEN
                                   ,
                                    InstructionTH = ListProduct.ArticleMaster[i].InstructionTH
                                   ,
                                    InstructionEN = ListProduct.ArticleMaster[i].InstructionEN
                                   ,
                                    PartsInBoxSetTH = ListProduct.ArticleMaster[i].PartsInBoxSetTH
                                   ,
                                    PartsInBoxSetEN = ListProduct.ArticleMaster[i].PartsInBoxSetEN
                                   ,
                                    WarrantyTH = ListProduct.ArticleMaster[i].WarrantyTH
                                   ,
                                    WarrantyEN = ListProduct.ArticleMaster[i].WarrantyEN
                                   ,
                                    UpSell = ListProduct.ArticleMaster[i].UpSell
                                   ,
                                    CrossSell = ListProduct.ArticleMaster[i].CrossSell
                                   ,
                                    PartsOutBoxSetTH = ListProduct.ArticleMaster[i].PartsOutBoxSetTH
                                   ,
                                    PartsOutBoxSetEN = ListProduct.ArticleMaster[i].PartsOutBoxSetEN
                                   ,
                                    Brand = ListProduct.ArticleMaster[i].Brand
                                   ,
                                    ModelTH = ListProduct.ArticleMaster[i].ModelTH
                                   ,
                                    ModelEN = ListProduct.ArticleMaster[i].ModelEN
                                   ,
                                    COD = ListProduct.ArticleMaster[i].COD
                                   ,
                                    Installment = ListProduct.ArticleMaster[i].Installment
                                   ,
                                    InstallmentDetail = ListProduct.ArticleMaster[i].InstallmentDetail
                                   ,
                                    DoHomeProductType = ListProduct.ArticleMaster[i].DoHomeProductType
                                   ,
                                    PreOrderDeliveryDay = ListProduct.ArticleMaster[i].PreOrderDeliveryDay
                                   ,
                                    MinimumPiecePerOrder = ListProduct.ArticleMaster[i].MinimumPiecePerOrder
                                   ,
                                    MaximumPiecePerOrder = ListProduct.ArticleMaster[i].MaximumPiecePerOrder
                                   ,
                                    DummyImagePath = ListProduct.ArticleMaster[i].DummyImagePath
                                   ,
                                    SalesStatus = ListProduct.ArticleMaster[i].SalesStatus
                                   ,
                                    SloganTH = ListProduct.ArticleMaster[i].SloganTH
                                   ,
                                    SloganEN = ListProduct.ArticleMaster[i].SloganEN
                                   ,
                                    PurchasingGroup = ListProduct.ArticleMaster[i].PurchasingGroup
                                   ,
                                    OnlineFrom = ListProduct.ArticleMaster[i].OnlineFrom
                                   ,
                                    OnlineTo = ListProduct.ArticleMaster[i].OnlineTo
                                   ,
                                    SurchargeAddedAlready = ListProduct.ArticleMaster[i].SurchargeAddedAlready
                                   ,
                                    DeliveryCondition = ListProduct.ArticleMaster[i].DeliveryCondition
                                   ,
                                    EcommerceProductName = ListProduct.ArticleMaster[i].EcommerceProductName
                                   ,
                                    EcommerceShortName = ListProduct.ArticleMaster[i].EcommerceShortName
                                   ,
                                    Color = ListProduct.ArticleMaster[i].Color
                                   ,
                                    Price = ListProduct.ArticleMaster[i].Price
                                   ,
                                    CreatedBy = "Job Schedule ImportProduct"
                                }, System.Data.CommandType.StoredProcedure);
                            }
                        }
                        else
                        { //01 file existing in db
                          //no process
                        }
                    }

                    //Write file to local
                    string targetPath = ftpProcess.WriteFileToLocal(path, fileName, dataFile);
                    //Ftp move file to backup folder
                    ftpProcess.FtpMoveProductFileToBackUp(FTP_PathFileXML_Backup, FTP_PathFileXML_Product + "/" + fileName, targetPath, fileName);
                }

                response.message = "Successfully";
            }
            catch (Exception ex)
            {
                response.code = "99";
                response.message = ex.Message;
            }

            return response;
        }

        [HttpPost]
        public bool ExportPrice([FromBody] RequestExportXML ImportDate)
        {
            return productController.ExportPrice(ImportDate);
        }

        [HttpPost]
        public bool ExportStock([FromBody] RequestExportXML ImportDate)
        {
            return productController.ExportStock(ImportDate);
        }

        [HttpPost]
        public bool ExportProduct([FromBody] RequestExportXML ImportDate)
        {
            return productController.ExportProduct(ImportDate);
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}

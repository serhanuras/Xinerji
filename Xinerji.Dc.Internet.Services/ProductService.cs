using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;


namespace Xinerji.Dc.Internet.Services
{
    public class ProductService
    {
        private static int numberOfItemsInPage = int.Parse(Xinerji.Configuration.ConfigurationManager.GetServiceElement("projectSettings")["itemsCountInPage"]);

        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IProductService productService;
        #endregion

        public ProductService()
        {
            sessionService = new SessionServiceImp();
            productService = new ProductServiceImp();
        }

        #region GetProductList
        [BOServiceFilter]
        public GetProductListResponse GetProductList(GetProductListRequest request)
        {
            GetProductListResponse response;

            if (request.SelectedPage != -1)
            {
                if (request.Search == "")
                {
                    var result = productService.GetAll(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage);

                    response = new GetProductListResponse
                    {
                        ProductList = result.Item1,
                        PageSize = result.Item2
                    };
                }
                else
                {
                    var result = productService.Search(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage, request.Search);

                    response = new GetProductListResponse
                    {
                        ProductList = result.Item1,
                        PageSize = result.Item2
                    };
                }
            }
            else
            {
                var result = productService.GetAll(request.Session.FirmId);

                response = new GetProductListResponse
                {
                    ProductList = result,
                    PageSize = 0
                };
            }

            return response;
        }
        #endregion


        #region InsertProduct
        [BOServiceFilter]
        public InsertProductResponse InsertProduct(InsertProductRequest request)
        {
            InsertProductResponse response;

            request.Product.FirmId = request.Session.FirmId;
            request.Product.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            Product product = productService.SearchProductByBarcode(request.Session.FirmId, request.Product.Barcode);

            if (product == null)
            {
               
                productService.Insert(request.Product);

                response = new InsertProductResponse
                {
                };

                
            }
            else
            {
                response = new InsertProductResponse
                {
                    Header = new ResponseHeader
                    {
                        Error = new Error
                        {
                            ErrorCode = 3
                        }
                    }
                };
            }

            return response;
        }
        #endregion

        #region DeleteProduct
        [BOServiceFilter]
        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse response;
            productService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteProductResponse
            {

            };

            return response;
        }
        #endregion


        #region EditProduct
        [BOServiceFilter]
        public EditProductResponse EditProduct(EditProductRequest request)
        {
            EditProductResponse response;
            request.Product.FirmId = request.Session.FirmId;
            request.Product.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            Product product = productService.SearchProductByBarcode(request.Session.FirmId, request.Product.Barcode);

            if (product == null)
            {
                productService.Update(request.Product);

                response = new EditProductResponse
                {
                };
            }
            else
            {
                if (product.Id == request.Product.Id)
                {
                    productService.Update(request.Product);

                    response = new EditProductResponse
                    {
                    };
                }
                else
                {
                    response = new EditProductResponse
                    {
                        Header = new ResponseHeader
                        {
                            Error = new Error
                            {
                                ErrorCode = 3
                            }
                        }
                    };
                }
            }

            return response;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Integration;
namespace Xinerji.Dc.Services
{
    public class ProductServiceImp : IProductService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public Product ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Product returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeProductStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = ProductDataBinder.ToProduct(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
           
        }

        public List<Product> GetAll(long firmId)
        {
            List<Product> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getProducts",
                        new object[] {
                            firmId
                        });

                    returnValue = ProductDataBinder.ToProductList(dv);
                }

                return returnValue;
            }
        }

        public Product GetById(long Id)
        {
            Product returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getProductById",
                        new object[] {
                            Id
                        });

                    returnvalue = ProductDataBinder.ToProduct(dv);
                }

                return returnvalue;
            }
        }

        public Product Insert(Product product)
        {
            Product returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertProduct",
                        new object[] {
                            product.FirmId,
                            product.Name,
                            product.Barcode,
                            product.Weight,
                            product.Height,
                            product.Width,
                            product.Volume,
                            (int)product.Status
                        });

                    returnvalue = ProductDataBinder.ToProduct(dv);
                }

                return returnvalue;
            }
        }

        public Product Update(Product product)
        {
            Product returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateProduct",
                        new object[] {
                            product.Id,
                            product.Name,
                            product.Barcode,
                            product.Weight,
                            product.Height,
                            product.Width,
                            product.Volume,
                            (int)product.Status
                        });

                    returnvalue = ProductDataBinder.ToProduct(dv);
                }

                return returnvalue;
            }
        }
    }
}

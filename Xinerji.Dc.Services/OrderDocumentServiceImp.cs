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
    public class OrderDocumentServiceImp : IOrderDocumentService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public OrderDocument Delete(long Id)
        {
            OrderDocument returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_deleteOrderDocument",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderDocumentDataBinder.ToOrderDocument(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<OrderDocument> GetAll(long orderId)
        {
            List<OrderDocument> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderDocuments",
                        new object[] {
                            orderId
                        });

                    returnValue = OrderDocumentDataBinder.ToOrderDocumentList(dv);
                }

                return returnValue;
            }
        }

        public OrderDocument GetById(long Id)
        {
            OrderDocument returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderDocumentById",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderDocumentDataBinder.ToOrderDocument(dv);
                }

                return returnvalue;
            }
        }

        public OrderDocument Insert(OrderDocument orderDocument)
        {
            OrderDocument returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrderDocument",
                        new object[] {
                            orderDocument.OrderId,
                            orderDocument.DocumentTypeId,
                            orderDocument.FileName,
                            orderDocument.FileExtension,
                            orderDocument.FileBinary
                        });

                    returnvalue = OrderDocumentDataBinder.ToOrderDocument(dv);
                }

                return returnvalue;
            }
        }

        public OrderDocument Update(OrderDocument orderDocument)
        {
            OrderDocument returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrderDocument",
                        new object[] {
                            orderDocument.Id,
                            orderDocument.OrderId,
                            orderDocument.DocumentTypeId,
                            orderDocument.FileName,
                            orderDocument.FileExtension,
                            orderDocument.FileBinary
                        });

                    returnvalue = OrderDocumentDataBinder.ToOrderDocument(dv);
                }

                return returnvalue;
            }
        }
    }
}

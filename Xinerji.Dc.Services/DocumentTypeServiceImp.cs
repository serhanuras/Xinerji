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
    public class DocumentTypeServiceImp : IDocumentTypeService
    {

        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public DocumentType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            DocumentType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeDocumentTypeStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = DocumentTypeDataBinder.ToDocumentType(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<DocumentType> GetAll(long firmId)
        {
            List<DocumentType> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getDocumentTypes",
                        new object[] {
                            firmId
                        });

                    returnValue = DocumentTypeDataBinder.ToDocumentTypeList(dv);
                }

                return returnValue;
            }
        }

        public DocumentType GetById(long Id)
        {
            DocumentType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getDocumentTypeById",
                        new object[] {
                            Id
                        });

                    returnvalue = DocumentTypeDataBinder.ToDocumentType(dv);
                }

                return returnvalue;
            }
        }

        public DocumentType Insert(DocumentType documentType)
        {
            DocumentType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertDocumentType",
                        new object[] {
                            documentType.FirmId,
                            documentType.Type,
                            (int)documentType.Status
                        });

                    returnvalue = DocumentTypeDataBinder.ToDocumentType(dv);
                }

                return returnvalue;
            }
        }

        public DocumentType Update(DocumentType documentType)
        {
            DocumentType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateDocumentType",
                        new object[] {
                            documentType.Id,
                            documentType.Type,
                            (int)documentType.Status
                        });

                    returnvalue = DocumentTypeDataBinder.ToDocumentType(dv);
                }

                return returnvalue;
            }
        }
    }
}

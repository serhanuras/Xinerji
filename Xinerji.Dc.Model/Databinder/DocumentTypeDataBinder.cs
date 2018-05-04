using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Utilities;


namespace Xinerji.Dc.Model.Databinder
{
    public static class DocumentTypeDataBinder
    {

        private static DocumentType GetDocumentTypeField(DataRowView drv)
        {
            return new DocumentType
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Type = UtilMethods.StripHTML(drv["Type"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static DocumentType ToDocumentType(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetDocumentTypeField(dv[0]);
            }

            return null;
        }

        public static List<DocumentType> ToDocumentTypeList(DataView dv)
        {
            List<DocumentType> truckStatusList = new List<DocumentType>();
            for (int i = 0; i < dv.Count; i++)
            {
                truckStatusList.Add(GetDocumentTypeField(dv[i]));
            }

            return truckStatusList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
namespace Xinerji.Dc.Model.Interfaces
{
    public interface IDocumentTypeService : IDisposable
    {
        DocumentType Insert(DocumentType documentType);

        DocumentType Update(DocumentType documentType);

        DocumentType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<DocumentType> GetAll(long firmId);

        DocumentType GetById(long Id);
    }
}

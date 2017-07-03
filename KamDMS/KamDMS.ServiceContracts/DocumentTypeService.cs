using KamDMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamDMS.Entities.Models.Doc;
using KamDMS.DaoContracts;

namespace KamDMS.ServiceContracts
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDaoHandler<DocumentType> docTypeDao;

        public DocumentTypeService(IDaoHandler<DocumentType> _docTypeDao)
        {
            this.docTypeDao = _docTypeDao;
        }
        public IEnumerable<DocumentType> GetAll
        {
            get
            {
                return docTypeDao.Get.Where(x=>x.IsDelete == false);
            }
        }

        public bool Create(DocumentType entity)
        {
            throw new NotImplementedException();
        }

        //public bool Create(DocumentType entity)
        //{

        //}

        public bool Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public DocumentType GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DocumentType entity)
        {
            throw new NotImplementedException();
        }
    }
}

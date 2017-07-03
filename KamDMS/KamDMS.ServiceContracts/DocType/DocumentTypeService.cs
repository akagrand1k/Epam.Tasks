using KamDMS.DaoContracts;
using KamDMS.Entities.Models.Doc;
using KamDMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.ServiceContracts.DocType
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDaoHandler<Entities.Models.Doc.DocumentType> typeRepo;
        public DocumentTypeService(IDaoHandler<Entities.Models.Doc.DocumentType> typeDoc)
        {
            typeRepo = typeDoc;
        }
        public IEnumerable<Entities.Models.Doc.DocumentType> GetAll
        {
            get
            {
                return typeRepo.Get;
            }
        }

        public bool Create(Entities.Models.Doc.DocumentType entity)
        {
            if (typeRepo.Add(entity))
            {
                return true;
            }
            throw new Exception("Error create type document");
        }

        public bool Delete(string Id)
        {
            var entity = typeRepo.GetById(Id);
            if (typeRepo.Delete(entity))
            {
                return true;
            }
            throw new Exception("Error delete type document");
        }

        public DocumentType GetById(string id)
        {
            var entity = typeRepo.GetById(id);
            return entity;
        }

        public bool Update(Entities.Models.Doc.DocumentType entity)
        {
            var model = typeRepo.GetById(entity.Id);

            model.TypeName = entity.TypeName;
            model.Id = entity.Id;
            model.DateUpdate = DateTime.Now;

            if (typeRepo.Update(model))
            {
                return true;
            }
            throw new Exception("Error update type document");
        }
    }
}
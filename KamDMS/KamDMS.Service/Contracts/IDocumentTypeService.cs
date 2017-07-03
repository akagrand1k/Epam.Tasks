using KamDMS.Entities.Models.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Service.Contracts
{
    public interface IDocumentTypeService
    {
        /// <summary>
        /// Get all items from storage
        /// </summary>
        IEnumerable<DocumentType> GetAll { get; }

        /// <summary>
        /// get one entity from storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return entity</returns>
        DocumentType GetById(string id);

        /// <summary>
        /// Update entity from storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        bool Update(DocumentType entity);

        /// <summary>
        /// Delete entity from storage
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bool</returns>
        bool Delete(string Id);

        /// <summary>
        /// Create entity from storage
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        bool Create(DocumentType entity);
    }
}

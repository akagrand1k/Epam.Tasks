using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models.Doc
{
    public class DocumentType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Document> FK_Document { get; set; }
    }
}

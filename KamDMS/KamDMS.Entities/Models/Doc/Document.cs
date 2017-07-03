using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models.Doc
{
    public class Document : BaseEntity
    {
        public string NameDoc { get; set; }
        public string TypeId { get; set; }
        public string NumberDoc { get; set; }
        public DateTime DateDoc { get; set; }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
        public string CreateUserId { get; set; }
        public string Path { get; set; }

        [ForeignKey("TypeId")]
        public virtual DocumentType FK_TypeDoc { get; set; }

        [ForeignKey("CreateUserId")]
        public virtual AppUser FK_User { get; set; }
    }
}

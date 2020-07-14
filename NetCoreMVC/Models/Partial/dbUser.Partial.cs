using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVC.Models.DBModel
{

    [MetadataType(typeof(dbUserMetadata))]
    public partial class dbUser
    {
        [NotMapped]
        public string BirthDay { get; set; }

    }
    public partial class dbUserMetadata
    {
        public Guid ID { get; set; }
        [Display(Name = "用戶名稱")]
        [Required(ErrorMessage = "員工姓名為必填項目!")]
        public string Name { get; set; }
        [Display(Name = "員工編號")]
        public string EmpNo { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

    }
}

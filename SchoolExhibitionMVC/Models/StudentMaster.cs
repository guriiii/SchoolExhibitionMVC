using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExhibitionMVC.Models
{
    public class StudentMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public int ExhibitionID { get; set; }
        public int ClassMasterID { get; set; }
        [ForeignKey("ExhibitionID")]
        public ExhibitionCoordinatorMaster Exhibition { get; set; }
        [ForeignKey("ClassMasterID")]
        public ClassMaster ClassMaster { get; set; }
    }
}

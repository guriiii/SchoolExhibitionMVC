using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExhibitionMVC.Models
{
    public class ExhibitionCoordinatorMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<StudentMaster> StudentMasters { get; set; }
    }
}

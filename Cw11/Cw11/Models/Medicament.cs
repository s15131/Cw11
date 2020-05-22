using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Medicament
    {
        public Medicament()
        {
            PrescriptionMedicament = new HashSet<PrescriptionMedicament>();
        }

        public int IdMedicament { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }

        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    }
}

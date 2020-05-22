using System;
using System.Collections;
using System.Collections.Generic;

namespace Cw11.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int IdPatient { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection <Prescription> Prescription { get; set; }
    }
}

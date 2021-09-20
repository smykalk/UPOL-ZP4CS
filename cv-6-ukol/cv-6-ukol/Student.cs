using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_6_ukol {
   class Student {
      public string osCislo { get; set; }
      public string jmeno { get; set; }
      public string prijmeni { get; set; }
      public string userName { get; set; }
      public int rocnik { get; set; }
      public string oborKomb { get; set; }

      public Student(string osCislo, string jmeno, string prijmeni, string userName, int rocnik, string oborKomb) {
         this.osCislo = osCislo;
         this.jmeno = jmeno;
         this.prijmeni = prijmeni;
         this.userName = userName;
         this.rocnik = rocnik;
         this.oborKomb = oborKomb;
      }

      public override string ToString() {
         return jmeno + " " + prijmeni;
      }
   }
}

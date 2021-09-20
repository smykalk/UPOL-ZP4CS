using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class studentiPredmetu {

   private Student[] studentPredmetuField;


   [System.Xml.Serialization.XmlElementAttribute("studentPredmetu")]
   public Student[] studentPredmetu {
      get {
         return this.studentPredmetuField;
      }
      set {
         this.studentPredmetuField = value;
      }
   }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class Student {

   private string osCisloField;

   private string jmenoField;

   private string prijmeniField;

   private string stavField;

   private string userNameField;

   private ushort stprIdnoField;

   private string nazevSpField;

   private string fakultaSpField;

   private string kodSpField;

   private string formaSpField;

   private string typSpField;

   private byte typSpKeyField;

   private string mistoVyukyField;

   private byte rocnikField;

   private byte financovaniField;

   private string oborKombField;

   private ushort oborIdnosField;

   private string emailField;

   private string cisloKartyField;

   private string pohlaviField;

   private string evidovanBankovniUcetField;

   private string statutPredmetuField;


   [Key]
   [Column(Order = 1)]
   public string osCislo {
      get {
         return this.osCisloField;
      }
      set {
         this.osCisloField = value;
      }
   }


   public string jmeno {
      get {
         return this.jmenoField;
      }
      set {
         this.jmenoField = value;
      }
   }


   public string prijmeni {
      get {
         return this.prijmeniField;
      }
      set {
         this.prijmeniField = value;
      }
   }


   public string stav {
      get {
         return this.stavField;
      }
      set {
         this.stavField = value;
      }
   }


   public string userName {
      get {
         return this.userNameField;
      }
      set {
         this.userNameField = value;
      }
   }

   [XmlElement("stprIdno")]
   public ushort stprno {
      get {
         return this.stprIdnoField;
      }
      set {
         this.stprIdnoField = value;
      }
   }


   public string nazevSp {
      get {
         return this.nazevSpField;
      }
      set {
         this.nazevSpField = value;
      }
   }


   public string fakultaSp {
      get {
         return this.fakultaSpField;
      }
      set {
         this.fakultaSpField = value;
      }
   }


   public string kodSp {
      get {
         return this.kodSpField;
      }
      set {
         this.kodSpField = value;
      }
   }


   public string formaSp {
      get {
         return this.formaSpField;
      }
      set {
         this.formaSpField = value;
      }
   }


   public string typSp {
      get {
         return this.typSpField;
      }
      set {
         this.typSpField = value;
      }
   }


   public byte typSpKey {
      get {
         return this.typSpKeyField;
      }
      set {
         this.typSpKeyField = value;
      }
   }


   public string mistoVyuky {
      get {
         return this.mistoVyukyField;
      }
      set {
         this.mistoVyukyField = value;
      }
   }


   public byte rocnik {
      get {
         return this.rocnikField;
      }
      set {
         this.rocnikField = value;
      }
   }


   public byte financovani {
      get {
         return this.financovaniField;
      }
      set {
         this.financovaniField = value;
      }
   }


   public string oborKomb {
      get {
         return this.oborKombField;
      }
      set {
         this.oborKombField = value;
      }
   }

   [XmlElement("oborIdnos")]
   public ushort obornos {
      get {
         return this.oborIdnosField;
      }
      set {
         this.oborIdnosField = value;
      }
   }


   public string email {
      get {
         return this.emailField;
      }
      set {
         this.emailField = value;
      }
   }


   public string cisloKarty {
      get {
         return this.cisloKartyField;
      }
      set {
         this.cisloKartyField = value;
      }
   }


   public string pohlavi {
      get {
         return this.pohlaviField;
      }
      set {
         this.pohlaviField = value;
      }
   }


   public string evidovanBankovniUcet {
      get {
         return this.evidovanBankovniUcetField;
      }
      set {
         this.evidovanBankovniUcetField = value;
      }
   }


   public string statutPredmetu {
      get {
         return this.statutPredmetuField;
      }
      set {
         this.statutPredmetuField = value;
      }
   }

   public Student() {
   }

   public Student(string osCislo, string jmeno, string prijmeni, string stav, string userName, ushort stprIdno, string nazevSp, string fakultaSp, string kodSp, string formaSp, string typSp, byte typSpKey, string mistoVyuky, byte rocnik, byte financovani, string oborKomb, ushort oborIdnos, string email, string cisloKarty, string pohlavi, string evidovanBankovniUcet, string statutPredmetu) {
      this.osCislo = osCislo;
      this.jmeno = jmeno;
      this.prijmeni = prijmeni;
      this.stav = stav;
      this.userName = userName;
      this.stprno = stprIdno;
      this.nazevSp = nazevSp;
      this.fakultaSp = fakultaSp;
      this.kodSp = kodSp;
      this.formaSp = formaSp;
      this.typSp = typSp;
      this.typSpKey = typSpKey;
      this.mistoVyuky = mistoVyuky;
      this.rocnik = rocnik;
      this.financovani = financovani;
      this.oborKomb = oborKomb;
      this.obornos = oborIdnos;
      this.email = email;
      this.cisloKarty = cisloKarty;
      this.pohlavi = pohlavi;
      this.evidovanBankovniUcet = evidovanBankovniUcet;
      this.statutPredmetu = statutPredmetu;
   }
}

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
using System.Collections.Generic;
using System.Xml.Serialization;
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class predmetyKatedry {

	private predmetyKatedryPredmetKatedry[] predmetKatedryField;

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("predmetKatedry")]
	public predmetyKatedryPredmetKatedry[] predmetKatedry {
		get {
			return this.predmetKatedryField;
		}
		set {
			this.predmetKatedryField = value;
		}
	}
}

/////////////////////////////
[XmlRoot("predmetyKatedry")]
public class SubjectsList {
	public SubjectsList() { Items = new List<predmetyKatedryPredmetKatedry>(); }
	[XmlElement("predmetKatedry")]
	public List<predmetyKatedryPredmetKatedry> Items;
}
/////////////////////////////

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class predmetyKatedryPredmetKatedry {

	private string katedraField;

	private string zkratkaField;

	private ushort rokField;

	private string nazevField;

	private string semestrField;

	private string maVyukuField;

	private string vyukaZSField;

	private string vyukaLSField;

	private string jazyk1Field;

	private string jazyk2Field;

	private string nabizetPrijezdyEctsField;

	private byte pocetStudentuField;

	private byte aMaxField;

	private bool aMaxFieldSpecified;

	private byte bMaxField;

	private bool bMaxFieldSpecified;

	private byte cMaxField;

	private bool cMaxFieldSpecified;

	private byte aSkutField;

	private byte bSkutField;

	private byte cSkutField;

	/// <remarks/>
	public string katedra {
		get {
			return this.katedraField;
		}
		set {
			this.katedraField = value;
		}
	}

	/// <remarks/>
	public string zkratka {
		get {
			return this.zkratkaField;
		}
		set {
			this.zkratkaField = value;
		}
	}

	/// <remarks/>
	public ushort rok {
		get {
			return this.rokField;
		}
		set {
			this.rokField = value;
		}
	}

	/// <remarks/>
	public string nazev {
		get {
			return this.nazevField;
		}
		set {
			this.nazevField = value;
		}
	}

	/// <remarks/>
	public string semestr {
		get {
			return this.semestrField;
		}
		set {
			this.semestrField = value;
		}
	}

	/// <remarks/>
	public string maVyuku {
		get {
			return this.maVyukuField;
		}
		set {
			this.maVyukuField = value;
		}
	}

	/// <remarks/>
	public string vyukaZS {
		get {
			return this.vyukaZSField;
		}
		set {
			this.vyukaZSField = value;
		}
	}

	/// <remarks/>
	public string vyukaLS {
		get {
			return this.vyukaLSField;
		}
		set {
			this.vyukaLSField = value;
		}
	}

	/// <remarks/>
	public string jazyk1 {
		get {
			return this.jazyk1Field;
		}
		set {
			this.jazyk1Field = value;
		}
	}

	/// <remarks/>
	public string jazyk2 {
		get {
			return this.jazyk2Field;
		}
		set {
			this.jazyk2Field = value;
		}
	}

	/// <remarks/>
	public string nabizetPrijezdyEcts {
		get {
			return this.nabizetPrijezdyEctsField;
		}
		set {
			this.nabizetPrijezdyEctsField = value;
		}
	}

	/// <remarks/>
	public byte pocetStudentu {
		get {
			return this.pocetStudentuField;
		}
		set {
			this.pocetStudentuField = value;
		}
	}

	/// <remarks/>
	public byte aMax {
		get {
			return this.aMaxField;
		}
		set {
			this.aMaxField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIgnoreAttribute()]
	public bool aMaxSpecified {
		get {
			return this.aMaxFieldSpecified;
		}
		set {
			this.aMaxFieldSpecified = value;
		}
	}

	/// <remarks/>
	public byte bMax {
		get {
			return this.bMaxField;
		}
		set {
			this.bMaxField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIgnoreAttribute()]
	public bool bMaxSpecified {
		get {
			return this.bMaxFieldSpecified;
		}
		set {
			this.bMaxFieldSpecified = value;
		}
	}

	/// <remarks/>
	public byte cMax {
		get {
			return this.cMaxField;
		}
		set {
			this.cMaxField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIgnoreAttribute()]
	public bool cMaxSpecified {
		get {
			return this.cMaxFieldSpecified;
		}
		set {
			this.cMaxFieldSpecified = value;
		}
	}

	/// <remarks/>
	public byte aSkut {
		get {
			return this.aSkutField;
		}
		set {
			this.aSkutField = value;
		}
	}

	/// <remarks/>
	public byte bSkut {
		get {
			return this.bSkutField;
		}
		set {
			this.bSkutField = value;
		}
	}

	/// <remarks/>
	public byte cSkut {
		get {
			return this.cSkutField;
		}
		set {
			this.cSkutField = value;
		}
	}
}


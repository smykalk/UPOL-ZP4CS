using System;
using System.Xml;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cv_4_ukol {
	class FileOperations {
		public static void ReadStudentsWriteSecondYear(string readpath, string writepath) {
			XmlDocument studentsDoc = new XmlDocument();

			try {
				studentsDoc.Load(readpath);
				StreamWriter sw = new StreamWriter(writepath);

				XmlNodeList students = studentsDoc.GetElementsByTagName("studentPredmetu");

				sw.Write("[");

				int nodecounter = students.Count;
				bool notFirstEntry = false;
				//manualni zapis do json
				foreach (XmlNode node in students) {
					string str = "";

					if (notFirstEntry)
						str += ","; //oddelovace mezi zaznamy

					str += "{";

					bool write = true;

					int childcounter = node.ChildNodes.Count;
					foreach (XmlNode child in node.ChildNodes) {
						if (child.Name == "rocnik" && child.InnerText != "2") //filtr druheho rocniku
							write = false;
						str += "\"" + child.Name + "\"" + ": " + "\"" + child.InnerText + "\""; //json format
						childcounter--;
						if (childcounter != 0) {
							str += ",";
						}
					}

					str += "}";

					if (write) {
						sw.Write(str);
						notFirstEntry = true;
					}
				}

				sw.Write("]");
				sw.Flush();
				sw.Close();
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}


		public static void DeserializeSubjectsWriteFirstN(string readpath, string writepath, int n) {
			XmlSerializer deserializer = new XmlSerializer(typeof(SubjectsList));

			var subjects = new SubjectsList();

			try {
				using (var reader = new StreamReader(readpath)) {
					subjects = (SubjectsList)deserializer.Deserialize(reader);
				}

				subjects.Items.RemoveRange(n,subjects.Items.Count - n);

				using (var writer = new StreamWriter(writepath)) {
					deserializer.Serialize(writer, subjects);
					writer.Flush();
				}
			}
			catch(Exception e) {
				Console.WriteLine(e.Message);
			}
		}


		public static void ReadStudentsWritePeters(string readpath, string writepath) {
			try {
				using (StreamReader file = File.OpenText(readpath)) {
					var serializer = new JavaScriptSerializer();

					//deserializace do listu
					var teachers = serializer.Deserialize<List<Teacher>>(file.ReadToEnd());


					teachers.RemoveAll(NameNotPetr);

					//manualni zapis do xml
					XmlDocument teachersxml = new XmlDocument();
					XmlDeclaration xmlDeclaration = teachersxml.CreateXmlDeclaration("1.0", "UTF-8", null);
					XmlElement root = teachersxml.DocumentElement;
					teachersxml.InsertBefore(xmlDeclaration, root);

					XmlElement Ucitele = teachersxml.CreateElement("Ucitele");

					foreach (Teacher t in teachers) {
						XmlElement Ucitel = teachersxml.CreateElement("Ucitel");

						XmlElement ucitIdno = teachersxml.CreateElement("ucitIdno");
						ucitIdno.InnerText = t.ucitIdno.ToString();
						Ucitel.AppendChild(ucitIdno);

						XmlElement jmeno = teachersxml.CreateElement("jmeno");
						jmeno.InnerText = t.jmeno;
						Ucitel.AppendChild(jmeno);

						XmlElement prijmeni = teachersxml.CreateElement("prijmeni");
						prijmeni.InnerText = t.prijmeni;
						Ucitel.AppendChild(prijmeni);

						XmlElement titulPred = teachersxml.CreateElement("titulPred");
						titulPred.InnerText = t.titulPred;
						Ucitel.AppendChild(titulPred);

						XmlElement titulZa = teachersxml.CreateElement("titulZa");
						titulZa.InnerText = t.titulZa;
						Ucitel.AppendChild(titulZa);

						XmlElement platnost = teachersxml.CreateElement("platnost");
						platnost.InnerText = t.platnost;
						Ucitel.AppendChild(platnost);

						XmlElement zamestnanec = teachersxml.CreateElement("zamestnanec");
						zamestnanec.InnerText = t.zamestnanec;
						Ucitel.AppendChild(zamestnanec);

						XmlElement katedra = teachersxml.CreateElement("katedra");
						katedra.InnerText = t.katedra;
						Ucitel.AppendChild(katedra);

						XmlElement pracovisteDalsi = teachersxml.CreateElement("pracovisteDalsi");
						pracovisteDalsi.InnerText = t.pracovisteDalsi;
						Ucitel.AppendChild(pracovisteDalsi);

						XmlElement email = teachersxml.CreateElement("email");
						email.InnerText = t.email;
						Ucitel.AppendChild(email);

						XmlElement telefon = teachersxml.CreateElement("telefon");
						telefon.InnerText = t.telefon;
						Ucitel.AppendChild(telefon);

						XmlElement telefon2 = teachersxml.CreateElement("telefon2");
						telefon2.InnerText = t.telefon2;
						Ucitel.AppendChild(telefon2);

						XmlElement url = teachersxml.CreateElement("url");
						url.InnerText = t.url;
						Ucitel.AppendChild(url);

						Ucitele.AppendChild(Ucitel);
					}

					teachersxml.AppendChild(Ucitele);

					XmlTextWriter xmlTextWriter = new XmlTextWriter(File.Create(writepath), Encoding.UTF8);
					xmlTextWriter.Formatting = Formatting.Indented;
					teachersxml.WriteContentTo(xmlTextWriter);
					xmlTextWriter.Close();
				}
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		private static bool NameNotPetr(Teacher t) {
			return t.jmeno != "Petr";
		}
	}
}

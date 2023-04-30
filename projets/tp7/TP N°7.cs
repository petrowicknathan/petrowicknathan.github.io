using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace AnalyseFilm
{
    class Program
    {
        // déclaration de la structure
        public struct CarFilm
        {
            public string nom;
            public string mois;
            public int annee;
            public int nbSeance;
            public int nbEntEnfant;
            public int nbEntAdulte;
            

        }
        static void Main(string[] args)
        {
            // déclaration des variables
            // --------------------------
            string valeurSaisie;
            int option;
            int mtTotnbSeance;
            int nbEntEnfant;
            int mtTotnbFilm;

            // variable de type structure qui contient les caractéristiques d'un film
            CarFilm unFilm;

            // déclaration du tableau de structure
            List<CarFilm> lesFilms;

            // variable représentant le fichier XML
            XmlDocument fichierFilm;

            // variable pour l'ajout d'un film dans le fichier XML
            XmlNode noeudNom;
            XmlNode noeudMois;
            XmlNode noeudAnnee;
            XmlNode noeudNbSeance;
            XmlNode noeudNbEnf;
            XmlNode noeudNbAdul;

            //nom du fichier XML
            string nomFichier = "C:/Users/Petrowick.STSSIO/Desktop/bloc1/fichiers/entrees-cine.xml";

            // on crée le tableau de structure qui contiendra les caractéristiques des films
            lesFilms = new List<CarFilm>();

            // chargement du fichier XML dans la liste de structures
            if (File.Exists(nomFichier) == false)
            {
                Console.WriteLine("Traitement impossible car le fichier n'existe pas.");
            }
            else
            {
                #region Chargement des données du fichier XML dans le tableau de structures
                // on déclare un  objet qui permettra de travailler avec le fichier XML
                fichierFilm = new XmlDocument();

                // on charge le fichier XML dans l'objet
                fichierFilm.Load(nomFichier);

                // on récupère toutes les balise <film> dans une liste qui s'appelle listeBaliseXMLFilm
                XmlNodeList listeBaliseXMLFilm = fichierFilm.GetElementsByTagName("film");

                // pour chaque balise film
                foreach (XmlNode unfilmXML in listeBaliseXMLFilm)
                {
                    // on crée une variable de type structure de film et on renseigne ses caractéristiques
                    unFilm = new CarFilm(); 

                    // on récupère le nom du film (1er enfant de la balise film)
                    unFilm.nom = unfilmXML.ChildNodes[0].InnerText;

                    // on récupère le mois (2ème enfant de la balise film)
                    unFilm.mois = unfilmXML.ChildNodes[1].InnerText;

                    // on récupère l'année (3ème enfant de la balise film)
                    unFilm.annee = Convert.ToInt32(unfilmXML.ChildNodes[2].InnerText);

                    // on récupère le nombre de séances (4ème enfant de la balise film) 
                    unFilm.nbSeance = Convert.ToInt32(unfilmXML.ChildNodes[3].InnerText);

                    // on récupère le le nombre d'entrées pour les enfants (5ème enfant de la balise film)
                    unFilm.nbEntEnfant = Convert.ToInt32(unfilmXML.ChildNodes[4].InnerText);

                    // on récupère le le nombre d'entrées pour les adultes (6ème enfant de la balise film)
                    unFilm.nbEntAdulte = Convert.ToInt32(unfilmXML.ChildNodes[5].InnerText);

                    // ajout de l'élément dans le tableau
                    lesFilms.Add(unFilm);
                }
                #endregion
            }
            do
            {
                #region Affichage du menu et récupération de l'option choisie (variable option)
                do
                {
                    // on efface ce qui est affiché sur la console
                    Console.Clear();

                    // affichage du menu
                    Console.WriteLine("1. Voir les informations déjà saisies");
                    Console.WriteLine("2. Ajouter un nouveau film");
                    Console.WriteLine("3. Voir le nombre total de séances");
                    Console.WriteLine("4. Voir le nombre de films qui ont fait plus de 100 entrées enfant");
                    Console.WriteLine("5. Voir les films projetés en décembre");
                    Console.WriteLine("6. Voir le nombre d'entrées pour un mois choisi");
                    Console.WriteLine("7. Sortie du menu");
                    Console.Write("Veuillez choisir votre option : ");

                    // récupération de la valeur choisie par l'utilisateur
                    valeurSaisie = Console.ReadLine();
                    int.TryParse(valeurSaisie, out option);

                    // contrôle de la valeur de l'option
                    if (option < 1 || option > 7)
                    {
                        Console.WriteLine("Saisie erronée : l'option doit être comprise entre 1 et 6");
                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                    }

                } while (option < 1 || option > 7);
                #endregion

                switch (option)
                {
                    case 1:
                        // affichage des valeurs chargées dans le tableau
                        foreach (CarFilm unEle in lesFilms)
                        {
                            Console.WriteLine("\n" + unEle.nom);
                            Console.WriteLine("Ce film  a été passé " + unEle.nbSeance + " fois en " + unEle.mois + " " + unEle.annee);
                            Console.WriteLine("Nombre de tickets vendu pour les enfants " + unEle.nbEntEnfant);
                            Console.WriteLine("Nombre de tickets vendu pour les adultes " + unEle.nbEntAdulte);
                        }
                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                        break;
                    case 2:
                        // Ajouter les caractéristiques d'un nouveau film

                        #region On fait saisir les caractéristiques et on les ajoute dans le tableau de structure

                        unFilm = new CarFilm();

                        Console.Write("\nVeuillez saisir le nom du film : ");
                        unFilm.nom = Console.ReadLine();

                        Console.Write("\nVeuillez saisir le mois pour lequel vous souhaitez saisir les caractéristiques de fréquentation : ");
                        unFilm.mois = Console.ReadLine();

                        Console.Write("\nVeuillez saisir l'année pour laquelle vous souhaitez saisir les caractéristiques de fréquentation : ");
                        valeurSaisie = Console.ReadLine();
                        int.TryParse(valeurSaisie, out unFilm.annee);

                        Console.Write("\nVeuillez saisir le nombre de séances : ");
                        valeurSaisie = Console.ReadLine();
                        int.TryParse(valeurSaisie, out unFilm.nbSeance);

                        Console.Write("\nVeuillez saisir le nombre de places enfants vendues : ");
                        valeurSaisie = Console.ReadLine();
                        int.TryParse(valeurSaisie, out unFilm.nbEntEnfant);

                        Console.Write("\nVeuillez saisir le nombre de places adultes vendues : ");
                        valeurSaisie = Console.ReadLine();
                        int.TryParse(valeurSaisie, out unFilm.nbEntAdulte);

                        // ajout de l'élément dans le tableau
                        lesFilms.Add(unFilm);

                        #endregion

                        #region On ajoute les caractéristiques saisies dans le fichier XML
                        // Ouverture du fichier et chargement en mémoire
                        fichierFilm = new XmlDocument();
                        fichierFilm.Load(nomFichier);

                        // création d'un nouvel élément  <film>
                        System.Xml.XmlElement elementFilm = fichierFilm.CreateElement("film");

                        // Création d'un noeud <nom> contenant le nom du film
                        noeudNom = fichierFilm.CreateElement("nom");
                        noeudNom.InnerText = unFilm.nom;

                        // Création du noeud <mois> contenant le mois
                        noeudMois = fichierFilm.CreateElement("mois");
                        noeudMois.InnerText = unFilm.mois;

                        // création du noeud <annee> contenant l'année
                        noeudAnnee = fichierFilm.CreateElement("annee");
                        noeudAnnee.InnerText = unFilm.annee.ToString();

                        // création du noeud <nb-seance> contenant le nombre de séances
                        noeudNbSeance = fichierFilm.CreateElement("nb-seance");
                        noeudNbSeance.InnerText = unFilm.nbSeance.ToString();

                        // création du noeud <nb-entree-enfant> contenant le nombre d'entrées enfant
                        noeudNbEnf = fichierFilm.CreateElement("nb-entree-enfant");
                        noeudNbEnf.InnerText = unFilm.nbEntEnfant.ToString();

                        // création du noeud <nb-entree-adulte> contenant le nombre d'entrées adulte
                        noeudNbAdul = fichierFilm.CreateElement("nb-entree-adulte");
                        noeudNbAdul.InnerText = unFilm.nbEntAdulte.ToString();

                        // ajout des nœuds <nom> <mois> <annee> etc. que l'on vient de créer à l'élément <film>
                        elementFilm.AppendChild(noeudNom);
                        elementFilm.AppendChild(noeudMois);
                        elementFilm.AppendChild(noeudAnnee);
                        elementFilm.AppendChild(noeudNbSeance);
                        elementFilm.AppendChild(noeudNbEnf);
                        elementFilm.AppendChild(noeudNbAdul);

                        // on récupère le noeud racine existant
                        XmlNode racine = fichierFilm.SelectSingleNode("frequentation");

                        // ajout du noeud <film> à la racine <frequentation>
                        racine.AppendChild(elementFilm);

                        // sauvegarde du document XML sur le disque
                        fichierFilm.Save("c:\\bloc1\\fichiers\\entrees-cine.xml");

                        #endregion

                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                        break;
                    case 3:
                        // Voir le nombre total de séances
                        mtTotnbSeance = 0;
                        foreach (CarFilm uneCar in lesFilms)
                        {
                            mtTotnbSeance = mtTotnbSeance + uneCar.nbSeance;
                        }
                        Console.WriteLine("Nombre total de Séances : " + mtTotnbSeance);

                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                        break;
                    case 4:
                        // Voir le nombre de films qui ont fait plus de 100 entrées enfant
                        nbEntEnfant = 0;
                        mtTotnbFilm = 0;
                        foreach (CarFilm uneCar in lesFilms) 
                        {
                            if (nbEntEnfant > 100) 
                            {
                                mtTotnbFilm = mtTotnbFilm + uneCar.nbEntEnfant;
                            }
                        }
                        Console.WriteLine("Nombre de film avec plus de 100 entrées enfant : " + mtTotnbFilm);

                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option : " );
                        Console.ReadLine();
                        break;
                    case 5:
                        // Voir le nom des films projetés en décembre
                        // TODO
                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                        break;
                    case 6:
                        // Voir le nombre d'entrées pour un mois choisi
                        // TODO
                        Console.WriteLine("Appuyez sur entrée pour choisir une autre option");
                        Console.ReadLine();
                        break;
                }

            } while (option != 7);
        }
    }
} 

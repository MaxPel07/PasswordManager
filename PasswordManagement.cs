/// ETML
/// Auteur : Maxime Pelloquin
/// Date de création :      19.03.2024
/// Dernière modification : 26.03.2024
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDeMotDePasse
{
    internal class PasswordManagement
    {
        /// <summary>
        /// 
        /// </summary>
        public static void ViewPassword()
        {
            string folderPath = Program.FolderPath;
            int passwordNumberNisplay = 2;

            Console.WriteLine("***************************************\n" +
                              "Consulter un mot de passe :\n" +
                              "1. Retour au menu principal");

            // Vérifie si le dossier existe
            if (Directory.Exists(folderPath))
            {
                // Récupère tous les fichiers dans le dossier spécifié
                string[] passwordFiles = Directory.GetFiles(folderPath);

                // Récupère le nombre de fichier de mot de passe
                int nbOfPassword = passwordFiles.Length;

                // Affiche les noms de tous les fichiers
                for (int i = 0; i < nbOfPassword; i++)
                {
                    Console.WriteLine(passwordNumberNisplay + ". " + Path.GetFileNameWithoutExtension(passwordFiles[i]));
                    passwordNumberNisplay ++;
                }

                Console.WriteLine("***************************************");
                Console.Write("Faites votre choix : ");

                // Lecture de l'entrée utilisateur
                string userInput = Console.ReadLine();

                // Vérification si l'entrée est un nombre valide
                if (int.TryParse(userInput, out int selectedFileNumber) && selectedFileNumber >= 2 && selectedFileNumber <= nbOfPassword + 1)
                {
                    // Lecture du contenu du fichier sélectionné
                    string selectedFilePath = passwordFiles[selectedFileNumber - 2];
                    string encryptedText = File.ReadAllText(selectedFilePath);

                    // Affichage du contenu du fichier
                    Console.WriteLine("\n" + TextDecryption(encryptedText));

                    // Revenir au menu en appuyant sur Enter
                    Console.WriteLine("Appuyer sur Enter pour masquer le mot de passe");
                    Console.ReadLine();
                    Console.Clear();
                    ViewPassword();
                }
                else if (selectedFileNumber == 1) 
                {
                    Console.Clear();
                    Program.Showmenu();
                }
                else
                {
                    Console.WriteLine("ERREUR : Entrée invalide");
                    Console.ReadLine();
                    Console.Clear();
                    ViewPassword();
                }
            }
            else
            {
                Console.WriteLine("Erreur : le dossier de mot de passe n'existe pas");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void AddPasswordMenu()
        {
            Console.WriteLine("********************************\n" +
                              "Ajouter un mot de passe :\n" +
                              "1. Retour au menu principal\n" +
                              "2. Ajouter un mot de passe");

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Program.Showmenu();
                    break;

                case '2':
                    Console.Clear();
                    AddPassword();
                    break;
                
                default:
                    Console.Clear();
                    AddPasswordMenu();
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddPassword()
        {
            string folderPath = Program.FolderPath;

            // Vérifie si le dossier existe
            if (Directory.Exists(folderPath))
            {
                // Demande le nom du site
                Console.Write("Nom du site : ");

                // Lecture de l'entrée utilisateur
                string userInput = Console.ReadLine();
                if(userInput.Length != 0)
                {
                    // Créer le chemin vers le nouveau mot de passe
                    string filePath = Path.Combine(folderPath, userInput + ".txt");

                    // Demande l'URL du site
                    Console.Write("URL : ");

                    // Lecture de l'entrée utilisateur
                    string userInputURL = Console.ReadLine();



                    // Demande le login du site
                    Console.Write("LOGIN : ");

                    // Lecture de l'entrée utilisateur
                    string userInputLogin = Console.ReadLine();


                    // Demande le mot de passe du site
                    Console.Write("MOT DE PASSE : ");

                    // Lecture de l'entrée utilisateur
                    string userInputPassword = Console.ReadLine();


                    // Création du text à mettre dans le fichier du mot de passe
                    string textWithoutEncryption = ("URL : " + userInputURL +
                                            "\nLOGIN : " + userInputLogin +
                                            "\nMOT DE PASSE : " + userInputPassword);

                    // Ecriture dans le fichier text du mot de passe chiffré
                    File.WriteAllText(filePath, TextEncryption(textWithoutEncryption));

                    Console.WriteLine("\nmot de passe ajouté avec succès");
                    Console.ReadLine();
                    Program.Showmenu();
                }
                else
                {
                    Console.Write("ERREUR : champ vide");
                    Console.ReadLine();
                    Console.Clear();
                    AddPassword();
                }
            }
            else
            {
                Console.Write("Erreur : le dossier de mot de passe n'existe pas");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void RemovePassword()
        {
            string folderPath = Program.FolderPath;
            int passwordNumberNisplay = 2;

            Console.WriteLine("***************************************\n" +
                              "Supprimer un mot de passe :\n" +
                              "1. Retour au menu principal");

            // Vérifie si le dossier existe
            if (Directory.Exists(folderPath))
            {
                // Récupère tous les fichiers dans le dossier spécifié
                string[] passwordFiles = Directory.GetFiles(folderPath);

                // Récupère le nombre de fichier de mot de passe
                int nbOfPassword = passwordFiles.Length;

                // Affiche les noms de tous les fichiers
                for (int i = 0; i < nbOfPassword; i++)
                {
                    Console.WriteLine(passwordNumberNisplay + ". " + Path.GetFileNameWithoutExtension(passwordFiles[i]));
                    passwordNumberNisplay++;
                }

                Console.WriteLine("***************************************");
                Console.Write("Faites votre choix : ");

                // Lecture de l'entrée utilisateur
                string userInput = Console.ReadLine();

                
                if (int.TryParse(userInput, out int selectedFileNumber) && selectedFileNumber >= 2 && selectedFileNumber <= nbOfPassword + 1)
                {
                    // Index du fichier sélectionné dans le tableau
                    int selectedFileIndex = selectedFileNumber - 2;

                    // Nom du fichier sélectionné
                    string selectedFileName = Path.GetFileNameWithoutExtension(passwordFiles[selectedFileIndex]);

                    // Chemin complet du fichier sélectionné
                    string selectedFilePath = passwordFiles[selectedFileIndex];

                    // Message de verification à l'utilisateur
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Etes-vous sur de vouloir supprimer ce mot de passe : " + selectedFileName + " ?"); //implémenter le code pour le nom du mot de passe
                    Console.ResetColor();
                    Console.Write("Confirmez (O/N) : ");
                    string confirmation = Console.ReadLine().ToLower();
                    
                    if(confirmation == "o")
                    {
                        // Supprimer le fichier
                        File.Delete(selectedFilePath);
                        Console.WriteLine("Le mot de passe a été supprimé avec succès.");
                    }
                    else if(confirmation == "n")
                    {
                        // La suppression n'a pas abouti
                        Console.WriteLine("Opération annulée.");
                    }
                    else
                    {
                        // L'utilisateur n'a rentré ni "o" ni "n"
                        Console.WriteLine("Réponse non valide. Opération annulée.");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    RemovePassword();
                }
                else if (userInput == "1")
                {
                    Program.Showmenu();
                }
                else
                {
                    Console.WriteLine("ERREUR : Entrée invalide");
                    Console.ReadLine();
                    Console.Clear();
                    RemovePassword();
                }
            }
            else
            {
                Console.Write("Erreur : le dossier de mot de passe n'existe pas");
            }
        }

        public static string TextEncryption(string textWithoutEncryption)
        {
            string masterPassword = Program.masterPassword;

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < textWithoutEncryption.Length; i++)
            {
                char caractere = textWithoutEncryption[i];
                char cle = masterPassword[i % masterPassword.Length]; // Répétition du mot de passe

                // Calcul du caractère chiffré
                char caractereChiffre = (char)(caractere + cle);
                encryptedText.Append(caractereChiffre);
            }

            return encryptedText.ToString();
        }

        public static string TextDecryption(string encryptedText)
        {
            string masterPassword = Program.masterPassword;

            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                char caractereChiffre = encryptedText[i];
                char cle = masterPassword[i % masterPassword.Length]; // Répétition du mot de passe

                // Calcul du caractère déchiffré
                char caractereDechiffre = (char)(caractereChiffre - cle);
                decryptedText.Append(caractereDechiffre);
            }

            return decryptedText.ToString();
        }
    }
}

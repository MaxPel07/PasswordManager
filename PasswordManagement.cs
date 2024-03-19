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
                    string fileContent = File.ReadAllText(selectedFilePath);

                    // Affichage du contenu du fichier
                    Console.WriteLine("\n" + fileContent);

                    // Revenir au menu en appuyant sur Enter
                    Console.WriteLine("Appuyer sur Enter pour masquer le mot de passe et revenir au menu");
                }
                else
                {
                    Console.Clear();
                    Program.Main();
                }
            }

            // Message d'erreur si le dossier password n'existe pas
            else
            {
                Console.WriteLine("Le dossier spécifié n'existe pas.");
            }

            Console.ReadLine();

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    Program.Main();
                    Console.Clear();
                    break;

                case '2':
                    PasswordManagement.AddPassword();
                    Console.Clear();
                    break;
            }
            Console.ReadLine();
        }

        public static void AddPassword()
        {
            Console.WriteLine("********************************\n" +
                              "Ajouter un mot de passe :\n" +
                              "1. Retour au menu principal");
            Console.ReadLine();
        }

        public static void RemovePassword()
        {

        }
    }
}

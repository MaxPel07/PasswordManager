/// ETML
/// Auteur : Maxime Pelloquin
/// Date de création :      19.03.2024
/// Dernière modification : 26.03.2024
/// Description : Ce programme est un gestionnaire de mot de passe. Il utilise pour l'instant la méthode du chiffrement par décalage (Code César)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDeMotDePasse
{
    public class Program
    {
        // chemin du dossier password
        public static string FolderPath { get; } = @"D:\Semestre 2\I114_codificationChiffrement\Projet\password";

        // mot de passe maitre
        public static string masterPassword { get; } = "abc";

        public static void Main()
        {
            // mot de passe maitre
            //const string masterPassword = "abc";

            // Entrer le mot de passe maître pour accéder aux mdp
            Console.Write("Master password = abc\n" +
                          "*********************************\n" +
                          "*  GESTIONAIRE DE MOT DE PASSE  *\n" +
                          "*********************************\n\n" +
                          "Entrez le mot de passe : ");

            string userInput = Console.ReadLine();

            if (userInput == masterPassword)
            {
                Showmenu();
            }
            else
            {
                Console.Clear();
                Main();
            }
        }

        public static void Showmenu()
        {
            Console.Clear();
            Console.Write("*******************************************\n" +
                          "Sélectionnez une action\n" +
                          "1. Consulter un mot de passe\n" +
                          "2. Bloquer la session\n" +
                          "3. Ajouter un mot de passe\n" +
                          "4. Supprimer un mot de passe\n" +
                          "5. Quitter le programme\n" +
                          "*******************************************\n\n" +
                          "Faites votre choix : ");


            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    PasswordManagement.ViewPassword();
                    break;

                case '2':
                    Console.Clear();
                    Main();
                    break;


                case '3':
                    Console.Clear();
                    PasswordManagement.AddPasswordMenu();
                    break;

                case '4':
                    Console.Clear();
                    PasswordManagement.RemovePassword();
                    break;

                case '5':
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nL'entrée n'est pas valide");
                    Console.ReadLine();
                    Showmenu();
                    break;

            }
            Console.ReadLine();
        }
    }
}

/// ETML
/// Auteur : Maxime Pelloquin
/// Date de création :      19.03.2024
/// Dernière modification : 19.03.2024
/// Description : Ce programme est un gestionnaire de mot de passe. Il utilise pour l'instant la méthode du chiffrement par décalage (Code César)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDeMotDePasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // chemin du dossier password
            string folderPath = @"D:\Semestre 2\I114_codificationChiffrement\Projet\password";

            // nom du fichier qui contient les mots de passe
            string fileName = "password.txt";

            // chemin du fichier txt de mot de passe
            string filePath = Path.Combine(folderPath, fileName);


            // Vérifie si le fichier existe
            if (!File.Exists(filePath))
            {
                // Crée un nouveau fichier s'il n'existe
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    // test d'écriture dans le fichier txt
                    sw.WriteLine("Contenu initial du fichier...");
                }

                Console.WriteLine("Le fichier " + fileName + " a été créé avec succès.");
            }

            Console.Write("Master password = abc\n"+
                          "*******************************************\n" +
                          "Sélectionnez une action\n" +
                          "1. Consulter un mot de passe\n" +
                          "2. Ajouter un mot de passe\n" +
                          "3. Supprimer un mot de passe\n" +
                          "4. Quitter le programme\n" +
                          "*******************************************\n\n" +
                          "Faites votre choix : ");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    PasswordManagement.ViewPassword();
                    Console.Clear();
                    break;

                case '2':
                    PasswordManagement.AddPassword();
                    Console.Clear();
                    break;

                case '3':
                    PasswordManagement.RemovePassword();
                    Console.Clear();
                    break;

                case '4':
                    Environment.Exit(0);
                    break;
            }
            Console.ReadLine();
        }
    }
}

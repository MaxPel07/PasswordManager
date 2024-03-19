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
    public class Program
    {
        // chemin du dossier password
        public static string FolderPath { get; } = @"E:\Semestre 2\I114_codificationChiffrement\Projet\password";
        
        public static void Main()
        {
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
                    Console.Clear();
                    PasswordManagement.ViewPassword();
                    break;

                case '2':
                    Console.Clear();
                    PasswordManagement.AddPassword();
                    break;

                case '3':
                    Console.Clear();
                    PasswordManagement.RemovePassword();
                    break;

                case '4':
                    Environment.Exit(0);
                    break;
            }
                Console.ReadLine();
        }
    }
}

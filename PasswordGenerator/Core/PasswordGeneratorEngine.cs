using PasswordGenerator.Enums;
using PasswordGenerator.Interfaces;
using PasswordGenerator.Utils;

namespace PasswordGenerator.Core;

/// <summary>
/// Orchestrateur principal de la génération de mots de passe.
/// </summary>
internal static class PasswordGeneratorEngine // MoteurGenerateurDeMotsDePasse
{
    private static readonly IUserInteractionService _ui = new ConsoleUserInteractionService(); // InterfaceUI
    private static PasswordCriteria? _lastCriteria; // DerniersCriteres

    /// <summary>
    /// Point d'entrée de l'orchestration. Gère la boucle principale du programme.
    /// </summary>
    internal static void Run() // Executer()
    {
        ReplayOption option = ReplayOption.NewCriteria; // InitialisationOption

        do
        {
            // Si c’est la première fois ou si l’utilisateur veut de nouveaux critères
            if (_lastCriteria == null || AskForNewCriteria(out option)) // DemanderNouveauxCriteres()
            {
                _lastCriteria = PasswordCriteriaBuilder.Build(_ui); // ConstruireCriteres()
            }

            // Si l’utilisateur a choisi de quitter, passer à l’itération suivante (sortie juste après)
            if (option == ReplayOption.Exit) continue;

            // Génération et affichage du mot de passe
            string password = PasswordGenerator.Generate(_lastCriteria); // GenererMotDePasse()
            Console.WriteLine($"\nMot de passe généré : {password}");
            Console.WriteLine(); // LigneVide()
        }
        while (option != ReplayOption.Exit); // RépéterTantQuePasSortie
    }

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite utiliser de nouveaux critères.
    /// </summary>
    private static bool AskForNewCriteria(out ReplayOption option) // DemanderNouveauxCriteres()
    {
        Console.WriteLine("\nSouhaitez-vous générer un nouveau mot de passe ?");
        Console.WriteLine("1. Oui, avec les mêmes critères");
        Console.WriteLine("2. Oui, avec de nouveaux critères");
        Console.WriteLine("Autre. Quitter");

        option = _ui.GetReplayOption(); // ObtenirOptionRejouer()
        return option == ReplayOption.NewCriteria;
    }
}

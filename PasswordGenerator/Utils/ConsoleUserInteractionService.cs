using PasswordGenerator.Enums;
using PasswordGenerator.Interfaces;

namespace PasswordGenerator.Utils;

/// <summary>
/// Fournit des méthodes utilitaires pour interagir avec la console utilisateur.
/// </summary>
internal sealed class ConsoleUserInteractionService : IUserInteractionService // OutilsConsole
{
    /// <summary>
    /// Demande à l'utilisateur un entier compris dans une plage spécifiée.
    /// </summary>
    public int AskInt(string message, int min, int max) // DemanderEntier()
    {
        int value;
        bool valid;
        do
        {
            Console.Write($"{message} ({min}-{max}) : "); // AfficherQuestion
            string input = Console.ReadLine() ?? string.Empty; // LireReponse()
            valid = int.TryParse(input, out value) && value >= min && value <= max;
            if (!valid)
                Console.WriteLine("Entrée invalide. Veuillez recommencer."); // MessageErreur
        }
        while (!valid);

        return value;
    }

    /// <summary>
    /// Demande à l'utilisateur une réponse oui/non (o/n ou y/n).
    /// </summary>
    public bool AskYesNo(string message) // DemanderOuiNon()
    {
        string input; // ReponseUtilisateur

        do
        {
            Console.Write($"{message} (o/n) : "); // AfficherQuestion
            input = (Console.ReadLine() ?? string.Empty).Trim().ToLower(); // LireReponse()

            if (input == "o" || input == "y") return true;  // Oui
            if (input == "n") return false;                 // Non

            Console.WriteLine("Réponse non valide. Tapez 'o' pour oui ou 'n' pour non."); // MessageErreur
        }
        while (true);
    }

    /// <summary>
    /// Retourne le choix de l'utilisateur pour rejouer avec les mêmes critères ou non.
    /// </summary>
    public ReplayOption GetReplayOption() // ObtenirOptionRejouer()
    {
        string input = (Console.ReadLine() ?? string.Empty).Trim().ToLower(); // LireReponse()

        return input switch
        {
            "1" => ReplayOption.SameCriteria,   // MemesCriteres
            "2" => ReplayOption.NewCriteria,    // NouveauxCriteres
            _ => ReplayOption.Exit              // Quitter
        };
    }
}

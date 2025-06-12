using PasswordGenerator.Enums;
using PasswordGenerator.Interfaces;

namespace PasswordGenerator.Utils;

/// <summary>
/// Fournit des méthodes utilitaires pour interagir avec l'utilisateur via la console.
/// </summary>
internal sealed class ConsoleUserInteractionService : IUserInteractionService // OutilsConsole
{
    /// <summary>
    /// Demande à l'utilisateur de saisir un entier dans une plage spécifiée.
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

            //if (!valid)
            //    Console.WriteLine("Entrée invalide. Veuillez recommencer."); // MessageErreur

        } while (!valid);

        return value;
    }

    /// <summary>
    /// Demande à l'utilisateur de répondre par oui ou non (o/n ou y/n).
    /// </summary>
    public bool AskYesNo(string message) // DemanderOuiNon()
    {
        do
        {
            Console.Write($"{message} (o/n) : "); // AfficherQuestion
            string input = (Console.ReadLine() ?? string.Empty).Trim().ToLower(); // LireReponse()

            if (input == "o" || input == "y") return true;  // Oui
            if (input == "n") return false;                 // Non

            //Console.WriteLine("Réponse non valide. Tapez 'o' pour oui ou 'n' pour non."); // MessageErreur
        }
        while (true);
    }

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite générer un autre mot de passe.
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

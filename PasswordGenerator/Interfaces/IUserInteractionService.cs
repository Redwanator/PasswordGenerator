using PasswordGenerator.Enums;

namespace PasswordGenerator.Interfaces;

/// <summary>
/// Définit les interactions de base avec l'utilisateur.
/// </summary>
internal interface IUserInteractionService
{
    /// <summary>
    /// Demande à l'utilisateur un entier dans une plage spécifiée.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <param name="min">La valeur minimale autorisée.</param>
    /// <param name="max">La valeur maximale autorisée.</param>
    /// <returns>Un entier compris entre min et max.</returns>
    int AskInt(string message, int min, int max);   // DemanderEntier()

    /// <summary>
    /// Demande à l'utilisateur une réponse oui/non.
    /// </summary>
    /// <param name="message">Le message à afficher.</param>
    /// <returns>True si l'utilisateur répond oui, sinon false.</returns>
    bool AskYesNo(string message);                  // DemanderOuiNon()

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite rejouer et retourne son choix.
    /// </summary>
    /// <returns>Une option représentant l'intention de l'utilisateur.</returns>
    ReplayOption GetReplayOption();                 // ObtenirOptionRejouer()
}

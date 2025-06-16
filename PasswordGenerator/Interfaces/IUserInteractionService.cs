using PasswordGenerator.Enums;

namespace PasswordGenerator.Interfaces;

/// <summary>
/// Définit les interactions de base avec l'utilisateur.
/// </summary>
internal interface IUserInteractionService
{
    /// <summary>
    /// Demande à l'utilisateur de saisir un entier dans une plage spécifiée.
    /// </summary>
    /// <param name="message">Message affiché à l'utilisateur.</param>
    /// <param name="min">Valeur minimale autorisée.</param>
    /// <param name="max">Valeur maximale autorisée.</param>
    /// <returns>Un entier compris entre min et max.</returns>
    int AskLenght(string message, int min, int max);   // DemanderLongueur()

    /// <summary>
    /// Demande à l'utilisateur de répondre par oui ou non.
    /// </summary>
    /// <param name="message">Message affiché à l'utilisateur.</param>
    /// <returns>True si l'utilisateur répond oui, sinon false.</returns>
    bool AskYesNo(string message);                  // DemanderOuiNon()

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite générer un autre mot de passe.
    /// </summary>
    /// <returns>Une option représentant le choix de l'utilisateur.</returns>
    ReplayOption GetReplayOption();                 // ObtenirOptionRejouer()

    /// <summary>
    /// Affiche un message à l'utilisateur.
    /// </summary>
    /// <param name="message">Message à afficher.</param>
    void WriteMessage(string message);              // AfficherMessage()
}

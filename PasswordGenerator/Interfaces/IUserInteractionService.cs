using PasswordGenerator.Enums;

namespace PasswordGenerator.Interfaces;

/// <summary>
/// Définit les interactions de base avec l'utilisateur.
/// </summary>
internal interface IUserInteractionService
{
    int AskInt(string message, int min, int max);           // DemanderEntier()
    bool AskYesNo(string message);                          // DemanderOuiNon()
    ReplayOption GetReplayOption();                         // ObtenirOptionRejouer()
}

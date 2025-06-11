namespace PasswordGenerator.Enums;

/// <summary>
/// Représente le choix de l'utilisateur après la génération d'un mot de passe.
/// </summary>
internal enum ReplayOption // OptionRejouer
{
    /// <summary>
    /// Générer un mot de passe avec les mêmes critères.
    /// </summary>
    SameCriteria, // MemesCriteres

    /// <summary>
    /// Générer un mot de passe avec de nouveaux critères.
    /// </summary>
    NewCriteria, // NouveauxCriteres

    /// <summary>
    /// Quitter l'application.
    /// </summary>
    Exit // Quitter
}

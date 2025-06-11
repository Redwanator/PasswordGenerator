namespace PasswordGenerator.Core;

/// <summary>
/// Représente les critères de génération d’un mot de passe.
/// </summary>
internal sealed class PasswordCriteria( // CriteresDeMotDePasse
    int length,             // longueur
    bool includeLowercase,  // inclureMinuscules
    bool includeUppercase,  // inclureMajuscules
    bool includeDigits,     // inclureChiffres
    bool includeSymbols     // inclureSymboles
)
{
    /// <summary>
    /// Longueur souhaitée du mot de passe.
    /// </summary>
    internal int Length { get; } = length; // Longueur

    /// <summary>
    /// Indique si des lettres minuscules doivent être incluses.
    /// </summary>
    internal bool IncludeLowercase { get; } = includeLowercase; // InclureMinuscules

    /// <summary>
    /// Indique si des lettres majuscules doivent être incluses.
    /// </summary>
    internal bool IncludeUppercase { get; } = includeUppercase; // InclureMajuscules

    /// <summary>
    /// Indique si des chiffres doivent être inclus.
    /// </summary>
    internal bool IncludeDigits { get; } = includeDigits; // InclureChiffres

    /// <summary>
    /// Indique si des symboles doivent être inclus.
    /// </summary>
    internal bool IncludeSymbols { get; } = includeSymbols; // InclureSymboles

    /// <summary>
    /// Vérifie si au moins un type de caractère a été sélectionné.
    /// </summary>
    internal bool HasAtLeastOneOption() // AuMoinsUneOption()
    {
        return IncludeLowercase || IncludeUppercase || IncludeDigits || IncludeSymbols;
    }
}

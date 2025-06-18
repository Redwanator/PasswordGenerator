namespace PasswordGenerator.Core;

/// <summary>
/// Représente les critères de génération d’un mot de passe.
/// </summary>
internal sealed class PasswordCriteria // CriteresDeMotDePasse
{
    /// <summary>
    /// Longueur souhaitée du mot de passe.
    /// </summary>
    internal required int Length { get; init; } // Longueur

    /// <summary>
    /// Indique si des lettres minuscules doivent être incluses.
    /// </summary>
    internal bool IncludeLowercase { get; init; } // InclureMinuscules

    /// <summary>
    /// Indique si des lettres majuscules doivent être incluses.
    /// </summary>
    internal bool IncludeUppercase { get; init; } // InclureMajuscules

    /// <summary>
    /// Indique si des chiffres doivent être inclus.
    /// </summary>
    internal bool IncludeDigits { get; init; } // InclureChiffres

    /// <summary>
    /// Indique si des symboles doivent être inclus.
    /// </summary>
    internal bool IncludeSymbols { get; init; } // InclureSymboles

    /// <summary>
    /// Vérifie si au moins un type de caractère a été sélectionné.
    /// </summary>
    internal bool HasAtLeastOneOption() // AuMoinsUneOption()
    {
        return IncludeLowercase || IncludeUppercase || IncludeDigits || IncludeSymbols;
    }
}

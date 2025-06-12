using System.Text;

namespace PasswordGenerator.Core;

/// <summary>
/// Fournit la logique de génération de mot de passe à partir de critères spécifiés.
/// </summary>
internal sealed class PasswordGenerator // GenerateurDeMotDePasse
{
    private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";  // Minuscules
    private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  // Majuscules
    private const string Digits = "0123456789";                     // Chiffres
    private const string Symbols = "!@#$%^&*_-+=";                  // Symboles

    /// <summary>
    /// Génère un mot de passe respectant les critères fournis.
    /// </summary>
    internal string Generate(PasswordCriteria criteria) // Generer(Criteres)
    {
        StringBuilder characterPool = new();                                        // ReservoirDeCaracteres
        List<char> requiredChars = new();                                           // CaracteresObligatoires

        if (criteria.IncludeLowercase)
        {
            characterPool.Append(Lowercase);                                        // AjouterMinuscules()
            requiredChars.Add(Lowercase[Random.Shared.Next(Lowercase.Length)]);     // 1 minuscule
        }

        if (criteria.IncludeUppercase)
        {
            characterPool.Append(Uppercase);                                        // AjouterMajuscules()
            requiredChars.Add(Uppercase[Random.Shared.Next(Uppercase.Length)]);     // 1 majuscule
        }

        if (criteria.IncludeDigits)
        {
            characterPool.Append(Digits);                                           // AjouterChiffres()
            requiredChars.Add(Digits[Random.Shared.Next(Digits.Length)]);           // 1 chiffre
        }

        if (criteria.IncludeSymbols)
        {
            characterPool.Append(Symbols);                                          // AjouterSymboles()
            requiredChars.Add(Symbols[Random.Shared.Next(Symbols.Length)]);         // 1 symbole
        }

        string pool = characterPool.ToString();                                     // ReservoirFinal
        List<char> passwordChars = new(requiredChars);                              // ConstructionMotDePasse

        // Compléter jusqu'à atteindre la longueur souhaitée
        while (passwordChars.Count < criteria.Length)
        {
            passwordChars.Add(pool[Random.Shared.Next(pool.Length)]);               // AjouterCaractereAleatoire()
        }

        // Mélanger tous les caractères pour ne pas avoir une position fixe des types imposés
        return new string(passwordChars.OrderBy(_ => Random.Shared.Next()).ToArray()); // MelangerEtRetourner()
    }
}

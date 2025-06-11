using System.Text;

namespace PasswordGenerator.Core;

/// <summary>
/// Fournit la logique de génération de mot de passe à partir de critères spécifiés.
/// </summary>
internal static class PasswordGenerator // GenerateurDeMotDePasse
{
    private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";  // Minuscules
    private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  // Majuscules
    private const string Digits = "0123456789";                     // Chiffres
    private const string Symbols = "!@#$%^&*_-+=";                  // Symboles

    private static readonly Random _random = new(); // GenerateurAleatoire

    /// <summary>
    /// Génère un mot de passe respectant les critères fournis.
    /// </summary>
    internal static string Generate(PasswordCriteria criteria) // Generer(Criteres)
    {
        StringBuilder characterPool = new();                                        // PoolCaracteres
        List<char> requiredChars = new();                                           // CaractèresObligatoires

        if (criteria.IncludeLowercase)
        {
            characterPool.Append(Lowercase);                                        // AjouterMinuscules()
            requiredChars.Add(Lowercase[_random.Next(Lowercase.Length)]);           // 1 minuscule
        }

        if (criteria.IncludeUppercase)
        {
            characterPool.Append(Uppercase);                                        // AjouterMajuscules()
            requiredChars.Add(Uppercase[_random.Next(Uppercase.Length)]);           // 1 majuscule
        }

        if (criteria.IncludeDigits)
        {
            characterPool.Append(Digits);                                           // AjouterChiffres()
            requiredChars.Add(Digits[_random.Next(Digits.Length)]);                 // 1 chiffre
        }

        if (criteria.IncludeSymbols)
        {
            characterPool.Append(Symbols);                                          // AjouterSymboles()
            requiredChars.Add(Symbols[_random.Next(Symbols.Length)]);               // 1 symbole
        }

        string pool = characterPool.ToString();                                        // PoolFinal
        List<char> passwordChars = new List<char>(requiredChars);                          // ConstructionMotDePasse

        // Compléter jusqu'à atteindre la longueur souhaitée
        while (passwordChars.Count < criteria.Length)
        {
            passwordChars.Add(pool[_random.Next(pool.Length)]);                     // AjouterCaractereAleatoire
        }

        // Mélanger tous les caractères pour ne pas avoir une position fixe des types imposés
        return new string(passwordChars.OrderBy(_ => _random.Next()).ToArray());    // MelangerEtRetourner
    }

}

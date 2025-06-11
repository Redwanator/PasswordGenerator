using PasswordGenerator.Utils;

namespace PasswordGenerator.Core;

/// <summary>
/// Construit une instance de <see cref="PasswordCriteria"/> à partir des réponses de l'utilisateur.
/// </summary>
internal static class PasswordCriteriaBuilder // ConstructeurDeCriteres
{
    /// <summary>
    /// Demande les critères de génération à l'utilisateur et retourne une instance valide.
    /// </summary>
    internal static PasswordCriteria Build() // Construire()
    {
        Console.WriteLine("Configuration du mot de passe :");

        int length = ConsoleUtils.AskInt("Longueur du mot de passe souhaitée", 4, 40); // longueur = DemanderEntier()

        PasswordCriteria criteria;

        do
        {
            criteria = AskCriteria(length); // criteres = DemanderCriteres()

            if (!criteria.HasAtLeastOneOption()) // criteres.AuMoinsUneOption()
                Console.WriteLine("Vous devez choisir au moins un type de caractère. Veuillez recommencer.");

        } while (!criteria.HasAtLeastOneOption()); // criteres.AuMoinsUneOption()

        return criteria;
    }

    /// <summary>
    /// Pose les questions sur les types de caractères à inclure.
    /// </summary>
    private static PasswordCriteria AskCriteria(int length) // DemanderCriteres(longueur)
    {
        bool includeLowercase = ConsoleUtils.AskYesNo("Inclure des lettres minuscules ?");  // inclureMinuscules = DemanderOuiNon()
        bool includeUppercase = ConsoleUtils.AskYesNo("Inclure des lettres majuscules ?");  // inclureMajuscules = DemanderOuiNon()
        bool includeDigits = ConsoleUtils.AskYesNo("Inclure des chiffres ?");               // inclureChiffres = DemanderOuiNon()
        bool includeSymbols = ConsoleUtils.AskYesNo("Inclure des symboles ?");              // inclureSymboles = DemanderOuiNon()

        return new PasswordCriteria(length, includeLowercase, includeUppercase, includeDigits, includeSymbols);
    }
}

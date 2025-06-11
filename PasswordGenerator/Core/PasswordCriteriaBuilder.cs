using PasswordGenerator.Interfaces;

namespace PasswordGenerator.Core;

/// <summary>
/// Construit une instance de <see cref="PasswordCriteria"/> à partir des réponses de l'utilisateur.
/// </summary>
internal static class PasswordCriteriaBuilder // ConstructeurDeCriteres
{
    /// <summary>
    /// Demande les critères de génération à l'utilisateur et retourne une instance valide.
    /// </summary>
    internal static PasswordCriteria Build(IUserInteractionService ui) // Construire()
    {
        Console.WriteLine("Configuration du mot de passe :");

        int length = ui.AskInt("Longueur du mot de passe souhaitée", 4, 40); // longueur = DemanderEntier()

        PasswordCriteria criteria;

        do
        {
            criteria = AskCriteria(length, ui); // criteres = DemanderCriteres()

            if (!criteria.HasAtLeastOneOption()) // criteres.AuMoinsUneOption()
                Console.WriteLine("Vous devez choisir au moins un type de caractère. Veuillez recommencer.");

        } while (!criteria.HasAtLeastOneOption()); // criteres.AuMoinsUneOption()

        return criteria;
    }

    /// <summary>
    /// Pose les questions sur les types de caractères à inclure.
    /// </summary>
    private static PasswordCriteria AskCriteria(int length, IUserInteractionService ui) // DemanderCriteres(longueur)
    {
        bool includeLowercase = ui.AskYesNo("Inclure des lettres minuscules ?");    // inclureMinuscules = DemanderOuiNon()
        bool includeUppercase = ui.AskYesNo("Inclure des lettres majuscules ?");    // inclureMajuscules = DemanderOuiNon()
        bool includeDigits = ui.AskYesNo("Inclure des chiffres ?");                 // inclureChiffres = DemanderOuiNon()
        bool includeSymbols = ui.AskYesNo("Inclure des symboles ?");                // inclureSymboles = DemanderOuiNon()

        return new PasswordCriteria(length, includeLowercase, includeUppercase, includeDigits, includeSymbols);
    }
}

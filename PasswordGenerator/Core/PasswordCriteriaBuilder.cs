using PasswordGenerator.Interfaces;

namespace PasswordGenerator.Core;

/// <summary>
/// Construit une instance de <see cref="PasswordCriteria"/> à partir des réponses de l'utilisateur.
/// </summary>
internal sealed class PasswordCriteriaBuilder // ConstructeurDeCriteres
{
    private readonly IUserInteractionService _ui; // InterfaceUtilisateur

    /// <summary>
    /// Initialise une nouvelle instance de <see cref="PasswordCriteriaBuilder"/>.
    /// </summary>
    internal PasswordCriteriaBuilder(IUserInteractionService ui) // Constructeur()
    {
        _ui = ui;
    }

    /// <summary>
    /// Demande les critères de génération à l'utilisateur et retourne une instance valide.
    /// </summary>
    internal PasswordCriteria Build() // Construire()
    {
        Console.WriteLine("Configuration du mot de passe :");

        int length = _ui.AskInt("Longueur du mot de passe souhaitée", 4, 40); // longueur = DemanderEntier()
        PasswordCriteria criteria;

        do
        {
            criteria = AskCriteria(length); // criteres = DemanderCriteres()

            if (!criteria.HasAtLeastOneOption()) // criteres.AuMoinsUneOption()
                Console.WriteLine("Vous devez choisir au moins un type de caractère. Veuillez recommencer.");
        }
        while (!criteria.HasAtLeastOneOption()); // criteres.AuMoinsUneOption()

        return criteria;
    }

    /// <summary>
    /// Pose les questions sur les types de caractères à inclure.
    /// </summary>
    private PasswordCriteria AskCriteria(int length) // DemanderCriteres(longueur)
    {
        bool includeLowercase = _ui.AskYesNo("Inclure des lettres minuscules ?");   // inclureMinuscules = DemanderOuiNon()
        bool includeUppercase = _ui.AskYesNo("Inclure des lettres majuscules ?");   // inclureMajuscules = DemanderOuiNon()
        bool includeDigits = _ui.AskYesNo("Inclure des chiffres ?");                // inclureChiffres = DemanderOuiNon()
        bool includeSymbols = _ui.AskYesNo("Inclure des symboles ?");               // inclureSymboles = DemanderOuiNon()

        return new PasswordCriteria(length, includeLowercase, includeUppercase, includeDigits, includeSymbols);
    }
}

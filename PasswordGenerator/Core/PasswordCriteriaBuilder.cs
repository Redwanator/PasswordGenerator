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
        _ui.WriteMessage("Configuration du mot de passe :");

        int length = _ui.AskIntInRange("Longueur du mot de passe souhaitée", 4, 40); // longueur = DemanderEntierDansPlage()

        PasswordCriteria criteria = AskCriteria(length); // criteres = DemanderCriteres()

        while (!criteria.HasAtLeastOneOption()) // criteres.AuMoinsUneOption()
        {
            _ui.WriteMessage("Vous devez choisir au moins un type de caractère. Veuillez recommencer.");
            criteria = AskCriteria(length); // criteres = DemanderCriteres()
        }

        return criteria;
    }

    /// <summary>
    /// Pose les questions sur les types de caractères à inclure.
    /// </summary>
    private PasswordCriteria AskCriteria(int length) // DemanderCriteres(longueur)
    {
        return new PasswordCriteria
        {
            Length = length,
            IncludeLowercase = _ui.AskYesNo("Inclure des lettres minuscules ?"),   // inclureMinuscules = DemanderOuiNon()
            IncludeUppercase = _ui.AskYesNo("Inclure des lettres majuscules ?"),   // inclureMajuscules = DemanderOuiNon()
            IncludeDigits = _ui.AskYesNo("Inclure des chiffres ?"),                // inclureChiffres = DemanderOuiNon()
            IncludeSymbols = _ui.AskYesNo("Inclure des symboles ?")                // inclureSymboles = DemanderOuiNon()
        };
    }
}

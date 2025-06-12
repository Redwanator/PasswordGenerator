using PasswordGenerator.Enums;
using PasswordGenerator.Interfaces;

namespace PasswordGenerator.Core;

/// <summary>
/// Représente une session de génération de mots de passe.
/// </summary>
internal sealed class PasswordGeneratorSession // SessionGenerateurDeMotDePasse
{
    private readonly IUserInteractionService _ui; // InterfaceUtilisateur
    private readonly PasswordGenerator _generator = new(); // Generateur
    private PasswordCriteria? _lastCriteria; // DerniersCriteres

    /// <summary>
    /// Initialise une nouvelle session avec le service d'interaction utilisateur spécifié.
    /// </summary>
    internal PasswordGeneratorSession(IUserInteractionService ui) // ConstructeurSession()
    {
        _ui = ui;
    }

    /// <summary>
    /// Démarre la session de génération de mots de passe.
    /// </summary>
    internal void Run() // Executer()
    {
        ReplayOption option = ReplayOption.NewCriteria; // Forcer la 1ère construction

        do
        {
            if (option == ReplayOption.NewCriteria) // NouveauxCriteres
                _lastCriteria = new PasswordCriteriaBuilder(_ui).Build(); // ConstruireCriteres()

            try
            {
                GenerateAndPrintPassword(); // GenererEtAfficher()
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}"); // MessageErreur
            }

            option = AskForNewCriteria(); // DemanderNouveauxCriteres()

        } while (option != ReplayOption.Exit); // RépéterTantQuePasSortie
    }

    /// <summary>
    /// Génère et affiche un mot de passe basé sur les critères actuels.
    /// </summary>
    private void GenerateAndPrintPassword() // GenererEtAfficher()
    {
        if (_lastCriteria is null)
            throw new InvalidOperationException("Les critères ne sont pas initialisés."); // CriteresAbsents

        string password = _generator.Generate(_lastCriteria); // GenererMotDePasse()

        Console.WriteLine();
        Console.WriteLine($"Mot de passe généré : {password}"); // AfficherMotDePasse
        Console.WriteLine();
    }

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite utiliser de nouveaux critères.
    /// </summary>
    private ReplayOption AskForNewCriteria() // DemanderNouveauxCriteres()
    {
        Console.WriteLine("Souhaitez-vous générer un nouveau mot de passe ?");
        Console.WriteLine("1. Oui, avec les mêmes critères");
        Console.WriteLine("2. Oui, avec de nouveaux critères");
        Console.WriteLine("Autre. Non, quitter l'application");

        return _ui.GetReplayOption(); // ObtenirOptionRejouer()
    }
}

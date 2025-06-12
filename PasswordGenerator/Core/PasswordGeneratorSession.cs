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
    private PasswordCriteria? _lastCriteria;      // DerniersCriteres

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
        try
        {
            _lastCriteria = new PasswordCriteriaBuilder(_ui).Build(); // ConstruireCriteres()
            GenerateAndPrintPassword(); // GenererEtAfficher()

            ReplayChoice choice;

            do
            {
                choice = AskForNewCriteria(); // DemanderNouveauxCriteres()

                if (choice.Option == ReplayOption.Exit) continue; // Quitter

                if (choice.IsNewCriteria) // EstNouveauCriteres
                {
                    _lastCriteria = new PasswordCriteriaBuilder(_ui).Build(); // ConstruireCriteres()
                }

                GenerateAndPrintPassword(); // GenererEtAfficher()

            } while (choice.Option != ReplayOption.Exit); // RépéterTantQuePasSortie
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}"); // MessageErreur
        }
    }

    /// <summary>
    /// Génère et affiche un mot de passe basé sur les critères actuels.
    /// </summary>
    private void GenerateAndPrintPassword() // GenererEtAfficher()
    {
        if (_lastCriteria is null)
            throw new InvalidOperationException("Les critères ne sont pas initialisés."); // CriteresAbsents

        string password = _generator.Generate(_lastCriteria); // GenererMotDePasse()
        Console.WriteLine($"\nMot de passe généré : {password}");
        Console.WriteLine(); // LigneVide()
    }

    /// <summary>
    /// Demande à l'utilisateur s'il souhaite utiliser de nouveaux critères.
    /// </summary>
    private ReplayChoice AskForNewCriteria() // DemanderNouveauxCriteres()
    {
        Console.WriteLine("\nSouhaitez-vous générer un nouveau mot de passe ?");
        Console.WriteLine("1. Oui, avec les mêmes critères");
        Console.WriteLine("2. Oui, avec de nouveaux critères");
        Console.WriteLine("Autre. Non, quitter l'application");

        ReplayOption option = _ui.GetReplayOption(); // ObtenirOptionRejouer()
        bool isNew = option == ReplayOption.NewCriteria; // EstNouveau

        return new ReplayChoice(isNew, option); // RetournerChoix
    }

    /// <summary>
    /// Représente le choix de l'utilisateur à la fin d'une génération.
    /// </summary>
    private readonly record struct ReplayChoice(bool IsNewCriteria, ReplayOption Option); // ChoixRejouer
}

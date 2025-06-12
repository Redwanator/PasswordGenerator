using PasswordGenerator.Core;
using PasswordGenerator.Interfaces;
using PasswordGenerator.Utils;

namespace PasswordGenerator;

/// <summary>
/// Point d’entrée de l’application console.
/// </summary>
internal static class Program
{
    private static readonly IUserInteractionService _ui = new ConsoleUserInteractionService(); // InterfaceUtilisateur
    private static readonly PasswordGeneratorSession _session = new(_ui); // Session

    private static void Main()
    {
        _session.Run(); // Executer()
    }
}

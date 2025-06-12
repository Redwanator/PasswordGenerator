using PasswordGenerator.Core;
using PasswordGenerator.Utils;

namespace PasswordGenerator;

/// <summary>
/// Point d’entrée de l’application console.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        ConsoleUserInteractionService ui = new(); // InterfaceUtilisateur
        PasswordGeneratorSession session = new(ui); // Session

        session.Run(); // Executer()
    }
}

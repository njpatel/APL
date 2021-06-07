using System.Collections.Generic;

namespace APL.Language
{
    using Symbols;

    public static class AriaBridgeCommands
    {
        // TODO: update this with actual Aria Bridge commands
        public static IReadOnlyList<CommandSymbol> All { get; } =
            new CommandSymbol[]
            {
                EngineCommands.ShowVersion
            };
    }
}
using System.Collections.Generic;

namespace APL.Language
{
    using Symbols;

    public static class ClusterManagerCommands
    {
        // TODO: update this with actual CM commands
        public static IReadOnlyList<CommandSymbol> All { get; } =
            new CommandSymbol[]
            {
                EngineCommands.ShowVersion
            };
    }
}
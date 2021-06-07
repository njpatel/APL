using System;
using System.Collections.Generic;
using System.Linq;

namespace APL.Language.Symbols
{
    using Utils;

    public class EmptyScope : Scope
    {
        public static readonly EmptyScope Instance = new EmptyScope();

        public override void GetSymbols(string name, SymbolMatch match, List<Symbol> symbols)
        {
            // do nothing
        }
    }
}
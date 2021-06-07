using System;
using System.Linq;
using System.Collections.Generic;
using APL.Language.Symbols;
using APL.Language.Syntax;
using APL.Language.Editor;

namespace APL.Language.Parsing
{
    using static Parsers<LexicalToken>;
    using static SyntaxParsers;

    /// <summary>
    /// Parsers for the APL directive grammar.
    /// </summary>
    public static class DirectiveGrammar
    {
        public static readonly Parser<LexicalToken, DirectiveBlock> DirectiveBlock =
            Rule(
                RequiredToken(SyntaxKind.DirectiveToken),
                List(AnyTokenButEnd), // consumes all remaining tokens
                Optional(Token(SyntaxKind.EndOfTextToken)),
                (directive, list, end) =>
                    new DirectiveBlock(directive, list, end));
    }
}
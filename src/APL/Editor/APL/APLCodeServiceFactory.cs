using System;

namespace APL.Language.Editor
{
    /// <summary>
    /// A factory for creating <see cref="APLCodeService"/>
    /// </summary>
    public class APLCodeServiceFactory : CodeServiceFactory
    {
        /// <summary>
        /// The <see cref="GlobalState"/> to instantiate new <see cref="APLCodeService"/> with.
        /// </summary>
        public GlobalState Globals { get; }

        /// <summary>
        /// Creates a new instance of <see cref="APLCodeServiceFactory"/>.
        /// </summary>
        public APLCodeServiceFactory(GlobalState globals)
        {
            if (globals == null)
                throw new ArgumentNullException(nameof(globals));

            // always use a cache
            this.Globals = globals.WithCache();
        }

        /// <summary>
        /// Creates a new <see cref="APLCodeServiceFactory"/> with <see cref="P:Globals"/> changed.
        /// </summary>
        public APLCodeServiceFactory WithGlobals(GlobalState globals)
        {
            if (this.Globals != globals)
            {
                return new APLCodeServiceFactory(globals);
            }
            else
            {
                return this;
            }
        }

        public override bool TryGetCodeService(string text, out CodeService service)
        {
            if (IsAPL(text))
            {
                service = new APLCodeService(text, this.Globals);
                return true;
            }
            else
            {
                service = null;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the text is believed to be APL syntax.
        /// </summary>
        private static bool IsAPL(string text)
        {
            return !IsSql(text); // SQL is not APL
        }

        /// <summary>
        /// Returns true if the text is believed to be SQL syntax.
        /// </summary>
        private static bool IsSql(string text)
        {
            var firstToken = GetFirstAPLToken(text);
            return string.Compare(firstToken, "select", ignoreCase: true) == 0;
        }

        /// <summary>
        /// Gets the text of the first token as understood using APL syntax.
        /// </summary>
        private static string GetFirstAPLToken(string text)
        {
            var firstToken = Parsing.TokenParser.ParseToken(text, 0);
            return firstToken?.Text ?? string.Empty;
        }
    }
}
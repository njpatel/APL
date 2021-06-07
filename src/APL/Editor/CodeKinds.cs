using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APL.Language.Editor
{
    /// <summary>
    /// Known code kinds.
    /// </summary>
    public static class CodeKinds
    {
        /// <summary>
        /// The code is a APL Query.
        /// </summary>
        public const string Query = nameof(Query);

        /// <summary>
        /// The code is a APL Commmand.
        /// </summary>
        public const string Command = nameof(Command);

        /// <summary>
        /// The code is a APL Directive
        /// </summary>
        public const string Directive = nameof(Directive);

        /// <summary>
        /// The code kind is not known.
        /// </summary>
        public const string Unknown = nameof(Unknown);
    }
}
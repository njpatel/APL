﻿using System;
using System.Collections.Generic;

namespace APL.Language.Editor
{
    using Utils;

    /// <summary>
    /// The base class for any <see cref="APLCode"/> analyzer.
    /// </summary>
    public abstract class APLAnalyzer
    {
        /// <summary>
        /// The name of the analyzer
        /// </summary>
        public virtual string Name { get { return this.GetType().Name; } }

        protected abstract IEnumerable<Diagnostic> GetDiagnostics();

        private IReadOnlyList<Diagnostic> _diagnostics;

        /// <summary>
        /// The diagnostics produced by this analyzer.
        /// </summary>
        public IReadOnlyList<Diagnostic> Diagnostics
        {
            get
            { 
                if (_diagnostics == null)
                {
                    _diagnostics = GetDiagnostics().ToReadOnly();
                }

                return _diagnostics;
            }
        }

        /// <summary>
        /// Analyzes the <see cref="APLCode"/> and outputs any diagnostics found into the diagnostics list.
        /// </summary>
        public abstract void Analyze(APLCode code, List<Diagnostic> diagnostics, CancellationToken cancellationToken);

        public static APLAnalyzer Create(string name, Diagnostic diagnostic, Action<APLCode, Diagnostic, List<Diagnostic>, CancellationToken> analyzer)
        {
            return new SimpleAnalyzer(name, diagnostic, analyzer);
        }

        public static APLAnalyzer Create(string name, Diagnostic diagnostic, Action<APLCode, Diagnostic, List<Diagnostic>> analyzer)
        {
            return new SimpleAnalyzer(name, diagnostic, (c, d, l, t) => analyzer(c, d, l));
        }

        private class SimpleAnalyzer : APLAnalyzer
        {
            private readonly string _name;
            private readonly Diagnostic _diagnostic;
            private readonly Action<APLCode, Diagnostic, List<Diagnostic>, CancellationToken> _analyzer;

            public SimpleAnalyzer(string name, Diagnostic diagnostic, Action<APLCode, Diagnostic, List<Diagnostic>, CancellationToken> analyzer)
            {
                _name = name;
                _diagnostic = diagnostic;
                _analyzer = analyzer;
            }

            public override string Name
            {
                get { return _name; }
            }

            protected override IEnumerable<Diagnostic> GetDiagnostics()
            {
                return new[] { _diagnostic };
            }

            public override void Analyze(APLCode code, List<Diagnostic> diagnostics, CancellationToken cancellationToken)
            {
                _analyzer(code, _diagnostic, diagnostics, cancellationToken);
            }
        }
    }
}
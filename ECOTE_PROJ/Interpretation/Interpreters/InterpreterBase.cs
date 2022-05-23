using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Tokenization.Tokens;

namespace ECOTE_PROJ.Interpretation.Interpreters {
    internal abstract class InterpreterBase {
        protected readonly Context context;
        protected readonly DependencyBuilder dependencyBuilder;

        public InterpreterBase(Context context, DependencyBuilder dependencyBuilder) {
            this.context = context;
            this.dependencyBuilder = dependencyBuilder;
        }

        public void Parse(TokenReader reader) {
            ParseInner(reader);
        }

        protected abstract void ParseInner(TokenReader reader);

        protected void ParseParameters<T1, T2>(TokenReader reader, out T1 parsedToken1, out T2 parsedToken2) where T1 : IToken where T2 : IToken {
            parsedToken1 = ParseNextParameter<T1>(reader);
            parsedToken2 = ParseNextParameter<T2>(reader);
        }

        protected void ParseParameters<T1, T2, T3>(TokenReader reader, out T1 parsedToken1, out T2 parsedToken2, out T3 parsedToken3) where T1 : IToken where T2 : IToken where T3 : IToken {
            parsedToken1 = ParseNextParameter<T1>(reader);
            parsedToken2 = ParseNextParameter<T2>(reader);
            parsedToken3 = ParseNextParameter<T3>(reader);
        }

        private T ParseNextParameter<T>(TokenReader reader) where T : IToken {
            if (reader.Current is T parsed && reader.Read()) {
                return parsed;
            } else {
                throw new NothingFoundException();
            }
        }
    }
}

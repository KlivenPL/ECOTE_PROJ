using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Tokenization.Tokens;
using System.Linq;

namespace ECOTE_PROJ.Interpretation.Interpreters {
    internal class DependencyInterpreter : InterpreterBase {
        public DependencyInterpreter(Context context, DependencyBuilder dependencyBuilder) : base(context, dependencyBuilder) {
        }
        protected override void ParseInner(TokenReader reader) {
            if (context.CurrentScope != null) {
                if (TryParseDependency(reader)) {
                    return;
                }
            }

            throw new NothingFoundException();
        }

        private bool TryParseDependency(TokenReader reader) {
            try {
                ParseParameters<IdentifierToken, OperatorToken, IdentifierToken>(reader, out var var1, out var op, out var var2);
                // if variable was declared
                if (context.CurrentScope.AllVariables.Any(x => x.Name == var1.Value)) {
                    var (originClass, variableDef) = context.Classes
                        .Except(new[] { context.CurrentClass })
                        .Select(x => (x, x.PublicDataMembers.ScopeVariables.FirstOrDefault(y => y.Name == var2.Value)))
                        .FirstOrDefault(x => x.Item2 != null);

                    if (originClass != null) {
                        dependencyBuilder.AddDependency(originClass, variableDef, context.CurrentClass);
                        return true;
                    }
                }

                return false;

            } catch (NothingFoundException) {
                return false;
            }
        }
    }
}

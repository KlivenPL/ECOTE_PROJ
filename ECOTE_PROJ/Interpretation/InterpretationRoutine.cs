using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Interpretation.Interpreters;

namespace ECOTE_PROJ.Interpretation {
    public class InterpretationRoutine {

        private readonly ClassDefinitionInterpreter classDefinitionInterpreter;
        private readonly ScopeInterpreter scopeInterpreter;
        private readonly DependencyInterpreter dependencyInterpreter;
        private readonly DependencyBuilder dependencyBuilder;
        private readonly Context context;

        public InterpretationRoutine() {
            context = new Context();
            dependencyBuilder = new DependencyBuilder();
            classDefinitionInterpreter = new ClassDefinitionInterpreter(context, dependencyBuilder);
            scopeInterpreter = new ScopeInterpreter(context, dependencyBuilder);
            dependencyInterpreter = new DependencyInterpreter(context, dependencyBuilder);
        }

        public string FindPublicDataMemberDependencies(TokenReader reader) {
            // First we find all classes definitions and public data members, then we find the dependencies.

            FindAllClassesAndPublicDataMembers(reader.Clone());
            FindPublicMemberDependencies(reader);

            return dependencyBuilder.ToString();
        }

        private void FindAllClassesAndPublicDataMembers(TokenReader tokenReader) {
            while (tokenReader.HasNext) {
                var origPos = tokenReader.Position;
                try {
                    classDefinitionInterpreter.Parse(tokenReader);
                } catch (NothingFoundException) {
                    tokenReader.MoveTo(origPos);
                    tokenReader.Read();
                }
            }
        }

        private void FindPublicMemberDependencies(TokenReader reader) {
            while (reader.HasNext) {
                bool hasException = false;

                var origPos = reader.Position;
                try {
                    scopeInterpreter.Parse(reader);
                } catch (NothingFoundException) {
                    reader.MoveTo(origPos);
                    hasException = true;
                }


                try {
                    dependencyInterpreter.Parse(reader);
                } catch (NothingFoundException) {
                    hasException = true;
                }

                if (hasException) {
                    reader.MoveTo(origPos);
                    reader.Read();
                }
            }
        }
    }
}

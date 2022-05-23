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
            // First we find all classes definitions and public data members

            var origReader = reader.Clone();
            reader.Read();

            while (reader.HasNext) {
                var origPos = reader.Position;
                try {
                    classDefinitionInterpreter.Parse(reader);
                } catch (NothingFoundException) {
                    reader.MoveTo(origPos);
                    reader.Read();
                }
            }

            reader = origReader;

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
                    // hasException = false;
                } catch (NothingFoundException) {
                    hasException = true;
                }

                if (hasException) {
                    reader.MoveTo(origPos);
                    reader.Read();
                }
            }

            return dependencyBuilder.ToString();
        }
    }
}

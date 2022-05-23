using System.Collections.Generic;
using System.Linq;

namespace ECOTE_PROJ.Language.Structures {
    internal class Scope {
        private readonly Scope parentScope;
        private readonly List<Variable> variables;

        public Scope(Scope parentScope) {
            this.parentScope = parentScope;
            variables = new List<Variable>();
        }

        public IEnumerable<Variable> AllVariables => variables.Concat(parentScope?.AllVariables ?? Enumerable.Empty<Variable>());

        public IEnumerable<Variable> ScopeVariables => variables;

        public void AddVariable(string type, string name) {
            variables.Add(new Variable { Type = type, Name = name });
        }

        public Scope CreateNested() {
            return new Scope(this);
        }

        public Scope DisposeAndReturnParent() {
            variables.Clear();
            return parentScope;
        }
    }
}

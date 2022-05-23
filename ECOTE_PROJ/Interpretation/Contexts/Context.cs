using ECOTE_PROJ.Language.Structures;
using System.Collections.Generic;
using System.Linq;

namespace ECOTE_PROJ.Interpretation.Contexts {
    class Context {
        private readonly List<ClassContext> classes;

        public IEnumerable<ClassContext> Classes => classes;
        public ClassContext CurrentClass { get; private set; }
        public Scope CurrentScope { get; private set; }

        public Context() {
            classes = new List<ClassContext>();
            CurrentClass = null;
            CurrentScope = null;
        }

        public void OpenNewScope() {
            CurrentScope = CurrentScope?.CreateNested() ?? new Scope(null);
        }

        public void CloseCurrentScope() {
            CurrentScope = CurrentScope?.DisposeAndReturnParent() ?? null;
            if (CurrentScope == null) {
                CurrentClass = null;
            }
        }

        public void AddClassAndSetAsCurrent(string className) {
            var newClass = new ClassContext(className);
            classes.Add(newClass);
            CurrentClass = newClass;
            CurrentScope = null;
        }

        public void SetClassAsCurrent(string className) {
            CurrentClass = classes.First(x => x.ClassName == className);
            CurrentScope = null;
        }
    }
}

using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Language.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOTE_PROJ.Interpretation.Dependencies {
    internal class DependencyBuilder {
        private readonly List<Dependency> dependencies;

        public DependencyBuilder() {
            dependencies = new List<Dependency>();
        }

        public DependencyBuilder AddDependency(ClassContext dataMemberClass, Variable dataMember, ClassContext referencedFromClass) {
            dependencies.Add(new Dependency {
                DataMemberClass = dataMemberClass,
                DataMember = dataMember,
                ReferencedFromClass = referencedFromClass,
            });

            return this;
        }

        public override string ToString() {
            return string.Join(Environment.NewLine, dependencies.Select(x => x.ToString()).Distinct().ToArray());
        }
    }
}

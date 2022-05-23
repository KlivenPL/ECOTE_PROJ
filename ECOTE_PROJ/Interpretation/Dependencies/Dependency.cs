using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Language.Structures;

namespace ECOTE_PROJ.Interpretation.Dependencies {
    internal class Dependency {
        public ClassContext DataMemberClass { get; init; }
        public Variable DataMember { get; init; }
        public ClassContext ReferencedFromClass { get; init; }

        public override string ToString() {
            return $"{DataMemberClass.ClassName},{DataMember.Name},{ReferencedFromClass.ClassName}";
        }
    }
}

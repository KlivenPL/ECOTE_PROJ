using ECOTE_PROJ.Language.Structures;
using ECOTE_PROJ.Tokenization.Tokens;

namespace ECOTE_PROJ.Interpretation.Contexts {
    internal class ClassContext {

        public ClassContext(string className) {
            ClassName = className;
            publicDataMembers = new Scope(null);
        }

        private readonly Scope publicDataMembers;
        public string ClassName { get; private set; }
        public Scope PublicDataMembers => publicDataMembers;

        public void AddPublicDataMember(IdentifierToken identifierType, IdentifierToken identifierName) {
            publicDataMembers.AddVariable(identifierType.Value, identifierName.Value);
        }
    }
}

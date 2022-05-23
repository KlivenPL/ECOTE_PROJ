using System.Linq;
using System.Text;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class IdentifierToken : TokenBase<string> {
        private static readonly string[] modifiers = new string[] { "signed", "unsigned", "long", "short" };

        public override string Value { get; protected set; }
        public override TokenClass Class => TokenClass.Identifier;

        public IdentifierToken() { }

        public override bool TryAccept(CodeReader reader) {
            if (char.IsLetter(reader.Current) || reader.Current == '_') {
                var sb = new StringBuilder(reader.Current.ToString());

                while (reader.Read() && (char.IsLetterOrDigit(reader.Current) || reader.Current == '_')) {
                    sb.Append(reader.Current);
                }

                Value = sb.ToString();

                // ignore c++ modifiers.
                if (modifiers.Any(x => x.Equals(Value, System.StringComparison.OrdinalIgnoreCase))) {
                    return false;
                }

                reader.SetPosition(reader.Position - 1);
                return true;
            }
            return false;
        }
    }
}

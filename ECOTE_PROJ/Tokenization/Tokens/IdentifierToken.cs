using System.Text;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class IdentifierToken : TokenBase<string> {
        public override string Value { get; protected set; }
        public override TokenClass Class => TokenClass.Identifier;

        public IdentifierToken() { }

        public IdentifierToken(string value, int position, int line) {
            Value = value;
            AddDebugData(position, line);
        }

        public override IToken DeepCopy() {
            return new IdentifierToken(Value, CodePosition, LineNumber);
        }

        public override bool TryAccept(CodeReader reader) {
            if (char.IsLetter(reader.Current) || reader.Current == '_') {
                var sb = new StringBuilder(reader.Current.ToString());

                while (reader.Read() && (char.IsLetterOrDigit(reader.Current) || reader.Current == '_')) {
                    sb.Append(reader.Current);
                }

                Value = sb.ToString();
                reader.SetPosition(reader.Position - 1);
                return true;
            }
            return false;
        }
    }
}

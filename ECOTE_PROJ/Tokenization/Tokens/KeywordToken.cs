using ECOTE_PROJ.Language;
using System;
using System.Text;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class KeywordToken : TokenBase<KeywordType> {
        public override KeywordType Value { get; protected set; }
        public override TokenClass Class => TokenClass.Keyword;

        public KeywordToken() {

        }

        public KeywordToken(KeywordType value, int position, int line) {
            Value = value;
            AddDebugData(position, line);
        }

        public override IToken DeepCopy() {
            return new KeywordToken(Value, CodePosition, LineNumber);
        }

        public override bool TryAccept(CodeReader reader) {
            if (char.IsLetter(reader.Current)) {
                var sb = new StringBuilder();
                sb.Append(reader.Current);

                while (reader.Read() && char.IsLetter(reader.Current)) {
                    sb.Append(reader.Current);
                }

                if (Enum.TryParse<KeywordType>(sb.ToString(), true, out var register)) {
                    Value = register;
                    return true;
                }
            }
            return false;
        }

        public override string ToString() {
            return $"(Keyword) {Value}";
        }
    }
}

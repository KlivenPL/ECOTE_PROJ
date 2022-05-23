using ECOTE_PROJ.Language;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class OperatorToken : TokenBase<OperatorType> {
        public override OperatorType Value { get; protected set; }
        public override TokenClass Class => TokenClass.Operator;

        public OperatorToken() {

        }

        public OperatorToken(OperatorType value, int position, int line) {
            Value = value;
            AddDebugData(position, line);
        }

        public override IToken DeepCopy() {
            return new OperatorToken(Value, CodePosition, LineNumber);
        }

        public override bool TryAccept(CodeReader reader) {
            if (reader.Current == '.') {
                Value = OperatorType.Dot;
                return true;
            } else if (reader.Current == '-') {
                if (reader.Read() && reader.Current == '>') {
                    Value = OperatorType.Arrow;
                    return true;
                }
            }

            return false;
        }
    }
}

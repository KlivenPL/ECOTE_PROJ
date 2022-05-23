using ECOTE_PROJ.Language;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class OperatorToken : TokenBase<OperatorType> {
        public override OperatorType Value { get; protected set; }
        public override TokenClass Class => TokenClass.Operator;

        public OperatorToken() {

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
            } else if (reader.Current == '=') {
                Value = OperatorType.EqualSign;
                return true;
            }

            return false;
        }
    }
}

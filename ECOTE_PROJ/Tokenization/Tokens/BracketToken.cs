using ECOTE_PROJ.Language;

namespace ECOTE_PROJ.Tokenization.Tokens {
    class BracketToken : TokenBase<BracketType> {
        public BracketToken() {

        }

        public BracketToken(BracketType value, int position, int line) {
            Value = value;
            AddDebugData(position, line);
        }

        public override BracketType Value { get; protected set; }
        public override TokenClass Class => TokenClass.Bracket;

        public override IToken DeepCopy() {
            return new BracketToken(Value, CodePosition, LineNumber);
        }

        public override bool TryAccept(CodeReader reader) {
            if (reader.Current == '{') {
                Value = BracketType.CurlyOpen;
                return true;
            } else if (reader.Current == '}') {
                Value = BracketType.CurlyClose;
                return true;
            }

            return false;
        }
    }
}

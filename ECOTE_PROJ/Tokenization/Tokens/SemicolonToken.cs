namespace ECOTE_PROJ.Tokenization.Tokens {
    class SemicolonToken : TokenBase<char> {
        public override char Value { get; protected set; }
        public override TokenClass Class => TokenClass.Semicolon;

        public SemicolonToken() {

        }

        public SemicolonToken(char value, int position, int line) {
            Value = value;
            AddDebugData(position, line);
        }

        public override IToken DeepCopy() {
            return new SemicolonToken(Value, CodePosition, LineNumber);
        }

        public override bool TryAccept(CodeReader reader) {
            if (reader.Current == ';') {
                Value = ';';
                return true;
            }

            return false;
        }
    }
}

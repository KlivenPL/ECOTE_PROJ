namespace ECOTE_PROJ.Tokenization.Tokens {
    class SemicolonToken : TokenBase<char> {
        public override char Value { get; protected set; }
        public override TokenClass Class => TokenClass.Semicolon;

        public SemicolonToken() {

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

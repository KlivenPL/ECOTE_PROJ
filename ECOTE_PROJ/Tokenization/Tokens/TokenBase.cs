namespace ECOTE_PROJ.Tokenization.Tokens {
    public interface IToken {
        TokenClass Class { get; }
        bool TryAccept(CodeReader reader);
    }

    abstract class TokenBase<TValue> : IToken {
        public abstract TValue Value { get; protected set; }
        public abstract TokenClass Class { get; }

        public abstract bool TryAccept(CodeReader reader);

        public override string ToString() {
            return Value.ToString();
        }
    }
}

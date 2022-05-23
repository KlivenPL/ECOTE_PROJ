using System;

namespace ECOTE_PROJ.Tokenization.Tokens {
    [Flags]
    public enum TokenClass : uint {
        None = 0,
        Identifier = 1,
        Keyword = 1 << 1,
        Bracket = 1 << 2,
        Operator = 1 << 3,
        Semicolon = 1 << 4,
    }
}

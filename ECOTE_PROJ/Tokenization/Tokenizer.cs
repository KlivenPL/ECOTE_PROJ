using ECOTE_PROJ.Tokenization.Tokens;
using System.Collections.Generic;

namespace ECOTE_PROJ.Tokenization {
    public class Tokenizer {
        public IEnumerable<IToken> Tokenize(CodeReader reader) {
            while (reader.Read()) {
                if (char.IsWhiteSpace(reader.Current) || reader.Current == ',') {
                    continue;
                }

                if (reader.Current == '#' || reader.Current == '/' && reader.TryPeek(out var c) && c == '/') {
                    reader.SkipToNextLine();
                    continue;
                }

                var token = CreateToken(reader);

                if (token != null) {
                    yield return token;
                }
            }
        }

        private IToken CreateToken(CodeReader reader) {
            var origPosition = reader.Position;

            IToken token;

            if (!char.IsLetter(reader.Current) && reader.Current != '_') {
                if ((token = new BracketToken()).TryAccept(reader)) {
                    return token;
                } else if ((token = new SemicolonToken()).TryAccept(reader)) {
                    return token;
                } else if ((token = new OperatorToken()).TryAccept(reader)) {
                    return token;
                } else {
                    reader.SetPosition(origPosition);
                }
            }

            if ((token = new KeywordToken()).TryAccept(reader)) {
                return token;
            }

            reader.SetPosition(origPosition);

            if ((token = new IdentifierToken()).TryAccept(reader)) {
                return token;
            }

            return null;
        }
    }
}

namespace ECOTE_PROJ.Tokenization {
    public sealed class CodeReader {
        private readonly string input;
        public char Current { get; private set; }
        public int Position { get; private set; }

        public CodeReader(string input) {
            this.input = input;
        }

        public bool Read() {
            if (Position < input.Length - 1) {
                Current = input[Position++];
                return true;
            }
            return false;
        }

        public bool TryPeek(out char c) {
            c = (char)0;
            if (Position < input.Length - 1) {
                c = input[Position + 1];
                return true;
            }
            return false;
        }

        public void SkipToNextLine() {
            while (Read()) {
                if (Current == '\n') {
                    return;
                }
            }
        }

        public void SetPosition(int position) {
            if (position == 0) {
                position++;
            }

            Position = position - 1;
            Read();
        }
    }
}

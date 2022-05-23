using System.Text;

namespace ECOTE_PROJ.Tokenization {
    public sealed class CodeReader {
        //private readonly StreamReader reader;
        private readonly string input;

        private readonly StringBuilder lastLineBuilder;
        public string LineText => lastLineBuilder.ToString();

        //public bool EndOfCode => Position == input.Length;
        public char Current { get; private set; }
        public char LowerCurrent => char.ToLower(Current);

        /*        public int Position { get; private set; }
                public int Line { get; private set; } = 1;*/

        public int Position { get; private set; }

        public CodeReader(string input) {
            //reader = new StreamReader(ms);
            this.input = input;
            lastLineBuilder = new StringBuilder();
        }

        /*private CodeReader(CodeReader oldReader) {
            MemoryStream newStream = null;
            oldReader.reader.BaseStream.CopyTo(newStream);
            newStream.Position = oldReader.reader.BaseStream.Position;
            reader = new StreamReader(newStream);
            lastLineBuilder = new StringBuilder(oldReader.LineText);
        }*/

        public bool Read() {
            if (Position < input.Length - 1) {
                Current = input[Position++];
                /*Position++;*/
                lastLineBuilder.Append(Current);

                if (Current == '\n') {
                    /*Line++;
                    Position = 0;*/
                    lastLineBuilder.Clear();
                }

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

        /* public CodeReader DeepCopy() {
             return new CodeReader(this) {
                 Current = Current,
                 *//*Position = Position,
                 Line = Line,*//*
             };
         }*/

        public void SetPosition(int position) {
            if (position == 0) {
                position++;
            }

            Position = position - 1;
            Read();
        }
    }
}

using ECOTE_PROJ.Interpretation;
using ECOTE_PROJ.Tokenization;
using System;
using Xunit;

namespace ECOTE_TESTS.Interpretation {
    public class InterpreterTests : TestBase {

        [Fact]
        public void Interpret_TestCase1() {
            var reader = CreateTokenReader(1);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,a,B");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase2() {
            var reader = CreateTokenReader(2);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,b,B");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase3() {
            var reader = CreateTokenReader(3);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,b,B");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase4() {
            var reader = CreateTokenReader(4);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,b,B", "A,b,C", "B,a,C");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase5() {
            var reader = CreateTokenReader(5);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps(string.Empty);

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase6() {
            var reader = CreateTokenReader(6);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,integer,B", "A,character,B", "A,boolean,B", "A,floatingPoint,B", "A,doubleFloatingPoint,B");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase7() {
            var reader = CreateTokenReader(7);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,test,B");

            Assert.Equal(expectedDeps, deps);
        }

        [Fact]
        public void Interpret_TestCase8() {
            var reader = CreateTokenReader(8);
            var routine = new InterpretationRoutine();

            var deps = routine.FindPublicDataMemberDependencies(reader);
            var expectedDeps = CreateExpectedDeps("A,test,B", "A,test2,B", "A,test3,B", "A,test4,B");

            Assert.Equal(expectedDeps, deps);
        }

        private TokenReader CreateTokenReader(int testCase) {
            var input = LoadTestCase(testCase);
            var codeReader = new CodeReader(input);
            return new TokenReader(new Tokenizer().Tokenize(codeReader));
        }

        private string CreateExpectedDeps(params string[] deps) {
            return string.Join(Environment.NewLine, deps);
        }
    }
}

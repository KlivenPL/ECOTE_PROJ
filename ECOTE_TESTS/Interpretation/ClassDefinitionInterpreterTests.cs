using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Interpretation.Interpreters;
using ECOTE_PROJ.Tokenization;
using System.Linq;
using Xunit;

namespace ECOTE_TESTS.Interpretation {
    public class ClassDefinitionInterpreterTests : TestBase {
        private readonly Context context;
        private readonly DependencyBuilder dependencyBuilder;
        private readonly ClassDefinitionInterpreter classDefinitionInterpreter;

        public ClassDefinitionInterpreterTests() {
            context = new Context();
            dependencyBuilder = new DependencyBuilder();
            classDefinitionInterpreter = new ClassDefinitionInterpreter(context, dependencyBuilder);
        }

        [Fact]
        public void TestCase1_AllClassesAndPublicMembersFound() {
            var input = LoadTestCase(1);
            var codeReader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(codeReader).ToList();
            var tokenReader = new TokenReader(tokens);

            FindAllClassesAndPublicDataMembers(tokenReader);

            Assert.Null(context.CurrentClass);
            Assert.Equal(2, context.Classes.Count());
            Assert.Contains(context.Classes, x => x.ClassName == "A" && x.PublicDataMembers.ScopeVariables.Count() == 2);
            Assert.Contains(context.Classes, x => x.ClassName == "B" && x.PublicDataMembers.ScopeVariables?.Count() == 0);
        }

        [Fact]
        public void TestCase4_AllClassesAndPublicMembersFound() {
            var input = LoadTestCase(4);
            var codeReader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(codeReader).ToList();
            var tokenReader = new TokenReader(tokens);

            FindAllClassesAndPublicDataMembers(tokenReader);

            Assert.Null(context.CurrentClass);
            Assert.Equal(3, context.Classes.Count());
            Assert.Contains(context.Classes, x => x.ClassName == "A" && x.PublicDataMembers.ScopeVariables.Count() == 1);
            Assert.Contains(context.Classes, x => x.ClassName == "B" && x.PublicDataMembers.ScopeVariables.Count() == 1);
            Assert.Contains(context.Classes, x => x.ClassName == "C" && x.PublicDataMembers.ScopeVariables.Count() == 0);
        }

        [Fact]
        public void TestCase8_AllClassesAndPublicMembersFound() {
            var input = LoadTestCase(8);
            var codeReader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(codeReader).ToList();
            var tokenReader = new TokenReader(tokens);

            FindAllClassesAndPublicDataMembers(tokenReader);

            Assert.Null(context.CurrentClass);
            Assert.Equal(2, context.Classes.Count());
            Assert.Contains(context.Classes, x => x.ClassName == "A" && x.PublicDataMembers.ScopeVariables.Count() == 4);
            Assert.Contains(context.Classes, x => x.ClassName == "B" && x.PublicDataMembers.ScopeVariables?.Count() == 0);
        }

        private void FindAllClassesAndPublicDataMembers(TokenReader tokenReader) {
            tokenReader.Read();

            while (tokenReader.HasNext) {
                var origPos = tokenReader.Position;
                try {
                    classDefinitionInterpreter.Parse(tokenReader);
                } catch (NothingFoundException) {
                    tokenReader.MoveTo(origPos);
                    tokenReader.Read();
                }
            }
        }
    }
}

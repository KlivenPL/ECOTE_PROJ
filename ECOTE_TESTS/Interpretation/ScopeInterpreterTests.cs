using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Interpretation.Interpreters;
using ECOTE_PROJ.Tokenization;
using System.Linq;
using Xunit;

namespace ECOTE_TESTS.Interpretation {
    public class ScopeInterpreterTests : TestBase {
        private readonly Context context;
        private readonly DependencyBuilder dependencyBuilder;
        private readonly ClassDefinitionInterpreter classDefinitionInterpreter;
        private readonly ScopeInterpreter scopeInterpreter;

        public ScopeInterpreterTests() {
            context = new Context();
            dependencyBuilder = new DependencyBuilder();
            classDefinitionInterpreter = new ClassDefinitionInterpreter(context, dependencyBuilder);
            scopeInterpreter = new ScopeInterpreter(context, dependencyBuilder);
        }

        [Fact]
        public void Input1_AllScopeAndClassVariablesFoundFound() {
            string input =
@"class A {
	public:
		int a;
		char b;
		
	private:
        int c;
		void test2(){
			char d;
";

            var codeReader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(codeReader).ToList();
            var tokenReader = new TokenReader(tokens);
            tokenReader.Read();

            FindAllClassesAndPublicDataMembers(tokenReader.Clone());
            context.CloseCurrentScope();
            context.CloseCurrentScope();
            FindScopes(tokenReader);

            Assert.Equal(4, context.CurrentScope.AllVariables.Count());
            Assert.Single(context.CurrentScope.ScopeVariables);

            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "a");
            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "b");
            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "c");

            Assert.Contains(context.CurrentScope.ScopeVariables, x => x.Name == "d");
        }

        [Fact]
        public void Input2_AllScopeAndClassVariablesFoundFound() {
            string input =
@"class A {
	public:
		int a = 1;
		char b = 'c';
		
	private:
        int c = 3;
		void test2(){
            {
                // this scope will be already closed, when this sample code is read to end.
                char ignored = 'i';
            }
			char d = 'e';
";

            var codeReader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(codeReader).ToList();
            var tokenReader = new TokenReader(tokens);
            tokenReader.Read();

            FindAllClassesAndPublicDataMembers(tokenReader.Clone());
            context.CloseCurrentScope();
            context.CloseCurrentScope();
            FindScopes(tokenReader);

            Assert.Equal(4, context.CurrentScope.AllVariables.Count());
            Assert.Single(context.CurrentScope.ScopeVariables);

            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "a");
            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "b");
            Assert.Contains(context.CurrentScope.AllVariables, x => x.Name == "c");

            Assert.Contains(context.CurrentScope.ScopeVariables, x => x.Name == "d");
        }

        private void FindAllClassesAndPublicDataMembers(TokenReader tokenReader) {
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

        private void FindScopes(TokenReader tokenReader) {
            while (tokenReader.HasNext) {
                var origPos = tokenReader.Position;
                try {
                    scopeInterpreter.Parse(tokenReader);
                } catch (NothingFoundException) {

                } finally {
                    tokenReader.MoveTo(origPos);
                    tokenReader.Read();
                }
            }
        }
    }
}

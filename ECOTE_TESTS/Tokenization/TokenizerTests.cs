using ECOTE_PROJ.Tokenization;
using ECOTE_PROJ.Tokenization.Tokens;
using System.Linq;
using Xunit;

namespace ECOTE_TESTS.Tokenization {
    public class TokenizerTests : TestBase {

        [Fact]
        public void Tokenize_TestCase1() {
            var input = LoadTestCase(1);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase2() {
            var input = LoadTestCase(2);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Keyword,

                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase3() {
            var input = LoadTestCase(3);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase4() {
            var input = LoadTestCase(4);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase5() {
            var input = LoadTestCase(5);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase6() {
            var input = LoadTestCase(6);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Semicolon,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase7() {
            var input = LoadTestCase(7);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Bracket,

                TokenClass.Semicolon,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }

        [Fact]
        public void Tokenize_TestCase8() {
            var input = LoadTestCase(8);
            var reader = new CodeReader(input);
            var tokens = new Tokenizer().Tokenize(reader).ToList();

            string xd = string.Join($",\r\n", tokens.Select(x => $"TokenClass.{x.Class}").ToList());

            var expectedTokenClasses = new TokenClass[] {
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Bracket,

                TokenClass.Semicolon,
                TokenClass.Keyword,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Operator,
                TokenClass.Identifier,
                TokenClass.Semicolon,
                TokenClass.Bracket,

                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Identifier,
                TokenClass.Bracket,

                TokenClass.Bracket,
                TokenClass.Bracket,
                TokenClass.Semicolon
            };

            Assert.Equal(tokens.Select(t => t.Class), expectedTokenClasses);
        }
    }
}

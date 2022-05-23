using ECOTE_PROJ._Infrastructure;
using ECOTE_PROJ.Interpretation.Contexts;
using ECOTE_PROJ.Interpretation.Dependencies;
using ECOTE_PROJ.Tokenization.Tokens;

namespace ECOTE_PROJ.Interpretation.Interpreters {
    internal class ScopeInterpreter : InterpreterBase {
        public ScopeInterpreter(Context context, DependencyBuilder dependencyBuilder) : base(context, dependencyBuilder) {
        }

        enum ClassArea {
            NotInClass,
            PrivateRegion,
            PublicRegion,
        }

        private ClassArea classArea = ClassArea.NotInClass;

        protected override void ParseInner(TokenReader reader) {
            if (classArea != ClassArea.NotInClass) {
                var peek = reader.Peek(0);
                if (peek is BracketToken bracket) {
                    if (bracket.Value == Language.BracketType.CurlyOpen) {
                        context.OpenNewScope();
                    } else if (bracket.Value == Language.BracketType.CurlyClose) {
                        context.CloseCurrentScope();
                    }
                }

                if (context.CurrentClass == null) {
                    classArea = ClassArea.NotInClass;
                }
            }

            if (classArea == ClassArea.NotInClass) {
                if (TryParseClass(reader)) {
                    classArea = ClassArea.PrivateRegion;
                    return;
                }

                throw new NothingFoundException();
            }

            if (classArea == ClassArea.PrivateRegion) {
                var peek = reader.Peek(0);
                if (peek is KeywordToken keywordToken && keywordToken.Value == Language.KeywordType.Public) {
                    classArea = ClassArea.PublicRegion;
                    return;
                } else if (TryParseVariableDeclaration(reader)) {
                    return;
                }

                throw new NothingFoundException();
            }

            if (classArea == ClassArea.PublicRegion) {
                var peek = reader.Peek(0);
                if (peek is KeywordToken keywordToken && keywordToken.Value == Language.KeywordType.Private) {
                    classArea = ClassArea.PrivateRegion;
                } else if (TryParseVariableDeclaration(reader)) {
                    return;
                }
            }

            throw new NothingFoundException();
        }

        private bool TryParseClass(TokenReader reader) {
            try {
                ParseParameters<KeywordToken, IdentifierToken, BracketToken>(reader, out var keyword, out var identifier, out var bracket);
                if (keyword.Value == Language.KeywordType.Class && bracket.Value == Language.BracketType.CurlyOpen) {
                    context.SetClassAsCurrent(identifier.Value);
                    return true;
                } else {
                    return false;
                }
            } catch (NothingFoundException) {
                return false;
            }
        }

        private bool TryParseVariableDeclaration(TokenReader reader) {
            try {
                ParseParameters<IdentifierToken, IdentifierToken>(reader, out var type, out var name);

                var peek = reader.Peek(0);
                if (peek is SemicolonToken || peek is OperatorToken operatorToken && operatorToken.Value == Language.OperatorType.EqualSign) {
                    reader.Read();
                    context.CurrentScope.AddVariable(type.Value, name.Value);
                }

                return true;
            } catch (NothingFoundException) {
                return false;
            }
        }
    }
}

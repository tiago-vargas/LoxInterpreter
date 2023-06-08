using System.Collections;

namespace Lox;

public class Scanner
{
	public static List<Token> ScanTokens(string source)
	{
		string[] lexemes = source.Split(separator: ' ', options: StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
		var tokens = new List<Token> { };

		foreach (string lexeme in lexemes)
		{
			TokenType tokenType = GetTokenType(lexeme);
			tokens.Add(new Token(tokenType));
		}
		return tokens;
	}

	private static TokenType GetTokenType(string lexeme)
	{
		switch (lexeme)
		{
			case "(":
				return TokenType.LeftParen;
			case ")":
				return TokenType.RightParen;
			case "{":
				return TokenType.LeftBrace;
			case "}":
				return TokenType.RightBrace;
			case ",":
				return TokenType.Comma;
			case ".":
				return TokenType.Dot;
			case "-":
				return TokenType.Minus;
			case "+":
				return TokenType.Plus;
			case ";":
				return TokenType.Semicolon;
			case "*":
				return TokenType.Star;
			default:
				throw new NotImplementedException(message: $"Unexpected lexeme: '{lexeme}'");
		}
	}
}

namespace Lox;

public class Scanner
{
	public static List<Token> ScanTokens(string source)
	{
		var tokens = new List<Token> { };

		foreach (char c in source)
		{
			if (!char.IsWhiteSpace(c))
			{
				TokenType tokenType = GetTokenType(c.ToString());
				tokens.Add(new Token(tokenType));
			}
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
				throw new UnexpectedLexemeException(lexeme);
		}
	}
}

class UnexpectedLexemeException: Exception
{
	internal UnexpectedLexemeException(string? lexeme)
		: base(message: $"Unexpected lexeme: '{lexeme}'")
	{ }
}

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
				TokenType tokenType = GetTokenType(c);
				tokens.Add(new Token(tokenType));
			}
		}
		return tokens;
	}

	private static TokenType GetTokenType(char firstCharacterOfLexeme)
	{
		switch (firstCharacterOfLexeme)
		{
			case '(':
				return TokenType.LeftParen;
			case ')':
				return TokenType.RightParen;
			case '{':
				return TokenType.LeftBrace;
			case '}':
				return TokenType.RightBrace;
			case ',':
				return TokenType.Comma;
			case '.':
				return TokenType.Dot;
			case '-':
				return TokenType.Minus;
			case '+':
				return TokenType.Plus;
			case ';':
				return TokenType.Semicolon;
			case '*':
				return TokenType.Star;
			case '=':
				return TokenType.Equal;
			case '!':
				return TokenType.Bang;
			case '>':
				return TokenType.Greater;
			case '<':
				return TokenType.Less;
			default:
				throw new UnexpectedLexemeException(firstCharacterOfLexeme);
		}
	}
}

class UnexpectedLexemeException: Exception
{
	internal UnexpectedLexemeException(char? firstCharacterOfLexeme)
		: base(message: $"Unexpected first character for a lexeme: '{firstCharacterOfLexeme}'")
	{ }
}

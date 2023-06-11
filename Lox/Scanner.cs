namespace Lox;

public class Scanner
{
	private static int currentIndex = 0;
	private static string source = "";
	private static char? NextCharacter
	{
		get
		{
			if (currentIndex + 1 >= source.Length)
				return null;
			else
				return source[currentIndex + 1];
		}
	}


	public static List<Token> ScanTokens(string source)
	{
		var tokens = new List<Token> { };
		Scanner.source = source;

		for (currentIndex = 0; currentIndex < source.Length; ++currentIndex)
		{
			char c = source[currentIndex];
			if (c == '/' && NextCharacter == '/')
			{
				SkipCharactersUntilTheEndOfTheLine();
			}
			else if (c == '"')
			{
				string value = GetStringValueBetweenQuotes();
				tokens.Add(new Token(TokenType.String, value));
			}
			else if (!char.IsWhiteSpace(c))
			{
				TokenType tokenType = GetTokenType(c);
				tokens.Add(new Token(tokenType));
			}
		}
		return tokens;
	}

	private static string GetStringValueBetweenQuotes()
	{
		int openQuoteIndex = currentIndex;
		int closingQuoteIndex = FindMatchingQuote();
		string value = source[(openQuoteIndex + 1)..closingQuoteIndex];
		return value;
	}

	private static void SkipCharactersUntilTheEndOfTheLine()
	{
		while (currentIndex < source.Length && source[currentIndex] != '\n')
			++currentIndex;
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
				if (NextCharacter == '=')
				{
					SkipNextCharacter();
					return TokenType.EqualEqual;
				}
				else
				{
					return TokenType.Equal;
				}
			case '!':
				if (NextCharacter == '=')
				{
					SkipNextCharacter();
					return TokenType.BangEqual;
				}
				else
				{
					return TokenType.Bang;
				}
			case '>':
				if (NextCharacter == '=')
				{
					SkipNextCharacter();
					return TokenType.GreaterEqual;
				}
				else
				{
					return TokenType.Greater;
				}
			case '<':
				if (NextCharacter == '=')
				{
					SkipNextCharacter();
					return TokenType.LessEqual;
				}
				else
				{
					return TokenType.Less;
				}
			case '/':
				return TokenType.Slash;
			default:
				throw new UnexpectedLexemeException(firstCharacterOfLexeme);
		}
	}

	private static int FindMatchingQuote()
	{
		++currentIndex;  // Skips the openning `"`

		while (source[currentIndex] != '"')
			++currentIndex;

		return currentIndex;
	}

	private static void SkipNextCharacter()
	{
		++currentIndex;
	}
}

internal class UnexpectedLexemeException: Exception
{
	internal UnexpectedLexemeException(char? firstCharacterOfLexeme)
		: base(message: $"Unexpected first character for a lexeme: '{firstCharacterOfLexeme}'")
	{ }
}

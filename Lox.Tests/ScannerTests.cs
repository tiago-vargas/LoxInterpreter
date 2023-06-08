using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lox.Tests;

[TestClass]
public class ScannerTests
{
	[TestClass]
	public class UnambiguousSingleCharacterTokens
	{
		[TestClass]
		public class SymbolsSeparatedByWhitespace
		{
			[TestMethod]
			public void ScanAllSimpleTokens()
			{
				string source = "( ) { } , . - + ; *";

				var tokens = Scanner.ScanTokens(source);

				CollectionAssert.AreEqual(
					expected: new Token[] {
						new Token(TokenType.LeftParen),
						new Token(TokenType.RightParen),
						new Token(TokenType.LeftBrace),
						new Token(TokenType.RightBrace),
						new Token(TokenType.Comma),
						new Token(TokenType.Dot),
						new Token(TokenType.Minus),
						new Token(TokenType.Plus),
						new Token(TokenType.Semicolon),
						new Token(TokenType.Star),
					},
					actual: tokens
				);
			}

			[TestMethod]
			public void ScanSimpleTokensBetweenVariousWhitespaces()
			{
				string source = "(   )\t +  \n\n *";

				var tokens = Scanner.ScanTokens(source);

				CollectionAssert.AreEqual(
					expected: new Token[] {
						new Token(TokenType.LeftParen),
						new Token(TokenType.RightParen),
						new Token(TokenType.Plus),
						new Token(TokenType.Star),
					},
					actual: tokens
				);
			}
		}

		[TestClass]
		public class SymbolsWithoutWhitespace
		{

			[TestMethod]
			public void ScanSimpleTokensWithoutWhitespace()
			{
				string source = "()+*";

				var tokens = Scanner.ScanTokens(source);

				CollectionAssert.AreEqual(
					expected: new Token[] {
						new Token(TokenType.LeftParen),
						new Token(TokenType.RightParen),
						new Token(TokenType.Plus),
						new Token(TokenType.Star),
					},
					actual: tokens
				);
			}
		}
	}
}

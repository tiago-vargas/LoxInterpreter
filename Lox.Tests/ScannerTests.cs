using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lox.Tests;

[TestClass]
public class ScannerTests
{
[TestClass]
	public class SymbolsSeparatedByWhitespace
	{
		[TestMethod]
		public void ScanAllUnambiguousSingleCharacterTokens()
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
		public void ScanUnambiguousSingleCharacterTokensBetweenManyWhitespace()
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
}

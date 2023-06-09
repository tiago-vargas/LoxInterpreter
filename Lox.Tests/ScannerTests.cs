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

	[TestClass]
	public class MaybeMultiCharacterTokens
	{
		// This class tests for tokens the aren't identifiable until we read
		// their remaining characters

		[TestMethod]
		public void ScanSingleCharacterToken()
		{
			string source = "> = < !";

			var tokens = Scanner.ScanTokens(source);

			CollectionAssert.AreEqual(
				expected: new Token[] {
					new Token(TokenType.Greater),
					new Token(TokenType.Equal),
					new Token(TokenType.Less),
					new Token(TokenType.Bang),
				},
				actual: tokens
			);
		}

		[TestMethod]
		public void ScanMultiCharacterTokens()
		{
			string source = "== != <= >=";

			var tokens = Scanner.ScanTokens(source);

			CollectionAssert.AreEqual(
				expected: new Token[] {
					new Token(TokenType.EqualEqual),
					new Token(TokenType.BangEqual),
					new Token(TokenType.LessEqual),
					new Token(TokenType.GreaterEqual),
				},
				actual: tokens
			);
		}
	}
}

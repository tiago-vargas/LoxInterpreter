namespace Lox;

public class Token
{
	private readonly TokenType type;

	public Token(TokenType type)
	{
		this.type = type;
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as Token);
	}

	private bool Equals(Token? other)
	{
		return this.type == other?.type;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}

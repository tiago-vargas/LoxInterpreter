namespace Lox;

public class Token
{
	private readonly TokenType type;
	private string? value;

	public Token(TokenType type)
	{
		this.type = type;
	}

	public Token(TokenType type, string value)
		: this(type)
	{
		this.value = value;
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as Token);
	}

	private bool Equals(Token? other)
	{
		return this.type == other?.type && this.value == other?.value;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}

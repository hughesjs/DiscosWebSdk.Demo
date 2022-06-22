namespace DiscosWebSdk.Demo.Blazor.Shared.Models.Misc;

public class TypeWrapper : IEquatable<TypeWrapper>
{
	public TypeWrapper(Type type) => Type = type;
	public bool Equals(TypeWrapper? other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}
		return ReferenceEquals(this, other) || Type == other.Type;
	}
	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}
		if (ReferenceEquals(this, obj))
		{
			return true;
		}
		return obj.GetType() == GetType() && Equals((TypeWrapper)obj);
	}

	public override int GetHashCode() => Type.GetHashCode();

	public static bool operator ==(TypeWrapper? left, TypeWrapper? right) => Equals(left, right);

	public static bool operator !=(TypeWrapper? left, TypeWrapper? right) => !Equals(left, right);

	public override string ToString() => Type.Name;

	public Type Type { get; }
	
	
}

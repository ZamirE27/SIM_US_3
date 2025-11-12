namespace SIM_US_3.Domain.Common;
//base class to any valueObject
public abstract class ValueObject
{
    //Abstract method to get the components that defines the equality, so we compare them by values
    protected abstract IEnumerable<object> GetEqualityComponents();

    //Equals method, before comparing the objects we make sme verifications, could not be null nor different types
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj; // this converts the obj in a value object

        //here we compare all the components one by one.
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    //this helps us to find objects quickly
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0) //for each component get a hash, if it is null uses 0
            .Aggregate((x, y) => x ^ y); //Xor Operator, mix all the hashes just in one 
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return left is null || left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }
}
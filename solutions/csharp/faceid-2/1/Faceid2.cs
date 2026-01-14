public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    public override bool Equals(Object obj)
    {
        if (obj == null || !(obj is FacialFeatures))
            return false;
        else
        {
            FacialFeatures other = obj as FacialFeatures;
            return (EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth);
        }
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public override bool Equals(Object obj)
    {
        if (obj == null || !(obj is Identity))
            return false;
        else
        {
            Identity other = obj as Identity;
            return (Email == other.Email && FacialFeatures.Equals(other.FacialFeatures));
        }
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private Dictionary<int, Identity> _identities = new Dictionary<int, Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if(IsRegistered(identity))
        {
            return false;
        }

        _identities[identity.GetHashCode()] = identity;
        
        return true;
    }

    public bool IsRegistered(Identity identity) => _identities.ContainsKey(identity.GetHashCode());

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
}

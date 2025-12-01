using System.Text;
using System.Globalization;

public static class Identifier
{
    public static char[] lowerGreek = {'α', 'β', 'γ', 'δ', 'ε', 'ζ', 'η', 'θ', 'ι', 'κ', 'λ', 'μ', 'ν', 'ξ', 'ο', 'π', 'ρ', 'σ', 'ς', 'τ', 'υ', 'φ', 'χ', 'ψ', 'ω'};
    
    public static string Clean(string identifier)
    {
        if(identifier == "")
            return "";

        StringBuilder cleaned = new StringBuilder();
        
        char[] characters = identifier.ToCharArray();
        for(int i = 0; i < characters.Length; ++i)
        {
            char character = characters[i];
            
            if(character == ' ')
            {
                cleaned.Append("_");
                continue;
            }
            
            if(Char.IsControl(character))
            {
                cleaned.Append("CTRL");
                continue;
            }
            
            if(character == '-' &&
               i < characters.Length - 1 &&
               Char.IsLetter(characters[i+1]))
            {
                cleaned.Append(Char.ToUpper(characters[i+1]));
                ++i;
                continue;
            }

            if(!Char.IsLetter(character))
            {
                continue;
            }

            if(lowerGreek.Contains(character))
            {
                continue;
            }
            
            cleaned.Append(character);
        }        
        
        return cleaned.ToString();
    }
}

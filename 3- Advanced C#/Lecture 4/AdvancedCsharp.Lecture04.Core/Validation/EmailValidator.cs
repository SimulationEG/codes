namespace AdvancedCsharp.Lecture04.Core.Validation;

/// <summary>Deck slides 96–97 — Fact vs Theory + InlineData.</summary>
public static class EmailValidator
{
    public static bool IsValid(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        int at = email.IndexOf('@');
        return at > 0                            // text before @
            && at == email.LastIndexOf('@')      // only one @
            && email.IndexOf('.', at) > at + 1   // a dot after it
            && !email.EndsWith('.');
    }
}

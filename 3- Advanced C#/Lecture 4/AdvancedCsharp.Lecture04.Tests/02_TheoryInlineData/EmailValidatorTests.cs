using AdvancedCsharp.Lecture04.Core.Validation;

namespace AdvancedCsharp.Lecture04.Tests._02_TheoryInlineData;

/// <summary>
/// PPT: "[Fact] vs [Theory] + [InlineData]" + "InlineData for the Bad Inputs Too"
/// </summary>
public class EmailValidatorTests
{
    [Fact] // one example
    public void IsValid_SimpleEmail_ReturnsTrue()
    {
        Assert.True(EmailValidator.IsValid("mona@gmail.com"));
    }

    [Theory] // many good inputs
    [InlineData("mona@gmail.com")]
    [InlineData("ali.hassan@company.eg")]
    [InlineData("a@b.co")]
    public void IsValid_GoodEmails_ReturnsTrue(string email)
    {
        Assert.True(EmailValidator.IsValid(email));
    }

    [Theory] // one row = one way to break it
    [InlineData("")]
    [InlineData("mona")]            // no @
    [InlineData("@gmail.com")]      // nothing before @
    [InlineData("mona@@gmail.com")] // two @
    [InlineData("mona@gmail")]      // no dot after @
    [InlineData("mona@gmail.")]     // ends with a dot
    public void IsValid_BadEmails_ReturnsFalse(string email)
    {
        Assert.False(EmailValidator.IsValid(email));
    }
}

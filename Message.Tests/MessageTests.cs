using Xunit;
using Message;

namespace Message.Tests;

public class MessageTests
{
    
    [Fact]
    public void TestEmptyInput()
    {
        string input = "";
        string expected = "";
        string result = Message.OldPhonePad(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestInput()
    {
        string input = "222 2 22#";
        string expected = "CAB";
        string result = Message.OldPhonePad(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestInputWithSpecialChar()
    {
        string input = "222 2 221222 2 777#";
        string expected = "CAB&CAR";
        string result = Message.OldPhonePad(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestInputWithBackSpace()
    {
        string input = "8 88777444666*664#";
        string expected = "TURING";
        string result = Message.OldPhonePad(input);

        Assert.Equal(expected, result);
    }
}

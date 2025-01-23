using Xunit;
using Message;

namespace Message.Tests;

public class MessageTests
{
    
    [Fact]
    public void TestSampleInput()
    {
        string input1 = "33#";
        string expected1 = "E";
        string result1 = Message.OldPhonePad(input1);
        Assert.Equal(expected1, result1);

        string input2 = "227*#";
        string expected2 = "B";
        string result2 = Message.OldPhonePad(input2);
        Assert.Equal(expected2, result2);

        string input3 = "4433555 555666#";
        string expected3 = "HELLO";
        string result3 = Message.OldPhonePad(input3);
        Assert.Equal(expected3, result3);
    }
    
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

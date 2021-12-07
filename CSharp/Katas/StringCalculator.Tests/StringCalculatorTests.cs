using System;
using NUnit.Framework;

namespace StringCalculator.Tests;

public class Tests
{
    private StringCalculator _stringCalculator;
    
    [SetUp]
    public void Setup()
    {
        _stringCalculator = new StringCalculator(); 
    }

    [Test]
    public void Add_EmptyString()
    {
        var str = string.Empty;

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void Add_OneNumber()
    {
        var str = "1";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(1, result);
    }

    [Test]
    public void Add_TwoNumber()
    {
        var str = "1,2";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(3, result);
    }

    [Test]
    public void Add_OneNumberOneCharacter()
    {
        var str = "1,c";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(1, result);
    }

    [Test]
    public void Add_NoNumbers()
    {
        var str = "a,b,c";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void Add_4Numbers()
    {
        var str = "1,3,5,7";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(1 + 3 + 5 + 7, result);
    }
    
    [Test]
    public void Add_HandleNewLinew()
    {
        var str = "1,\n,2";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(3, result);
    }
    
    [Test]
    public void Add_HandleNewDelimeter()
    {
        // format: //[delimiter]\n[numbers]
        var str = "//;\n1;\n;2";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(3, result);
    }
    
    [Test]
    public void Add_HandleNewWrongDelimeter()
    {
        // format: //[delimiter]\n[numbers]
        var str = "// \n1;\n;2";

        var result = _stringCalculator.Add(str);

        Assert.AreEqual(0, result);
    }
    
    
    
    [Test]
    public void Add_HandleNegativeNumbers_Exception()
    {
        var str = "1,2,-3";

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _stringCalculator.Add(str));

        Console.WriteLine(ex?.Message);
    }
    
    //Up next 5 + refactoring
}
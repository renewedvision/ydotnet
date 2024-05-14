using NUnit.Framework;
using YDotNet.Document;

namespace YDotNet.Tests.Unit.XmlElements;

public class InsertElementTests
{
    [Test]
    public void InsertSingleElement()
    {
        // Arrange
        var doc = new Doc();
        var xmlElement = doc.XmlElement("xml-element");

        // Act
        var transaction = doc.WriteTransaction();
        var addedXmlElement = xmlElement.InsertElement(transaction, index: 0, "color");
        var childLength = xmlElement.ChildLength(transaction);
        transaction.Commit();

        // Assert
        Assert.That(addedXmlElement.Handle, Is.Not.EqualTo(0));
        Assert.That(addedXmlElement.Tag, Is.EqualTo("color"));
        Assert.That(childLength, Is.EqualTo(expected: 1));
    }

    [Test]
    public void InsertMultipleElements()
    {
        // Arrange
        var doc = new Doc();
        var xmlElement = doc.XmlElement("xml-element");

        // Act
        var transaction = doc.WriteTransaction();
        var xmlElement1 = xmlElement.InsertElement(transaction, index: 0, "color");
        var xmlElement2 = xmlElement.InsertElement(transaction, index: 0, "width");
        var xmlElement3 = xmlElement.InsertElement(transaction, index: 0, "height");
        var childLength = xmlElement.ChildLength(transaction);
        transaction.Commit();

        // Assert
        Assert.That(xmlElement1.Tag, Is.EqualTo("color"));
        Assert.That(xmlElement2.Tag, Is.EqualTo("width"));
        Assert.That(xmlElement3.Tag, Is.EqualTo("height"));
        Assert.That(childLength, Is.EqualTo(expected: 3));
    }
}

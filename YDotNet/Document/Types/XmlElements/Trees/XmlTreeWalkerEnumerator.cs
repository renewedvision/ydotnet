using System.Collections;
using YDotNet.Document.Cells;
using YDotNet.Native.Types;

namespace YDotNet.Document.Types.XmlElements.Trees;

/// <summary>
///     Represents the tree walker to provide instances of <see cref="Output" /> or
///     <c>null</c> to <see cref="XmlTreeWalker" />.
/// </summary>
internal class XmlTreeWalkerEnumerator : IEnumerator<Output>
{
    private readonly XmlTreeWalker treeWalker;
    private Output? current;

    /// <summary>
    ///     Initializes a new instance of the <see cref="XmlTreeWalkerEnumerator" /> class.
    /// </summary>
    /// <param name="treeWalker">
    ///     The <see cref="XmlTreeWalker" /> instance used by this enumerator.
    ///     Check <see cref="XmlTreeWalker" /> for more details.
    /// </param>
    public XmlTreeWalkerEnumerator(XmlTreeWalker treeWalker)
    {
        this.treeWalker = treeWalker;
    }

    /// <inheritdoc />
    public Output Current => current!;

    /// <inheritdoc />
    object IEnumerator.Current => current!;

    /// <inheritdoc />
    public void Dispose()
    {
        treeWalker.Dispose();
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        var handle = XmlElementChannel.TreeWalkerNext(treeWalker.Handle);

        if (handle != nint.Zero)
        {
            current = Output.CreateAndRelease(handle, treeWalker.Doc);
            return true;
        }

        current = null!;
        return false;
    }

    /// <inheritdoc />
    public void Reset()
    {
        throw new NotImplementedException();
    }
}

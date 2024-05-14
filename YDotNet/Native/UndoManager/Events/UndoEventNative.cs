using System.Runtime.InteropServices;
using YDotNet.Infrastructure;
using YDotNet.Native.Document.State;

namespace YDotNet.Native.UndoManager.Events;

[StructLayout(LayoutKind.Sequential)]
internal struct UndoEventNative
{
    public UndoEventKindNative KindNative { get; set; }

    public nint OriginHandle { get; set; }

    public uint OriginLength { get; set; }

    public DeleteSetNative Insertions { get; set; }

    public DeleteSetNative Deletions { get; set; }

    public byte[]? Origin()
    {
        if (OriginHandle == 0 || OriginLength <= 0)
        {
            return null;
        }

        return MemoryReader.ReadBytes(OriginHandle, OriginLength);
    }
}

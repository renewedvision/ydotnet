using System.Runtime.InteropServices;
using YDotNet.Infrastructure;
using YDotNet.Native.Cells.Outputs;
using YDotNet.Native.Types.Maps;

namespace YDotNet.Native.Types.Texts;

[StructLayout(LayoutKind.Explicit, Size = Size)]
internal readonly struct TextChunkNative
{
    public const int Size = OutputNative.Size + 8 + 8;

    [field: FieldOffset(offset: 0)]
    public OutputNative Data { get; }

    [field: FieldOffset(OutputNative.Size)]
    public uint AttributesLength { get; }

    [field: FieldOffset(OutputNative.Size + 8)]
    public nint AttributesHandle { get; }

    public NativeWithHandle<MapEntryNative>[] Attributes()
    {
        if (AttributesHandle == 0 || AttributesLength == 0)
        {
            return Array.Empty<NativeWithHandle<MapEntryNative>>();
        }

        return MemoryReader.ReadStructsWithHandles<MapEntryNative>(AttributesHandle, AttributesLength).ToArray();
    }
}

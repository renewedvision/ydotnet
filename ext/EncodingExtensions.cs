namespace System.Text
{
    public static class EncodingExtensions
    {
        // Copied from:
        // https://github.com/dotnet/runtime/blob/ed339b3670f6d3d971a5b56a6572d0b07095706d/src/libraries/System.Private.CoreLib/src/System/Text/Encoding.cs#L913
        public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes)
        {
            unsafe
            {
                fixed (byte* bytesPtr = bytes)
                {
                    return Encoding.UTF8.GetString(bytesPtr, bytes.Length);
                }
            }
        }

        // Copied from:
        // https://github.com/dotnet/runtime/blob/ed339b3670f6d3d971a5b56a6572d0b07095706d/src/libraries/System.Private.CoreLib/src/System/Text/Encoding.cs#L727
        public static int GetBytes(this Encoding encoding, ReadOnlySpan<char> chars, Span<byte> bytes)
        {
            unsafe
            {
                fixed (char* charsPtr = chars)
                {
                    fixed (byte* bytesPtr = bytes)
                    {
                        return encoding.GetBytes(charsPtr, chars.Length, bytesPtr, bytes.Length);
                    }
                }
            }
        }
    }
}

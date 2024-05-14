namespace YDotNet.Infrastructure.Extensions;

internal static class IntPtrExtensions
{
    public static nint Checked(this nint input)
    {
        if (input == 0)
        {
            ThrowHelper.Null();
        }

        return input;
    }
}

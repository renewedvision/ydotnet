namespace System
{
    public static class ArgumentNullExceptionHelper
    {
        // Copied from:
        // https://github.com/dotnet/runtime/blob/b48a6391f99e6ad478d87f8b9876132efe67f132/src/libraries/System.Private.CoreLib/src/System/ArgumentNullException.cs#L54
        public static void ThrowIfNull(object? argument, string? paramName = null)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}

namespace System
{
    public static class NIntExtensions
    {
        public static unsafe void* ToPointer(this nint value) => (void*)value;
    }
}

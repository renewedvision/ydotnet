namespace System
{
    public static class RandomHelper
    {
        private static readonly ThreadLocal<Random> _sharedRandom = new ThreadLocal<Random>();

        public static Random Shared => _sharedRandom.Value;
    }
}

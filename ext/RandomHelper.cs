namespace System
{
    public static class RandomHelper
    {
        private static readonly ThreadLocal<Random> _sharedRandom = new ThreadLocal<Random>(() => new());

        public static Random Shared => _sharedRandom.Value;
    }
}

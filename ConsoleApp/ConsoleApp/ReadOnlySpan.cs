namespace ConsoleApp
{
    internal class ReadOnlySpan<T>
    {
        private byte[] bytes;

        public ReadOnlySpan(byte[] bytes)
        {
            this.bytes = bytes;
        }
    }
}
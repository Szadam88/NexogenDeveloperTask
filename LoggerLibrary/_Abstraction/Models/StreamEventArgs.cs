namespace LoggerLibrary._Abstraction.Models
{
    public sealed class StreamEventArgs : EventArgs
    {
        public byte[] Bytes { get; }

        public StreamEventArgs(byte[] bytes) => Bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));

    }
}
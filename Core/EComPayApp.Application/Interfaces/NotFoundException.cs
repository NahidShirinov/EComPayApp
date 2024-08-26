using System.Runtime.Serialization;

namespace EComPayApp.Application.Interfaces
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        private string v;
        private Guid id;

        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string v, Guid id)
        {
            this.v = v;
            this.id = id;
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
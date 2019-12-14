using System;
using System.Runtime.Serialization;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
    [Serializable]
    internal class ModelFutarNotValidAddressExeption : Exception
    {
        public ModelFutarNotValidAddressExeption()
        {
        }

        public ModelFutarNotValidAddressExeption(string message) : base(message)
        {
        }

        public ModelFutarNotValidAddressExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelFutarNotValidAddressExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
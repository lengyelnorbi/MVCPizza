using System;
using System.Runtime.Serialization;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
    [Serializable]
    internal class ModelFutarNotValidPhonenumberExeption : Exception
    {
        public ModelFutarNotValidPhonenumberExeption()
        {
        }

        public ModelFutarNotValidPhonenumberExeption(string message) : base(message)
        {
        }

        public ModelFutarNotValidPhonenumberExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelFutarNotValidPhonenumberExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
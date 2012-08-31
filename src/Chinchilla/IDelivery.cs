using System;

namespace Chinchilla
{
    /// <summary>
    /// A delivery is a single message read from a queue. It must be
    /// accepted or rejected.
    /// </summary>
    public interface IDelivery
    {
        /// <summary>
        /// The delivery tag
        /// </summary>
        ulong Tag { get; }

        /// <summary>
        /// The raw body of the delivery
        /// </summary>
        byte[] Body { get; }

        /// <summary>
        /// The original routing key for this delivery
        /// </summary>
        string RoutingKey { get; }

        /// <summary>
        /// Indicates that this delivery has been processed and can be
        /// removed from the exchange
        /// </summary>
        void Accept();

        /// <summary>
        /// Called when a delivery fails
        /// </summary>
        /// <param name="e">The exception which caused this failure</param>
        void Failed(Exception e);
    }
}
﻿namespace Transmitto;

    public interface ISubscription : IDisposable
    {
        /// <summary>
        /// Gets the number of times the subscription has been invoked.
        /// </summary>
        int Invocations { get; }

        /// <summary>
        /// Gets the event identifier associated with this <see cref="ISubscription"/>.
        /// </summary>
        EventId EventId { get; }

        /// <summary>
        /// Unsubscribes this instance from the <see cref="IEventAggregator"/> which disposes this subscription prevents any further invocations.
        /// </summary>
        /// <returns></returns>
        bool Unsubscribe();

        /// <summary>
        /// Publishes the specified data to the <see cref="IEventAggregator"/>.
        /// </summary>
        void Publish<T>(T data);

        /// <summary>
        /// Increments the <see cref="Invocations"/> count and Invokes this subscription. This is for internal use only.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        void Invoke<T>(EventContext<T> context);
    }
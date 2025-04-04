﻿using Transmitto.Net;

namespace Transmitto.Server;

public interface IServerEventManager : IEventAggregator
{
	Task PublishServerEventAsync<TData>(EventId eventId, ConnectionContext context, TData data, CancellationToken token);
	
	Task RunAsync(CancellationToken token);

	//ISubscription Subscribe(string topic, ConnectionContext context);
}
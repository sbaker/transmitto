﻿using System.Threading.Channels;

namespace Transmitto.Channels;

/// <summary>
/// When implemented in a derived class; provides the underlying reader to <see cref="IBackgroundWorkerQueueReader"/>
/// </summary>
/// <typeparam name="TReader"></typeparam>
public interface ITransmittoChannelReaderProvider<TReader>
{
	/// <summary>
	/// Gets the <typeparamref name="TReader"/>.
	/// </summary>
	/// <returns>The <typeparamref name="TReader"/></returns>
	ChannelReader<TReader> GetReader();
}

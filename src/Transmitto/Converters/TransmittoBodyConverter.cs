﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Transmitto.Net.Models;

namespace Transmitto.Converters;

public class TransmittoBodyConverter<TBody> : JsonConverter<TBody> where TBody : TransmittoMessageBody, new()
{
	public override TBody? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var jsonDocument = JsonDocument.ParseValue(ref reader);

		var result = jsonDocument.Deserialize<TBody>() ?? new();
		result.RawBody = jsonDocument.RootElement.ToString();

		return result;
	}

	public override void Write(Utf8JsonWriter writer, TBody value, JsonSerializerOptions options)
	{
		var type = value.GetType();
		var properties = type.GetProperties();

		writer.WriteStartObject();

		foreach (var property in properties)
		{
			var propertyValue = property.GetValue(value)?.ToString();

			if (value is not null)
			{
				writer.WritePropertyName(property.Name);

				writer.WriteStringValue(propertyValue);
			}
		}

		writer.WriteEndObject();
	}
}

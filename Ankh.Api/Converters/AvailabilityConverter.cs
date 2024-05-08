﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Ankh.Api.Models.Enums;

namespace Ankh.Api.Converters;

public class AvailabilityConverter : JsonConverter<Availability> {
    public override Availability Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var str = reader.GetString();
        return string.IsNullOrWhiteSpace(str)
            ? Availability.Unknown
            : Enum.Parse<Availability>(str);
    }
    
    public override void Write(Utf8JsonWriter writer, Availability value, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }
}
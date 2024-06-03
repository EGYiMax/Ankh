﻿using System.Text.Json.Serialization;

namespace Ankh.Api.Models.Interfaces;

public class VUUser {
    [JsonPropertyName("legacy_cid, cid")]
    public ulong UserId { get; init; }
    
    [JsonPropertyName("username, avname")]
    public string Username { get; init; }
    
    [JsonPropertyName("avatar_image, avpic_url")]
    public string AvatarUrl { get; init; }
    
    [JsonPropertyName("registered")]
    public DateTimeOffset RegisteredOn { get; init; }
}
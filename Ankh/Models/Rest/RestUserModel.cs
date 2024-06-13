﻿using System.Text.Json.Serialization;
using Ankh.Converters;
using Ankh.Models.Enums;

namespace Ankh.Models.Rest;

public record RestUserModel(
    [property: JsonPropertyName("legacy_cid")]
    long UserId,
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("avatar_image")]
    string AvatarImage,
    [property: JsonPropertyName("registered")]
    long RegisteredOn,
    [property: JsonPropertyName("gender")]
    string Gender,
    [property: JsonPropertyName("age"),
               JsonConverter(typeof(NullIntConverter))]
    int Age,
    [property: JsonPropertyName("relationship_status"),
               JsonConverter(typeof(JsonNumberEnumConverter<RelationshipStatus>))]
    RelationshipStatus RelationshipStatus,
    [property: JsonPropertyName("orientation")]
    int Orientation,
    [property: JsonPropertyName("looking_for"),
               JsonConverter(typeof(JsonNumberEnumConverter<LookingFor>))]
    LookingFor LookingFor,
    [property: JsonPropertyName("interests")]
    string Interests,
    [property: JsonPropertyName("created")]
    DateTimeOffset CreatedOn,
    [property: JsonPropertyName("display_name")]
    string DisplayName,
    [property: JsonPropertyName("country")]
    string Country,
    [property: JsonPropertyName("state")]
    string State,
    [property: JsonPropertyName("avatar_portrait_image")]
    Uri AvatarPortraitImage,
    [property: JsonPropertyName("is_vip")]
    bool IsVip,
    [property: JsonPropertyName("is_ap")]
    bool HasAccessPass,
    [property: JsonPropertyName("is_creator")]
    bool IsCreator,
    [property: JsonPropertyName("is_adult")]
    bool IsAdult,
    [property: JsonPropertyName("is_ageverified")]
    bool IsAgeverified,
    [property: JsonPropertyName("is_staff")]
    bool IsStaff,
    [property: JsonPropertyName("is_greeter")]
    bool IsGreeter,
    [property: JsonPropertyName("greeter_score")]
    int GreeterScore,
    [property: JsonPropertyName("badge_level")]
    int BadgeLevel,
    [property: JsonPropertyName("persona_type")]
    long PersonaType,
    [property: JsonPropertyName("availability"),
               JsonConverter(typeof(AvailabilityConverter))]
    Availability Availability,
    [property: JsonPropertyName("is_on_hold")]
    bool IsOnHold,
    [property: JsonPropertyName("is_discussion_moderator")]
    bool IsDiscussionModerator,
    [property: JsonPropertyName("online")]
    bool Online,
    [property: JsonPropertyName("tagline")]
    string Tagline,
    [property: JsonPropertyName("thumbnail_url")]
    Uri ThumbnailUrl,
    [property: JsonPropertyName("is_host"),
               JsonConverter(typeof(IntToBoolConverter))]
    bool IsHost,
    [property: JsonPropertyName("is_current_user")]
    bool IsCurrentUser,
    [property: JsonPropertyName("ads_category")]
    string AdsCategory,
    [property: JsonPropertyName("ads_category_p")]
    bool AdsCategoryP,
    [property: JsonPropertyName("email")]
    string Email,
    [property: JsonPropertyName("is_email_verified")]
    bool IsEmailVerified,
    [property: JsonPropertyName("last_password_change")]
    DateTimeOffset LastPasswordChange,
    [property: JsonPropertyName("is_2fa_required")]
    object Is2FARequired,
    [property: JsonPropertyName("has_nft")]
    bool HasNft,
    [property: JsonPropertyName("vip_tier")]
    int VipTier,
    [property: JsonPropertyName("vip_platform"),
               JsonConverter(typeof(NullIntConverter))]
    int VipPlatform,
    [property: JsonPropertyName("has_legacy_vip")]
    bool HasLegacyVip
) : IRestModel;
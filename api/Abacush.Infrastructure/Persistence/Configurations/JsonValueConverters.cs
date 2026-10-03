using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Abacush.Infrastructure.Persistence.Configurations;

internal static class JsonValueConverters
{
    public static ValueConverter<Dictionary<string, string>, string> DictionaryConverter { get; } =
        new(
            value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
            value => JsonSerializer.Deserialize<Dictionary<string, string>>(value, (JsonSerializerOptions?)null)
                ?? new Dictionary<string, string>());

    public static ValueComparer<Dictionary<string, string>> DictionaryComparer { get; } =
        new(
            (left, right) => left.Count == right.Count && left.All(pair => right.Contains(pair)),
            value => value.Aggregate(0, (hash, pair) => HashCode.Combine(hash, pair.Key, pair.Value)),
            value => value.ToDictionary(pair => pair.Key, pair => pair.Value));

    public static ValueConverter<List<string>, string> StringListConverter { get; } =
        new(
            value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
            value => JsonSerializer.Deserialize<List<string>>(value, (JsonSerializerOptions?)null)
                ?? new List<string>());

    public static ValueComparer<List<string>> StringListComparer { get; } =
        new(
            (left, right) => left.SequenceEqual(right),
            value => value.Aggregate(0, (hash, item) => HashCode.Combine(hash, item)),
            value => value.ToList());
}

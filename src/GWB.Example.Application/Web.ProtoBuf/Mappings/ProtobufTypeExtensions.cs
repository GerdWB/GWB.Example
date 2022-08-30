namespace GWB.Example.Web.ProtoBuf.Mappings;

using System.Globalization;
using System.Runtime.CompilerServices;
using Google.Protobuf;

public static class ProtoBufTypeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? FromProtoString(this string? s) =>
        string.IsNullOrEmpty(s)
            ? null
            : s;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime ProtoStringToDateTime(this string s) =>
        DateTime.ParseExact(s, "R", CultureInfo.InvariantCulture);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid ProtoStringToGuid(this string s) => Guid.Parse(s);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime? ProtoStringToNullableDateTime(this string s) =>
        string.IsNullOrEmpty(s)
            ? null
            : s.ProtoStringToDateTime();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid? ProtoStringToNullableGuid(this string s) =>
        string.IsNullOrEmpty(s)
            ? null
            : s.ProtoStringToGuid();


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ByteString ToProtoBytes(this byte[]? bytes) =>
        bytes != null ? ByteString.CopyFrom(bytes) : ByteString.Empty;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToProtoDateString(this DateTime dateTime) => dateTime.ToString("R");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToProtoDateString(this DateTime? dateTime) =>
        dateTime.HasValue
            ? dateTime.Value.ToProtoDateString()
            : string.Empty;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToProtoString(this string s) =>
        string.IsNullOrEmpty(s)
            ? string.Empty
            : s;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToProtoString(this Guid guid) => guid.ToString("N");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToProtoString(this Guid? guid) =>
        guid.HasValue
            ? guid.Value.ToProtoString()
            : string.Empty;
}
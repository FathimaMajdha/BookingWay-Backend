using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookingApp.Infrastructure.Serialization
{
    
    public class DateOnlyConverter : JsonConverter<DateTime?>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            return string.IsNullOrEmpty(str) ? null : DateTime.Parse(str);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString(Format));
            else
                writer.WriteNullValue();
        }
    }

}

using System.Text.Encodings.Web;
using System.Text.Json;

namespace Core.Extensions
{
    public static class Serializer
    {

        static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
        };

        public static string Serialize<T>(this T @object)
        {
            return JsonSerializer.Serialize(@object,options);
        }
        public static T Deserialize<T>(this string @object)
        {
            return JsonSerializer.Deserialize<T>(@object, options);
        }



    }
}

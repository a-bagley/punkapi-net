using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PunkApiNet.Tests.TestHelpers
{
    internal class JsonHelper<T> where T : class
    {
        internal static T FromJson(string json) => JsonSerializer.Deserialize<T>(json);
        internal static ValueTask<T> FromJsonStreamAsync(Stream jsonStream) => JsonSerializer.DeserializeAsync<T>(jsonStream);
    }
}

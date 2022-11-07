
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
namespace DgiiTest.Core.Entities
{
    public partial class Contribuyentes
        {
            public string RncCedula { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Estatus { get; set; }
        }

        public partial class Contribuyentes
        {
            public static Contribuyentes FromJson(string json) => JsonConvert.DeserializeObject<Contribuyentes>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Contribuyentes self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }



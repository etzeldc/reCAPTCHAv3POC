using System.Text.Json.Serialization;

namespace reCAPTCHAv3POC.Responses
{
    public class SignupResponse
    {
        public bool Success { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Error { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ErrorCode { get; set; }
    }
}

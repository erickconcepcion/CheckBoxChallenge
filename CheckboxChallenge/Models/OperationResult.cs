using System.Text.Json.Serialization;

namespace CheckboxChallenge.Models
{
    public class OperationResult
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Result { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? Errors { get; set; }

    }
}

using System.Dynamic;
using System.Text.Json.Serialization;

public class LogModel
{
    [JsonPropertyName("log_type")]
    public required string LogType { get; set; }

    [JsonPropertyName("timestamp")]
    public required string TimeStamp { get; set; }

    [JsonPropertyName("log_message")]
    public required string LogMessage { get; set; }

    [JsonPropertyName("stack_trace")]
    public string? StackTrace { get; set; }
}
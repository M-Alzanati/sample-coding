using System.Text.Json;

namespace Example.CodingTask.Core.Transient
{
    public class ErrorDetailsDto
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

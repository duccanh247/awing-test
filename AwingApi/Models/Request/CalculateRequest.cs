namespace AwingApi.Models.Request
{
    public class CalculateRequest
    {
        public int P { get; set; }
        public List<List<int>> Matrix { get; set; } = new List<List<int>>();
    }
}

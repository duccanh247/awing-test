namespace AwingApi.Entities
{
    public class CalculationLog
    {
        public int Id { get; set; }
        public int Var_N { get; set; }
        public int Var_M { get; set; }
        public int Var_P { get; set; }
        public string Matrix { get; set; } = string.Empty;
        public double Result { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

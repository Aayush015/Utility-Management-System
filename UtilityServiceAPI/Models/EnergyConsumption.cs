namespace UtilityServiceAPI.Models {
    public class EnergyConsumption {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public float UsageKwh { get; set; }
    }
}
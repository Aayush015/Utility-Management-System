namespace UtilityServiceAPI.Models {
    public class ServiceRequest {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
namespace RealTimeChat.ApplicationCore.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string? MediaUrl { get; set; }
        public bool Seen { get; set; }
        public DateTime Date { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}

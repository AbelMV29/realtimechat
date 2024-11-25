using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeChat.ApplicationCore.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int MessageId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public virtual User Receiver { get; set; }
        public virtual Message Message { get; set; }
        public bool Seen { get; set; }
    }
}

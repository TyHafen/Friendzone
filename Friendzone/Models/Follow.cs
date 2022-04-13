namespace Friendzone.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public string followerId { get; set; }
        public string followingId { get; set; }
    }
}
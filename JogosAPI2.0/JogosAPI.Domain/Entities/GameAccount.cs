namespace JogosAPI.Domain.Entities
{
    public class GameAccount : BaseEntity
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

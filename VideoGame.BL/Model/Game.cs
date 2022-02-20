namespace VideoGame.DAL.Model
{
    public enum Genre
    {
        Action,
        Horror,
        TheRoyalBattle,
        Simulation,
        Strategies
    }

    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public Genre Genre { get; set; }
    }
}

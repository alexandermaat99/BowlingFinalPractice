namespace BowlingFinalPractice.Models
{
    public interface IBowlingRepository
    {
        List<Bowler> Bowlers { get; }
        public void AddBowler(Bowler bowler);

        IEnumerable<Bowler> GetAllBowlers();

        Bowler GetBowlerByID(int id);
        void UpdateBowler(Bowler bowler);
    }

}

using Microsoft.EntityFrameworkCore;

namespace BowlingFinalPractice.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingLeagueContext _context;

        public EFBowlingRepository(BowlingLeagueContext temp) 
        {
            _context = temp;
        }

        public List<Bowler> Bowlers => _context.Bowlers.ToList();

        public void AddBowler(Bowler bowler)
        {
            _context.Bowlers.Add(bowler);
            _context.SaveChanges();
        }

        public IEnumerable<Bowler> GetAllBowlers()
        {
            return _context.Bowlers.Include(b=>b.Team).ToList();
        }

        public Bowler GetBowlerByID(int id)
        {
            return _context.Bowlers.FirstOrDefault(b => b.BowlerId == id);
        }

        public void UpdateBowler(Bowler bowler)
        {
            _context.Bowlers.Update(bowler);
            _context.SaveChanges();
        }
    }
}

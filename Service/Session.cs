using Authentication.Data;
using Authentication.Data.Models;
using Authentication.Data.VModel;

namespace Authentication.Service
{
    public class Session
    {
        private readonly DataContext _context;
        public Session(DataContext context)
        {
            _context = context;
        }
        public async Task AddSession(SessionVM session)
        {
            var sess = new Sessiontable()
            {
                Name=session.Name,
                StartDate = session.StartDate,
                EndDate = session.EndDate,
                
            };
            
            _context.sessiontables.Add(sess);
            await _context.SaveChangesAsync();
        }
        public List<SessionVM> GetSession()
        {
            var res = _context.sessiontables.Select(D => new SessionVM
            {
                Name= D.Name,
                StartDate = D.StartDate,
                EndDate= D.EndDate,
            }).ToList();
            return res;
        }
        public async Task UpdateSession(int Id, SessionVM session)
        {
            var sesupdate = _context.sessiontables.Find(Id);
            sesupdate.Name=session.Name;
            sesupdate.StartDate=session.StartDate;
            sesupdate.EndDate=session.EndDate;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSession(int Id)
        {
            var res = _context.sessiontables.Find(Id);
            _context.sessiontables.Remove(res);
            await _context.SaveChangesAsync();
        }
    }

}

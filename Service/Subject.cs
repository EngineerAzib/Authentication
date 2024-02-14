using Authentication.Data;
using Authentication.Data.Models;
using Authentication.Data.VModel;

namespace Authentication.Service
{
    public class Subject
    {
        private readonly DataContext _context;
        public Subject(DataContext context)
        {
            _context = context;
        }

        public async Task PostSubject(SubjecttblVM subject)
        {
            var sub = new Subjecttble()
            {
                Name = subject.Name,
                RegDate = DateTime.Now(), // Assign DateTime.Now instead of DateTime.Now.Date
                Description = subject.Description
            };

            _context.SubjectTables.Add(sub);
            await _context.SaveChangesAsync();
        }
        public async Task GetSubject()
        {
            var res = _context.SubjectTables.ToList();
            return res
        }
        public async Tast UpdateSubject(SubjecttblVM subject,int Id)
        {
            var UpdateSubject = _context.SubjectTables.Find(Id);
            UpdateSubject.Name=subject.Name,
             UpdateSubject.RegDate = DateTime.Now();
            UpdateSubject.Description=subject.Description
  await _context.SaveChangesAsync();
        }

    }
}

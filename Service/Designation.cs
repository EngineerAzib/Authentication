using Authentication.Data;
using Authentication.Data.Models;
using Authentication.Data.VModel;

namespace Authentication.Service
{
    public class Designation
    {
        private readonly DataContext _context;
        public Designation(DataContext context)
        {
            _context = context; 
        }
        public async Task AddDesignation(DesignationVM designation)
        {
            var des = new DesignationTable()
            {
                Title = designation.Title,
                IsActive= designation.IsActive,
            };
            _context.DesignationTable.Add(des);
            await _context.SaveChangesAsync();
        }
        public List<DesignationVM> GetDesignations()
        {
            var res = _context.DesignationTable.Select(D=>new DesignationVM
            {
                Title= D.Title,
                IsActive= D.IsActive,
            }).ToList();
            return res;
        } 
        public async Task UpdateDesignation(int Id,DesignationVM designation)
        {
            var desiupdate = _context.DesignationTable.Find(Id);
            desiupdate.Title = designation.Title;
            desiupdate.IsActive = designation.IsActive;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDesignation(int Id)
        {
            var res = _context.DesignationTable.Find(Id);
            _context.DesignationTable.Remove(res);
            await _context.SaveChangesAsync();
        }
    }
}

using Authentication.Data;
using Authentication.Data.Models;
using Authentication.Data.VModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Service
{
    public class Programe
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public Programe(DataContext context, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task AddPrograme(ProgrameVM programe)
        {
            try
            {
               

                // Create a new ProgrameTable instance
                var program = new Programetbl()
                {
                  
                    Name = programe.Name,
                    StartDate = programe.StartDate,
                    IsActive = programe.IsActive,
                };

                // Add the ProgrameTable instance to the context and save changes
                _context.ProgrameTables.Add(program);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                Console.WriteLine($"Error adding programe: {ex.Message}");
                throw; // Rethrow the exception to propagate it further
            }
        }

        public List<programeView> GetPrograme()
        {
            var programeList = _context.ProgrameTables.Select(p => new programeView
            {
                // Map properties from Programetbl to Programe object
                Name = p.Name,
                StartDate = p.StartDate,
                IsActive = p.IsActive
            }).ToList();

            return programeList;
        }
        public async Task UpdatePrograme(programeView programe,int Id)
        {
            var updatepro = _context.ProgrameTables.Find(Id);
            updatepro.Name= programe.Name;
            updatepro.StartDate= programe.StartDate;
            updatepro.IsActive= programe.IsActive;
            await _context.SaveChangesAsync();

        }
        public async Task DeletePrograme(int Id)
        {
            var delpro = _context.ProgrameTables.Find(Id);
            _context.ProgrameTables.Remove(delpro);
            await _context.SaveChangesAsync();
        }

    }
}

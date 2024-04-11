using Authentication.Data.VModel;
using Authentication.Data;
using Microsoft.AspNetCore.Identity;
using Authentication.Data.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Service
{
    public class Staff
    {
       
        private readonly DataContext _context;

        public Staff(DataContext context)
        {
            _context = context;
        }

        public async Task AddStaffAsync(StaffVM staff, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    var extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                    // Construct the file path where the image will be saved
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "All_Image", fileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Create a new StaffTable entity and assign values
                    var staf = new StaffTable()
                    {
                        Name = staff.Name,
                        Designation_ID = staff.Designation_ID,
                        ContactNo = staff.ContactNo,
                        Address = staff.Address,
                        EmailAddress = staff.EmailAddress,
                        Qualification = staff.Qualification,
                        IsActive = staff.IsActive,
                        Description = staff.Description,
                        PhotoPath=imagePath
                       
                    };

                    // Add the entity to the DbContext and save changes
                    _context.staffTables.Add(staf);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // You may want to return a specific error response
            }
        }

        public List<StaffVM> GetStaff()
        {
            var stafflist = _context.staffTables.Select(p => new StaffVM
            {
                Name = p.Name,
                Designation_ID = p.Designation_ID,
                ContactNo = p.ContactNo,
                Address = p.Address,
                EmailAddress = p.EmailAddress,
                Qualification = p.Qualification,
                IsActive = p.IsActive,
                Description = p.Description,
               
            }).ToList();

            return stafflist;
        }



        public async Task UpdateStaff(StaffVM staff, IFormFile imageFile, int Id)
        {
            try
            {
                var existingStaff = await _context.staffTables.FindAsync(Id);

                if (existingStaff != null)
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                        var extension = Path.GetExtension(imageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                        // Construct the file path where the image will be saved
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "All_Image", fileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        existingStaff.PhotoPath = imagePath;
                    }

                    // Update the existing staff entity with the new values
                    existingStaff.Name = staff.Name;
                    existingStaff.Designation_ID = staff.Designation_ID;
                    existingStaff.ContactNo = staff.ContactNo;
                    existingStaff.Address = staff.Address;
                    existingStaff.EmailAddress = staff.EmailAddress;
                    existingStaff.Qualification = staff.Qualification;
                    existingStaff.IsActive = staff.IsActive;
                    existingStaff.Description = staff.Description;

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Handle case where staff with specified Id is not found
                    // You may want to return a specific error response or throw an exception
                    throw new ArgumentException("Staff with the specified Id does not exist.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // You may want to return a specific error response or rethrow the exception
                throw new Exception("Error updating staff: " + ex.Message);
            }
        }


        public async Task DeleteStaff(int Id)
        {
            var delpro = await _context.staffTables.FindAsync(Id);
            if (delpro != null)
            {
                // Remove the image file associated with the staff member, if it exists
                if (!string.IsNullOrEmpty(delpro.PhotoPath) && File.Exists(delpro.PhotoPath))
                {
                    try
                    {
                        File.Delete(delpro.PhotoPath);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception if file deletion fails
                        Console.WriteLine($"Error deleting image: {ex.Message}");
                        // You can choose to log this error or handle it as per your application's requirements
                    }
                }

                // Remove the staff record from the database
                _context.staffTables.Remove(delpro);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle case where staff with the provided Id is not found
                Console.WriteLine("Staff not found.");
                // You can throw an exception or log this case as per your application's requirements
            }
        }


    }
}

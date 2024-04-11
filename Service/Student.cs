using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Authentication.Data;
using Authentication.Data.Models;
using Authentication.Data.VModel;
using Microsoft.AspNetCore.Identity.Data;

namespace Authentication.Service
{
    public class Student
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataContext _context;
        private static readonly EmailAddressAttribute _emailAddressAttribute = new EmailAddressAttribute();

        public Student(UserManager<IdentityUser> userManager, DataContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterRequest registration, StudentVM studentVM, IFormFile imageFile)
        {
            if (registration == null || studentVM == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Registration or StudentVM is null." });
            }

            if (!string.IsNullOrEmpty(registration.Email) && !_emailAddressAttribute.IsValid(registration.Email))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid email format." });
            }

            var user = new IdentityUser { UserName = registration.Email, Email = registration.Email };
            var result = await _userManager.CreateAsync(user, registration.Password);
            try
            {
                if (result.Succeeded)
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                        var extension = Path.GetExtension(imageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student_image", fileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }
                        var userID = user.Id;
                        var students = new StudentTable()
                        {
                            UserId = userID,
                            Session_ID = studentVM.Session_ID,
                            Programe_ID = studentVM.Programe_ID,
                            Name = studentVM.Name,
                            FatherName = studentVM.FatherName,
                            DateofBirth = studentVM.DateofBirth,
                            Gender = studentVM.Gender,
                            ContactNo = studentVM.ContactNo,
                            PreviousSchool = studentVM.PreviousSchool,
                            ApplyDate = studentVM.ApplyDate,
                            PreviousPercentage = studentVM.PreviousPercentage,
                            Address = studentVM.Address,
                            Photo = imagePath
                        };

                        _context.studenttable.Add(students);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
            }

            return result;
        }


        //    public async Task<IdentityResult> UpdateStudentAsync(string userId, StudentVM studentVM, IFormFile imageFile)
        //    {
        //        if (string.IsNullOrEmpty(userId) || studentVM == null)
        //        {
        //            return IdentityResult.Failed(new IdentityError { Description = "UserId or StudentVM is null or empty." });
        //        }

        //        try
        //        {
        //            // Find the user by userId
        //            var user = await _userManager.FindByIdAsync(userId);
        //            if (user == null)
        //            {
        //                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        //            }

        //            // Update user using UserManager
        //            var userUpdateResult = await _userManager.UpdateAsync(user);
        //            if (!userUpdateResult.Succeeded)
        //            {
        //                return userUpdateResult;
        //            }

        //            // Update student information in the database
        //            var student = await _context.studenttable.FirstOrDefaultAsync(s => s.UserId == userId);
        //            if (student == null)
        //            {
        //                return IdentityResult.Failed(new IdentityError { Description = "Student information not found." });
        //            }

        //            if (imageFile != null && imageFile.Length > 0)
        //            {
        //                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
        //                var extension = Path.GetExtension(imageFile.FileName);
        //                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

        //                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student_image", fileName);
        //                using (var stream = new FileStream(imagePath, FileMode.Create))
        //                {
        //                    await imageFile.CopyToAsync(stream);
        //                }

        //                // Update the student's photo path
        //                student.Photo = imagePath;
        //            }

        //            // Update other student information
        //            student.Session_ID = studentVM.Session_ID;
        //            student.Programe_ID = studentVM.Programe_ID;
        //            student.Name = studentVM.Name;
        //            student.FatherName = studentVM.FatherName;
        //            student.DateofBirth = studentVM.DateofBirth;
        //            student.Gender = studentVM.Gender;
        //            student.ContactNo = studentVM.ContactNo;
        //            student.PreviousSchool = studentVM.PreviousSchool;
        //            student.ApplyDate = studentVM.ApplyDate;
        //            student.PreviousPercentage = studentVM.PreviousPercentage;
        //            student.Address = studentVM.Address;

        //            // Update student in the database
        //            _context.studenttable.Update(student);
        //            await _context.SaveChangesAsync();

        //            return IdentityResult.Success;
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log or handle the exception
        //            return IdentityResult.Failed(new IdentityError { Description = "An error occurred while updating student information." });
        //        }
        //    }
        //}
        //    }
        public async Task<IdentityResult> UpdateUserAsync(string userId, RegisterRequest registration, StudentVM studentVM, IFormFile imageFile)
        {
            if (registration == null || studentVM == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Registration or StudentVM is null." });
            }

            if (!string.IsNullOrEmpty(registration.Email) && !_emailAddressAttribute.IsValid(registration.Email))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid email format." });
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            try
            {
                if (!string.IsNullOrEmpty(registration.Email))
                {
                    user.Email = registration.Email;
                    user.UserName = registration.Email;
                }

                // Update user information
                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                {
                    return userUpdateResult;
                }

                // Update student information in the database
                var student = await _context.studenttable.FirstOrDefaultAsync(s => s.UserId == userId);
                if (student == null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Student information not found." });
                }

                // Update student information
                student.Session_ID = studentVM.Session_ID;
                student.Programe_ID = studentVM.Programe_ID;
                student.Name = studentVM.Name;
                student.FatherName = studentVM.FatherName;
                student.DateofBirth = studentVM.DateofBirth;
                student.Gender = studentVM.Gender;
                student.ContactNo = studentVM.ContactNo;
                student.PreviousSchool = studentVM.PreviousSchool;
                student.ApplyDate = studentVM.ApplyDate;
                student.PreviousPercentage = studentVM.PreviousPercentage;
                student.Address = studentVM.Address;

                // Update student photo if image file is provided
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    var extension = Path.GetExtension(imageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student_image", fileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Update student's photo path
                    student.Photo = imagePath;
                }

                _context.studenttable.Update(student);
                await _context.SaveChangesAsync();

                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return IdentityResult.Failed(new IdentityError { Description = "An error occurred while updating user information." });
            }
        }
        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            // Find the user by userId
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            try
            {
                // Remove the user using UserManager
                //var result = await _userManager.DeleteAsync(user);
                //if (!result.Succeeded)
                //{
                //    return result;
                //}

                // Remove the corresponding student record from the database
                var student = await _context.studenttable.FirstOrDefaultAsync(s => s.UserId == userId);
                if (student == null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Student information not found." });
                }

                // Remove the associated image file
                if (!string.IsNullOrEmpty(student.Photo))
                {
                    try
                    {
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student_image", student.Photo);
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception if file deletion fails
                        Console.WriteLine($"Error deleting image: {ex.Message}");
                        // You can choose to log this error or handle it as per your application's requirements
                    }
                }

                _context.studenttable.Remove(student);
                await _userManager.DeleteAsync(user);
                await _context.SaveChangesAsync();

                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return IdentityResult.Failed(new IdentityError { Description = "An error occurred while deleting the user." });
            }
        }
    }
}
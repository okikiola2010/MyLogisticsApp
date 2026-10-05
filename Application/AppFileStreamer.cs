using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public class AppFileStreamer(IWebHostEnvironment webHostEnvironment)
    {
        //public async Task<string?> FileStream(IFormFile File)
        //{
        //    string? profileString = null;
        //    if (File != null && File.Length > 0)
        //    {
        //        string uploadsFolder = Path.Combine(
        //            webHostEnvironment.WebRootPath,
        //            "profile-pictures");
        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }
        //        string fileExtension = Path.GetExtension(File.FileName);
        //        string fileName = $"{Guid.NewGuid()}{fileExtension}";
        //        string filePath = Path.Combine(uploadsFolder, fileName);
        //        using (FileStream streamer = new FileStream(filePath,FileMode.Create))
        //        {
        //            await File.CopyToAsync(streamer);
        //            profileString =$"/profile-pictures/{fileName}";
        //        }
        //    }
        //    return profileString;
        //}
        public async Task<string?> FileStreamApp(IFormFile File)
        {
            string? profileString = null;
            if (File != null && File.Length > 0)
            {
                string uploadsFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "profiles-pictures");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string fileExtension = Path.GetExtension(File.FileName);
                string fileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (FileStream streamer = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(streamer);

                    profileString = $"/profile-pictures/{fileName}";
                }
            }
            return profileString;
        }
    }
}

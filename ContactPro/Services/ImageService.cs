using ContactPro.Services.Interfaces;
using System.IO;

namespace ContactPro.Services
{
    public class ImageService : IImageService
    {

        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        private readonly string defaultImage = "img/DefaultContactImage.png";

        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return defaultImage;

            try
            {
                //making base 64 image, converts to string to pass to html tag
                string imageBase64Data = Convert.ToBase64String(fileData);
                return string.Format($"data:{extension};base64,{imageBase64Data}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                //create memory stream => take incomeing file copying to async => coverts to array then byte
                using MemoryStream memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                return byteFile;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}

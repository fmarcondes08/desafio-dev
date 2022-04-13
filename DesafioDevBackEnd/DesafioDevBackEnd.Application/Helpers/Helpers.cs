using Microsoft.AspNetCore.Http;
using System.IO;

namespace DesafioDevBackEnd.Application.Helpers
{
    public static class Helpers
    {
        public static byte[] ConvertToBytes(IFormFile image)
        {
            var reader = new BinaryReader(image.OpenReadStream());
            byte[] CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}

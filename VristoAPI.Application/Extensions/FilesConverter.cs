using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Application.Extensions
{
    public static class FilesConverter
    {

        public static async Task<byte[]> ToArrayOfBytes(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Copy the contents of the formFile to the memory stream
                await file.CopyToAsync(memoryStream);

                // Convert the memory stream to a byte array
                return memoryStream.ToArray();
            }
        }

    }
}

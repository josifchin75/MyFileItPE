using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileItPEService.Helpers
{
    public static class FileHelper
    {
        public static bool WriteBytesToFile(string path, Byte[] bytes)
        {
            var result = false;
            try
            {
                File.WriteAllBytes(path, bytes);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogError(ex);
            }
            return result;
        }

        public static string FileToBase64(string filePath)
        {
            byte[] byteArray = System.IO.File.ReadAllBytes(filePath);
            return Convert.ToBase64String(byteArray);
        }
    }
}

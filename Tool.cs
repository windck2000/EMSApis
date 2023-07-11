using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography;
using System.Text;

namespace EMSApi.Tool
{

    public static class Tool
    {
        public static async Task<string> Createmd5(string v)
        {
            using (var md5 = MD5.Create())
            {
             var result = await md5.ComputeHashAsync(new MemoryStream(Encoding.ASCII.GetBytes(v)));
             return  BitConverter.ToString(result).Replace("-","");
            }
        }
        public static void AddFile(List<IBrowserFile> browserFiles)
        {
            foreach (var item in browserFiles)
            {
                using (Stream stream = item.OpenReadStream())
                {
                    Stream stream1 = File.Create($"C:\\EMS\\{item.Name}");
                    CopyStream(stream, stream1);
                }
            }
        }

        public static void CopyStream(Stream stream, Stream stream1)
        {
            byte[] buffer = new byte[1024];
            int len;
            while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                stream1.Write(buffer, 0, len);
            }
        }

    }
}

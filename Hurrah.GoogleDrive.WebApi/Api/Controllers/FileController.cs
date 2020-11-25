using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Abp.WebApi.Controllers;

internal static class Extn
{
    public static TU Then<T, TU>(this T o, Func<T, TU> f)
    {
        return f(o);
    }
}

namespace Hurrah.GoogleDrive.Api.Controllers
{
    public class FileController : AbpApiController
    {
        [HttpPost]
        public async Task<dynamic> Upload()
        {
            try
            {
                MultipartFormDataStreamProvider stream = 
                    await 
                    HttpContext.Current.Server.MapPath("~/Temp/")
                    .Then(path => new MultipartFormDataStreamProvider(path))
                    .Then( provider => Request.Content.ReadAsMultipartAsync(provider, 209715200));

                string tempFile = stream.FileData.First().LocalFileName;
                string name = stream.FormData["name"];
                string destFolder = ConfigurationManager.AppSettings["ExcelFolder"];
                string destFile = Path.Combine(destFolder, name);
                
                Directory.CreateDirectory(destFolder);
                Retry.Retry.Do(
                    () => File.Copy(tempFile, destFile, true), 
                    TimeSpan.FromSeconds(1),
                    int.MaxValue
                );
                File.Delete(tempFile);
                
                return new
                {
                    Success = true,
                    FilePath = tempFile,
                    Destination = destFolder,
                    Name = name
                };
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                return new
                {
                    Success = false
                };
            }
        }
    }
}
using System;
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
        public async Task<dynamic> Test()
        {
            try
            {
                MultipartFormDataStreamProvider stream = 
                    await 
                    HttpContext.Current.Server.MapPath("~/Temp/")
                    .Then(path => new MultipartFormDataStreamProvider(path))
                    .Then( provider => Request.Content.ReadAsMultipartAsync(provider, 209715200));

                string filePath = stream.FileData.First().LocalFileName;
                
                return new
                {
                    Success = true,
                    FilePath = filePath
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
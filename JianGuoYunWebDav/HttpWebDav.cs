using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace JianGuoYunWebDav
{
    public class HttpWebDav
    {
        public string BaseUrl => "https://dav.jianguoyun.com/dav/";
        public string UserName => "用户名";
        public string Password => "密码";
        private HttpClient httpClient;
        public HttpWebDav()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = true;
            httpClientHandler.Proxy = new WebProxy();
            httpClientHandler.Credentials = new NetworkCredential(this.UserName, this.Password, "Domain");
            httpClientHandler.PreAuthenticate = true;
            this.httpClient = new HttpClient(httpClientHandler);
        }
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public async Task<byte[]> GetBytes(string fileName)
        {
            string url = $"{this.BaseUrl}{fileName}";
            return  await this.httpClient.GetByteArrayAsync(url);
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderName"></param>
        public async Task<bool> MakeFolder(string folderName)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = new HttpMethod("MKCOL");
            httpRequestMessage.RequestUri = new Uri($"{this.BaseUrl}{folderName}");
            HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(httpRequestMessage);
            return httpResponseMessage.IsSuccessStatusCode;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deleteFile"></param>
        public async Task<bool> Delete(string deleteFile)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Delete;
            httpRequestMessage.RequestUri = new Uri($"{this.BaseUrl}{deleteFile}");
            HttpResponseMessage httpResponseMessage = await this.httpClient.SendAsync(httpRequestMessage);
            return httpResponseMessage.IsSuccessStatusCode;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<bool> Upload(string fileName, byte[] bys)
        {
            string url = $"{this.BaseUrl}{fileName}";
            ByteArrayContent byteArrayContent = new ByteArrayContent(bys);
            HttpResponseMessage httpResponseMessage = await this.httpClient.PutAsync(url, byteArrayContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}

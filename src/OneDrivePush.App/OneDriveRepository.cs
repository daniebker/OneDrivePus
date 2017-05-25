using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDrivePush.App
{
    public class OneDriveRepository
    {
        private IHttpHandler _httpHandler;

        public OneDriveRepository(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<IEnumerable<Drive>> GetDrives()
        {
            string response = await _httpHandler.GetAsync("/me/drives");
            return JsonConvert.DeserializeObject<ResponseValue>(response).Value;            
        }
    }
}

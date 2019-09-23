using System;
using Microsoft.AspNetCore.Mvc;
using ZipToInfo.Data;
using ZipToInfo.Models;

namespace ZipToInfo.Services.Controllers
{
    [Route("api/[controller]")]
    public class ZipInfoController : Controller
    {
        private readonly IDataService _dataService;
        
        public ZipInfoController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET api/zip/97123
        [HttpGet]
        [Route("{zip}")]
        public string Get(string zip)
        {
            AssertZip(zip);

            var zipInfo = _dataService.GetInfoForZip(zip);
            return zipInfo.ToString();
        }

        // GET api/zip/97123/json
        [HttpGet]
        [Route("{zip}/json")] // TODO: I think it's more restful to have "json" in a querystring, not a route parameter, may revisit this...
        public ZipInfo GetJson(string zip, string json)
        {
            AssertZip(zip);

            var zipInfo = _dataService.GetInfoForZip(zip);
            return zipInfo;
        }

        private void AssertZip(string zip)
        {
            // Philosophical discussion(s) here... 
            // Everyone (hopefully) knows that validation needs to be run on the server as well as the client.
            // 1.) There are some passive mechanisms for inspecting input, and those may be useful, in this case, 
            // I used an explicit "Assert" method, as those passive mechanisms may be limited.
            // In this case, I'm certain a passive mechanism would work, because the validation is simple, 
            // but, when required to have some more complicated controls, customization is the way to go.
            // 2.) It may also be useful to push validation to a middle tier, so that shared data access can
            // benefit from one location for validation.
            // 3.) Other discussions?
            if (string.IsNullOrEmpty(zip))
            {
                throw new ArgumentNullException("zip", "Zip code cannot be null");
            }
            
            if (zip.Length < 5 || zip.Length > 10)
            {
                throw new ArgumentOutOfRangeException("zip", "Zip code appears to be invalid");
            }
        }
    }
}

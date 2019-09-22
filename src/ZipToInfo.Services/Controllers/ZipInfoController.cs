﻿using Microsoft.AspNetCore.Mvc;
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
            var zipInfo = _dataService.GetInfoForZip(zip);
            return zipInfo.ToString();
        }

        // GET api/zip/97123/json
        [HttpGet]
        [Route("{zip}/json")] // TODO: I think it's more restful to have "json" in a querystring, not a route parameter, may revisit this...
        public ZipInfo GetJson(string zip, string json)
        {
            var zipInfo = _dataService.GetInfoForZip(zip);
            return zipInfo;
        }
    }
}

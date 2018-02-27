using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StellerAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnvironmentsController: Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] string env) 
        {
            
        }
    }
}
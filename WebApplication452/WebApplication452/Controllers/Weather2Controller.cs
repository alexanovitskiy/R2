using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenWeather;

namespace WebApplication452.Controllers
{
    public class Weather2Controller : ApiController
    {
        // GET: api/Weather2
        public string Get()
        {
            IWeatherData wd = new OpenWeatherData();
            string error = string.Empty;
            var data = wd.GetWeatherData(out error);
            if (data != null )return data.main.temp.ToString();
            return error;
        }

        // GET: api/Weather2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Weather2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Weather2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather2/5
        public void Delete(int id)
        {
        }
    }
}

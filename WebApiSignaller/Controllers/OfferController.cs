using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSignaller.Helper;

namespace WebApiSignaller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        public OfferController()
        {
            if (!System.IO.File.Exists("mercedes.txt"))
            {
                FileHelper.Write("mercedes", 5000);
            }
            if (!System.IO.File.Exists("chevrolet.txt"))
            {
                FileHelper.Write("chevrolet", 3575);
            }
        }
        // GET: api/<OfferController>
        [HttpGet]
        public double Get()
        {
            return FileHelper.Read();
        }

        [HttpGet("/Room")]
        public double Get(string room)
        {
            return FileHelper.Read(room);
        }

        // GET: api/<OfferController>
        [HttpGet("/Increase")]
        public void Increase(double data)
        {
            var result = FileHelper.Read()+data;
            FileHelper.Write(result);
        }

        // GET: api/<OfferController>
        [HttpGet("/IncreaseRoom")]
        public void Increase(string room, double number)
        {
            var result = FileHelper.Read(room) + number;
            FileHelper.Write(room, result);
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OfferController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

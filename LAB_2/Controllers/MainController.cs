using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace LAB_2.Controllers
{
    public class MainController : ApiController
    {
        private static int _result = 0;
        private static readonly Stack<int> _stack = new Stack<int>();


        [HttpGet]
        public IHttpActionResult Get()
        {
            int result = (_stack.Count > 0) ? (_result + _stack.Peek()) : _result;
            return Ok(new { result });
        }

        [HttpPost]
        public IHttpActionResult Post([FromUri] string result)
        {
            if (!int.TryParse(result, out int resultParameter))
                return BadRequest("Enter integer parameter.");
            _result = resultParameter;
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri] string add)
        {
            if (!int.TryParse(add, out int addParameter))
                return BadRequest("Enter integer parameter.");
            _stack.Push(addParameter);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {
            if (_stack.Count <= 0)
                return BadRequest("Enter integer parameter.");
            _stack.Pop();
            return Ok();
        }
    }
}

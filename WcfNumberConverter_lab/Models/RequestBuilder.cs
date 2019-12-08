using System;
using System.Linq;

namespace WcfNumberConverter_lab.Models
{
    public class RequestBuilder
    {
        private Request request;

        public RequestBuilder()
        {
            request = new Request();
        }

        public RequestBuilder SetUpGuid()
        {
            request.Id = Guid.NewGuid();
            return this;
        }

        public RequestBuilder SetUpTime()
        {
            request.Time = DateTime.Now;
            return this;
        }

        public RequestBuilder SetTime(DateTime time)
        {
            request.Time = time;
            return this;
        }

        public RequestBuilder ArabNumber(int arabNumber)
        {
            request.ArabNumber = arabNumber;
            return this;
        }

        public RequestBuilder RomanNumber(string romanNumber)
        {
            request.RomanNumber = romanNumber;
            return this;
        }

        public Request create()
        {
            return request;
        }
    }
}
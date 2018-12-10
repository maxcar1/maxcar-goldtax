using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maxcar_goldtax.utils;
using Newtonsoft.Json.Linq;

namespace maxcar_goldtax.entity
{
    public class Response
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public JObject Data { get; set; }

        public Response() {
            Code = 200;
            Message = "Success";
            Data = null;
        }

        public Response getDefultError() {
            this.Code = Constant.ERROR;
            this.Message = "服务器异常";
            return this;
        }
    }
}

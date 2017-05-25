using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Codes
    {
        public Result recievedCode;

        public Result GetCode(string code)
        {
            switch (code)
            {
                case "200":
                    recievedCode = new Result() { Overrall = Status.Success, Code = "18.5", Message = "Fair" };
                    return recievedCode;
                case "201":
                    recievedCode = new Result() { Overrall = Status.Success, Code = "17.5", Message = "Fair" };
                    return recievedCode;
                case "202":
                    recievedCode = new Result() { Overrall = Status.Success, Code = "202", Message = "Acepted" };
                    return recievedCode;
                case "400":
                    recievedCode = new Result() { Overrall = Status.Fail, Code = "400", Message = "Error(Client)" };
                    return recievedCode;
                case "500":
                    recievedCode = new Result() { Overrall = Status.Fail, Code = "13.2", Message = "asdasd" };
                    return recievedCode;
                case "700":
                    recievedCode = new Result() { Overrall = Status.Unknown, Code = "700", Message = "Unknown" };
                    return recievedCode;
                default:
                    recievedCode = new Result() { Overrall = Status.Unknown, Code = code , Message = "Unknown" };
                    return recievedCode;
            }
        }

    }
}

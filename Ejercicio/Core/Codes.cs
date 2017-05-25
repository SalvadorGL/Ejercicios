/// <summary>
/// 
/// </summary>
namespace Core
{
    /// <summary>
    /// Codes Catalog
    /// </summary>
    public class Codes
    {
        private Result recievedCode;

        public Result GetCode(string code)
        {
            switch (code)
            {
                case "200":
                    this.recievedCode = new Result() { Overrall = Status.Success, Code = "18.5", Message = "Fair" };
                    return this.recievedCode;
                case "201":
                    this.recievedCode = new Result() { Overrall = Status.Success, Code = "17.5", Message = "Fair" };
                    return this.recievedCode;
                case "202":
                    this.recievedCode = new Result() { Overrall = Status.Success, Code = "202", Message = "Acepted" };
                    return this.recievedCode;
                case "400":
                    this.recievedCode = new Result() { Overrall = Status.Fail, Code = "400", Message = "Error(Client)" };
                    return this.recievedCode;
                case "500":
                    this.recievedCode = new Result() { Overrall = Status.Fail, Code = "13.2", Message = "asdasd" };
                    return this.recievedCode;
                case "700":
                    this.recievedCode = new Result() { Overrall = Status.Unknown, Code = "700", Message = "Unknown" };
                    return this.recievedCode;
                default:
                    this.recievedCode = new Result() { Overrall = Status.Unknown, Code = code, Message = "Unknown" };
                    return this.recievedCode;
            }
        }
    }
}

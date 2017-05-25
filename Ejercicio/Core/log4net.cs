using log4net;

namespace Core
{
    public static class Log4net
    {
        public static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}

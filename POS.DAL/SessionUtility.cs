using System;
using System.Web;

namespace POS.DAL
{
    [Serializable()]
    public class SessionUtility
    {
        private const string SESSION_KEY_PREFIX = "__DM__";
        public static SessionContainer POSSessionContainer
        {
            set
            {
                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"] = value;
                }
            }
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"] != null)
                    {
                        return (SessionContainer)HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"];
                    }
                    else
                    {
                        return new SessionContainer();
                    }
                }
                else
                    return new SessionContainer();
            }
        }
    }
}

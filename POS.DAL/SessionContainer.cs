﻿using System;

namespace POS.DAL
{
    [Serializable()]
    public class SessionContainer
    {
        public SessionContainer()
        {
            SessionUtility.POSSessionContainer = this;
        }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public object OBJ_CLASS { get; set; }
        public object OBJ_DOC_CLASS { get; set; }
        public object OBJ_Menu_CLASS { get; set; }
        public object OBJ_RPTDOC { get; set; }
        public string ErrorMsg { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTime SystemDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBComputadora.Model.Utils.Messages
{
    public class ApplicationMessage
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public AlertMessageType Type { get; set; }
        public bool IsInfo => (Type == AlertMessageType.Info) ? true : false;
        public bool IsWarning => (Type == AlertMessageType.Warning) ? true : false;
        public bool IsSuccess => (Type == AlertMessageType.Success) ? true : false;
        public bool IsError => (Type == AlertMessageType.Error) ? true : false;

        public void SetInfoMessage(string message)
        {
            SetMessage(message, AlertMessageType.Info);
        }
        public void SetWarningMessage(string message)
        {
            SetMessage(message, AlertMessageType.Warning);
        }
        public void SetSuccessMessage(string message)
        {
            SetMessage(message, AlertMessageType.Success);
        }
        public void SetErrorMessage(string message)
        {
            SetMessage(message, AlertMessageType.Error);
        }
        
        public void SetMessage(string message, AlertMessageType type)
        {
            Description = message;
            Type = type;
        }
    }
    public enum AlertMessageType
    {
        Info,
        Warning,
        Error,
        Success
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.Services
{
    public interface IIcPageHeaderSearchService
    {
        string Controller { get; }
        string Action { get; }
        string Placeholder { get; }
        bool Configured { get; }
        void Configure(string controller, string action, string placeholder);
    }

    public class IcPageHeaderSearchService : IIcPageHeaderSearchService
    {
        public string Controller { get; private set; }
        public string Action { get; private set; }
        public string Placeholder { get; private set; }
        public bool Configured { get; private set; }

        public void Configure(string controller, string action, string placeholder)
        {
            Controller = controller;
            Action = action;
            Placeholder = placeholder;
            Configured = true;
        }
    }
}

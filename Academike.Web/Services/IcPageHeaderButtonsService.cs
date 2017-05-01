using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.Services
{
    public interface IIcPageHeaderButtonsService
    {
        List<ButtonMetadata> Buttons { get; }
        ButtonMetadata Add(ButtonMetadata buttonMetadata);
        ButtonMetadata Add(string title, Dictionary<string, object> customAttributes);
        ButtonMetadata Add(string title, string controller, string action, Dictionary<string, object> customAttributes);
    }

    public class IcPageHeaderButtonsService : IIcPageHeaderButtonsService
    {
        public List<ButtonMetadata> Buttons { get; private set; } = new List<ButtonMetadata>();

        public ButtonMetadata Add(
            string title,
            Dictionary<string, object> customAttributes = null)
        {
            var result = new ButtonMetadata(title);
            result.AddCustomAttributes(customAttributes);

            Buttons.Add(result);

            return result;
        }

        public ButtonMetadata Add(
            string title, string controller, string action,
            Dictionary<string, object> customAttributes = null)
        {
            var result = new ButtonMetadata(title, controller, action);
            result.AddCustomAttributes(customAttributes);

            Buttons.Add(result);

            return result;
        }

        public ButtonMetadata Add(ButtonMetadata buttonMetadata)
        {
            Buttons.Add(buttonMetadata);

            return buttonMetadata;
        }
    }

    public class ButtonMetadata
    {
        public string Icon { get; set; }
        public string Title { get; protected set; }
        public string Controller { get; protected set; }
        public string Action { get; protected set; }
        public string Class { get; set; }
        private Dictionary<string, object> _customAttributes { get; set; } = new Dictionary<string, object>();
        public string CustomAttributes
        {
            get
            {
                var result = string.Empty;

                foreach (var cAttr in _customAttributes)
                {
                    result += string.Format("{0} = {1} ", cAttr.Key, cAttr.Value);
                }

                return result;
            }
        }

        private readonly string _defaultClass = "btn btn-primary btn-block";

        public ButtonMetadata(string title)
        {
            Title = title;
            Class = _defaultClass;
        }

        public ButtonMetadata(string title, string controller, string action)
            : this(title)
        {
            Class = _defaultClass;
        }

        public void AddCustomAttribute(string key, object value)
        {
            _customAttributes.Add(key, value);
        }

        public void AddCustomAttributes(IDictionary<string, object> customAttributes)
        {
            if (customAttributes != null)
            {
                foreach (var cAttr in customAttributes)
                {
                    AddCustomAttribute(cAttr.Key, cAttr.Value);
                }
            }
        }
    }
}

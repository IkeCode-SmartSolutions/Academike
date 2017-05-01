using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.Services
{
    public interface IIcBreadcrumbService
    {
        List<BreadcrumbMetadata> Levels { get; }
        void Add(string node);
        void Add(string node, string controller, string action);
    }

    public class IcBreadcrumbService : IIcBreadcrumbService
    {
        public List<BreadcrumbMetadata> Levels { get; set; } = new List<BreadcrumbMetadata>();

        public void Add(string node)
        {
            Levels.Add(new BreadcrumbMetadata
            {
                Label = node
            });
        }

        public void Add(string node, string controller, string action)
        {
            Levels.Add(new BreadcrumbMetadata
            {
                Label = node,
                Controller = controller,
                Action = action
            });
        }
    }

    public class BreadcrumbMetadata
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Label { get; set; }
    }
}

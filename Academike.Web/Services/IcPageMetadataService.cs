using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.Services
{
    public interface IIcPageMetadataService
    {
        string Icon { get; }
        string Title { get; }
        string[] Keywords { get; }

        void AddTitle(string title);
        void AddTitle(string icon, string title);
        void AddKeyWords(params string[] keywords);
    }

    public class IcPageMetadataService : IIcPageMetadataService
    {
        public string Icon { get; private set; }
        public string Title { get; private set; }
        public string[] Keywords { get; private set; }

        public void AddKeyWords(params string[] keywords)
        {
            Keywords = keywords;
        }

        public void AddTitle(string title)
        {
            Title = title;
            Icon = "ion-cube";
        }

        public void AddTitle(string icon, string title)
        {
            AddTitle(title);
            Icon = icon;
        }
    }
}

namespace Review.WebApp.Global.Nav.Model
{
    public class PageTabItem
    {
        public string Name
        {
            get;
        }

        public string Url
        {
            get;
        }

        public string Icon
        {
            get;
        }

        public bool Closable
        {
            get;
        } = true;


        internal bool IsOpened
        {
            get;
            set;
        }

        internal DateTime OpenedTime
        {
            get;
            set;
        }

        public PageTabItem(string name, string url)
        {
            Name = (name ?? throw new ArgumentNullException("name"));
            Url = (url ?? throw new ArgumentNullException("url"));
        }

        public PageTabItem(string name, string url, string icon)
            : this(name, url)
        {
            Icon = (icon ?? throw new ArgumentNullException("icon"));
        }

        public PageTabItem(string name, string url, string icon, bool closable)
            : this(name, url, icon)
        {
            Closable = closable;
        }
    }
}

namespace GameUI
{
    public class UIType
    {
        public int panelId { get; private set; }
        public string Path { get; private set; }

        public string Name { get; private set; }

        public UIType(string path, int id)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/') + 1);
            panelId = id;
        }

        public override string ToString()
        {
            return string.Format("path : {0} name : {1}", Path, Name);
        }
      
    }
}

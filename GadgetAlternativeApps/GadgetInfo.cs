namespace GadgetAlternativeApps
{
    public struct GadgetInfo
    {
        public struct ImgInfo
        {
            public string src;
            public float height;
            public float width;
        }
        public struct AutherInfo
        {
            public string name;
            public string infoUrl;
            public ImgInfo logoIcon;
        }

        public string rootDir;

        public string name;
        public string version;
        public AutherInfo autherInfo;
        public ImgInfo icon;
        public string htmlPath;
        public ImgInfo defaultImg;
        public string licence;
        public string description;

        public bool isActived;
        public int X;
        public int Y;
    }
}

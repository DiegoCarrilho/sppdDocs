using SppdDocs.Core.Domain.Interfaces;

namespace SppdDocs.Core.Domain.Objects
{
    public class LocalizedText : ILocalized<string>
    {
        protected LocalizedText()
        {
        }

        public LocalizedText(string en, string de = null, string fr = null, string it = null, string ja = null, string ko = null, string ru = null, string es = null,
            string zh = null, string pt = null, string tr = null, string pl = null)
        {
            En = en;
            Fr = fr;
            De = de;
            It = it;
            Ja = ja;
            Ko = ko;
            Ru = ru;
            Es = es;
            Zh = zh;
            Pt = pt;
            Tr = tr;
            Pl = pl;
        }

        public string En { get; set; }

        public string Fr { get; set; }

        public string De { get; set; }

        public string It { get; set; }

        public string Ja { get; set; }

        public string Ko { get; set; }

        public string Ru { get; set; }

        public string Es { get; set; }

        public string Zh { get; set; }

        public string Pt { get; set; }

        public string Tr { get; set; }

        public string Pl { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lBook
{
    public class Localization
    {
        private static Localization instance;
        public ComboBox Langs;
        public static Localization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Localization();
                }

                return instance;
            }
        }
        public void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            foreach (ComboBoxItem i in Langs.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsSelected = ci != null && ci.Equals(currLang);
            }
        }

        public void ChangeLanguageClick(Object sender, EventArgs e)
        {
            ComboBoxItem mi = sender as ComboBoxItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }
    }
}

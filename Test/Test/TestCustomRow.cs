using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public enum Title
    {
        King,
        Sir
    };

    public class Knight
    {
        private string hisName;
        private bool good;
        private Title hisTitle;

        public Knight(Title title, string name, bool good, Image img)
        {
            hisTitle = title;
            hisName = name;
            this.good = good;
            this.Avt = img;
        }

        public Knight()
        {
            hisTitle = Title.Sir;
            hisName = "<enter name>";
            good = true;
        }

        public string Name
        {
            get
            {
                return hisName;
            }

            set
            {
                hisName = value;
            }
        }

        public bool GoodGuy
        {
            get
            {
                return good;
            }
            set
            {
                good = value;
            }
        }

        public Title Title
        {
            get
            {
                return hisTitle;
            }
            set
            {
                hisTitle = value;
            }
        }
        private Image hisAvt;
        public Image Avt
        {
            set
            {
                hisAvt = value;
            }
            get
            {
                return hisAvt;
            }
        }

    }
    class TestCustomRow
    {
    }
}

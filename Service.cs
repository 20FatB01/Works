using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Works
{
    public class Service
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Cost { get; private set; }
        public DateTime Time { get; private set; }
        public BitmapImage Image { get; private set; }
        public float Sale { get; private set; }
    }
}

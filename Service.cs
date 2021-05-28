using System.Drawing;
namespace Works
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public int Time { get; set; }
        public string ImagePath { get; set; }
        public float Sale { get; set; }
        public string Description { get; set; }

        public Service()
        {
            Description = "";
        }

        public override string ToString()
        {
            return $"('{Title}', {Cost}, {Time}, '{Description}', {$"{Sale}".Replace(',','.')}, '{ImagePath}')";
        }
    }
}

namespace FirstWebApi.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size= 10},
            new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Red", Gender = "Men", Price = 25, Size= 9},
            new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Green", Gender = "Women", Price = 130, Size= 10},
            new Shirt { ShirtId = 4, Brand = "Your Brand", Color = "Yellow", Gender = "Women", Price = 35, Size= 11}
        };

        public static List<Shirt> GetShirts(){
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtsbyID(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
        
    }
}
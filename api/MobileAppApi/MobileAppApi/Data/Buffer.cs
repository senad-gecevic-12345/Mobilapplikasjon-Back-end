using MobileAppApi.Models;
namespace MobileAppApi.Data
{
    public class CoffeeBuffer
    {
        private static CoffeeBuffer instance = null;
        private static readonly object padlock = new object();
        private List<Coffee>? coffee_list;

        private bool coffee_init = false;
        private bool get_init()
        {
            return coffee_init;
        }
        private void set_list(List<Coffee>list)
        {
            coffee_list = list;
            coffee_init = true;
        }
        public List<Coffee> get_coffee_list()
        {
            if (!get_init())
            {
                string json_file = json_coffee_list_location.json_coffee_list;
                set_list(JsonParser<Coffee>.parse_json(json_file));
            }
            return coffee_list;
        }
        public static CoffeeBuffer Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new CoffeeBuffer();
                    }
                    return instance;
                }
            }
        }
    }
}

using MobileAppApi.Controllers;
using Xunit;
using MobileAppApi.Data;
using MobileAppApi.Models;
using System.Text.RegularExpressions;
using MobileAppApi.Requests.CoffeeRequest;
using MobileAppApi.Data.CoffeeHandler;

namespace MobileAppApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void json_to_model_list_to_json_compare()
        {
            string json_file = json_coffee_list_location.json_coffee_list;
            List <Coffee> list = JsonParser<Coffee>.parse_json(json_file);
            string reconvert_json = JsonParser<Coffee>.model_list_to_json(list);
            string json = File.ReadAllText(json_file);
            string one = Regex.Replace(reconvert_json, @"\s+", "");
            string two = Regex.Replace(json, @"\s+", "");
            Assert.Equal(one, two);

        }

        [Fact]
        public async void coffee_list_size(){
            GetCoffeeListRequest request = new GetCoffeeListRequest();
            GetCoffeeListHandler handler = new GetCoffeeListHandler();
            var res = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.Equal(85, res.Count());
        }

        [Fact]
        public async void coffee_search(){
            GetCoffeeIdRequest request = new GetCoffeeIdRequest(405);
            GetCoffeeIdHandler handler = new GetCoffeeIdHandler();
            var res = await handler.Handle(request, new System.Threading.CancellationToken());
            string[] sizes = { "Short", "Tall", "Grande", "Venti" };   
            bool assert =
                ("Caffè Americano" == res.name) &&
                ("Hot" == res.formCode) &&
                ("https://globalassets.starbucks.com/assets/83490c466e6d48bf8d1151bf7f14b187.jpg" == res.assets.thumbnail.large.uri) &&
                ("https://globalassets.starbucks.com/assets/0f1fb4ec32324da88d7135470269a9f1.jpg" == res.assets.fullSize.uri) &&
                ("https://globalassets.starbucks.com/assets/f12bc8af498d45ed92c5d6f1dac64062.jpg" == res.assets.masterImage.uri) &&
                (405 == res.id) &&
                ("Americanos" == res.category);

            bool size_assert = sizes.Length == res.sizes.Count();
            for(int i = 0; i < sizes.Length && size_assert; ++i)
            {
                bool has = false;
                for(int j = 0; j < res.sizes.Count(); ++j)
                {
                    if (sizes[i] == res.sizes[j])
                    {
                        has = true;
                        break;
                    }
                }
                if (!has)
                    size_assert = false;
            }
            Assert.True(assert && size_assert);
        }
    }
}

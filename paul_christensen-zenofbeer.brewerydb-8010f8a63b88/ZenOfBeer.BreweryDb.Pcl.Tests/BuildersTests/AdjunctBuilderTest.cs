using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using ZenOfBeer.BreweryDb.Pcl.Builders;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ZenOfBeer.BreweryDb.Pcl.Tests.BuildersTests
{
    public class AdjunctBuilderTest
    {
        [Fact]
        public void ValidateAdjunctBuilderTest()
        {
            var expected = new
            {
                id = 1,
                name = "my adjunct",
                description = "my description",
                category = "my category string",
                categoryDisplay = "my category display"
            };

            var jString = JsonConvert.SerializeObject(expected);

            var builder = new AdjunctBuilder();

            builder.Init();
            builder.SetResultData(JToken.Parse(jString));
            var actual = (IAdjunct)builder.Build();
            Assert.Equal(expected.id.ToString(), actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.category, actual.Category);
            Assert.Equal(expected.categoryDisplay, actual.CategoryDisplay);
        }
    }
}
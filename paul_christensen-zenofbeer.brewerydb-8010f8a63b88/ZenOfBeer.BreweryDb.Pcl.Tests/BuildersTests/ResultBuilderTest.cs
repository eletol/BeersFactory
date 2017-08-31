using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using ZenOfBeer.BreweryDb.Pcl.Builders;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ZenOfBeer.BreweryDb.Pcl.Tests.BuildersTests
{
    public class ResultBuilderTest
    {
        [Fact]
        public void BuildBeerTest()
        {
            //ToDo: complete testing the build out of the child objects
            var expected = new
            {
                id = "abcde4",
                name = "parent beer",
                description = "parent description",
                foodPairings = "parent food pairings",
                originalGravity = "og",
                abv = "abv",
                ibu = "ibu",
                glasswareId = "glasswareId",
                glass = new
                {
                    id = "glass id",
                    name = "glass name",
                    description = "glass description"
                },
                style = new
                {
                    id = "786",
                    name = "style name",
                    description = "style description",
                    categoryId = "category id",
                    category = new
                    {
                        id = "category id actual",
                        name = "category name",
                        description = "description of this child object"
                    },
                    ibuMin = "min ibu",
                    ibuMax = "max ibu",
                    abvMin = "min abv",
                    abvMax = "max abv",
                    srmMin = "min srm",
                    srmMax = "max srm",
                    ogMin = "min og",
                    ogMax = "max og",
                    fgMin = "min fg",
                    fgMax = "max fg"
                },
                styleId = "styleId",
                isOrganic = "True",
                labels = new
                {
                    id = "1",
                    name = "label",
                    description = "label description",
                    icon = "http://www.MyIconurl.jpg",
                    medium = "https://www.myMediumIcon.net",
                    large = "http://www.myLargeIcon.net/?id=someId"
                },
                available = new
                {
                    id = "available id",
                    name = "available name",
                    description = "available description"
                },
                beerVariation = new
                {
                    id = "abcde4",
                    name = "parent beer",
                    description = "parent description",
                    foodPairings = "parent food pairings",
                    originalGravity = "og",
                    abv = "abv",
                    ibu = "ibu",
                    glasswareId = "glasswareId",
                    glass = new
                    {
                        id = "glass id",
                        name = "glass name",
                        description = "glass description"
                    },
                    style = new
                    {
                        id = "786",
                        name = "style name",
                        description = "style description",
                        categoryId = "category id",
                        category = new
                        {
                            id = "category id actual",
                            name = "category name",
                            description = "description of this child object"
                        },
                        ibuMin = "min ibu",
                        ibuMax = "max ibu",
                        abvMin = "min abv",
                        abvMax = "max abv",
                        srmMin = "min srm",
                        srmMax = "max srm",
                        ogMin = "min og",
                        ogMax = "max og",
                        fgMin = "min fg",
                        fgMax = "max fg"
                    },
                    styleId = "styleId",
                    isOrganic = "True",
                    labels = new
                    {
                        id = "1",
                        name = "label",
                        description = "label description",
                        icon = "http://www.MyIconurl.jpg",
                        medium = "https://www.myMediumIcon.net",
                        large = "http://www.myLargeIcon.net/?id=someId"
                    },
                    available = new
                    {
                        id = "available id",
                        name = "available name",
                        description = "available description"
                    },
                    servingTemperature = "srvTmp",
                    servingTemperatureDisplay = "srvTmpDisp",
                    status = "status",
                    statusDisplay = "statusDisp",
                    availableId = "avail id",
                    beerVariationId = "id of the variation",
                    year = "1984"                    
                },
                servingTemperature = "srvTmp",
                servingTemperatureDisplay = "srvTmpDisp",
                status = "status",
                statusDisplay = "statusDisp",
                availableId = "avail id",
                beerVariationId = "id of the variation",
                year = "1984"
            };

            var jString = JsonConvert.SerializeObject(expected);
            var builder = new ResultBuilder();
            builder.Init();
            builder.SetResultData(JToken.Parse(jString));
            var actual = (IBeer)builder.Build();

            Assert.Equal(expected.id, actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.foodPairings, actual.FoodPairings);
            Assert.Equal(expected.originalGravity, actual.OriginalGravity);
            Assert.Equal(expected.abv, actual.Abv);
            Assert.Equal(expected.ibu, actual.Ibu);
            Assert.Equal(expected.glasswareId, actual.GlasswareId);
            Assert.Equal(expected.styleId, actual.StyleId);
            Assert.Equal(expected.isOrganic, actual.IsOrganic.ToString());
            Assert.Equal(expected.servingTemperature, actual.ServingTemperature);
            Assert.Equal(expected.servingTemperatureDisplay, actual.ServingTemperatureDisplay);
            Assert.Equal(expected.status, actual.Status);
            Assert.Equal(expected.statusDisplay, actual.StatusDisplay);
            Assert.Equal(expected.availableId, actual.AvailableId);
            Assert.Equal(expected.beerVariationId, actual.BeerVariationId);
            Assert.Equal(expected.year, actual.Year);
            Assert.Equal(expected.glass.id, actual.Glass.Id);
        }

        [Fact]
        public void BuildLabelsTest()
        {
            var expected = new
            {
                id = "1",
                name = "label",
                description = "label description",
                icon = "http://www.MyIconurl.jpg",
                medium = "https://www.myMediumIcon.net",
                large = "http://www.myLargeIcon.net/?id=someId"
            };

            var jString = JsonConvert.SerializeObject(expected);
            var builder = new ResultBuilder();
            builder.Init();
            builder.SetResultData(JToken.Parse(jString));
            var actual = (ILabels)builder.Build();
            Assert.Equal(expected.id, actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.icon, actual.Icon);
            Assert.Equal(expected.medium, actual.Medium);
            Assert.Equal(expected.large, actual.Large);
        }

        [Fact]
        public void BuildStyleTest()
        {
            var expected = new
            {
                id = "786",
                name = "style name",
                description = "style description",
                categoryId = "category id",
                category = new
                {
                    id = "category id actual",
                    name = "category name",
                    description = "description of this child object"
                },
                ibuMin = "min ibu",
                ibuMax = "max ibu",
                abvMin = "min abv",
                abvMax = "max abv",
                srmMin = "min srm",
                srmMax = "max srm",
                ogMin = "min og",
                ogMax = "max og",
                fgMin = "min fg",
                fgMax = "max fg"
            };

            var jString = JsonConvert.SerializeObject(expected);
            var builder = new ResultBuilder();
            builder.Init();
            builder.SetResultData(JToken.Parse(jString));
            var actual = (IStyle)builder.Build();

            Assert.Equal(expected.id, actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.categoryId, actual.CategoryId);
            Assert.Equal(expected.category.id, actual.Category.Id);
            Assert.Equal(expected.category.name, actual.Category.Name);
            Assert.Equal(expected.category.description, actual.Category.Description);
            Assert.Equal(expected.ibuMin, actual.IbuMin);
            Assert.Equal(expected.ibuMax, actual.IbuMax);
            Assert.Equal(expected.abvMin, expected.abvMin);
            Assert.Equal(expected.abvMax, actual.AbvMax);
            Assert.Equal(expected.srmMin, actual.SrmMin);
            Assert.Equal(expected.srmMax, actual.SrmMax);
            Assert.Equal(expected.ogMin, actual.OgMin);
            Assert.Equal(expected.ogMax, actual.OgMax);
            Assert.Equal(expected.fgMin, actual.FgMin);
            Assert.Equal(expected.fgMax, actual.FgMax);
        }

        [Fact]
        public void BuildImagesTest()
        {
            var expected = new
            {
                id = "1",
                name = "image",
                description = "image description",
                icon = "http://www.MyImageurl.jpg",
                medium = "http://www.myMediumImage.jpg",
                large = "https://www.myLargeImage.net/?id=someId"
            };

            var jString = JsonConvert.SerializeObject(expected);
            var builder = new ResultBuilder();
            builder.Init();
            builder.SetResultData(JToken.Parse(jString));

            var actual = (ILabels) builder.Build();
            Assert.Equal(expected.id, actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.icon, actual.Icon);
            Assert.Equal(expected.medium, actual.Medium);
            Assert.Equal(expected.large, actual.Large);
        }

        [Fact]
        public void BuildBreweryTest()
        {
            var expected = new
            {
                id = "469d",
                name = "my brewery",
                description = "my brewery description",
                website = "my website",
                established = "2013",
                mailingListUrl = "my mailinglist url",
                isOrganic = "true",
                images = new
                {
                    id = "2",
                    name = "my image",
                    description = "my image description",
                    icon = "http://www.MyImageurl.jpg",
                    medium = "http://www.myMediumImage.jpg",
                    large = "https://www.myLargeImage.net.jpg"
                }
            };

            var jString = JsonConvert.SerializeObject(expected);
            var builder = new ResultBuilder();
            builder.Init();
            builder.SetResultData(JToken.Parse(jString));

            var actual = (IBrewery) builder.Build();
            Assert.Equal(expected.id, actual.Id);
            Assert.Equal(expected.name, actual.Name);
            Assert.Equal(expected.description, actual.Description);
            Assert.Equal(expected.website, actual.Website);
            Assert.Equal(expected.established, actual.Established);
            Assert.Equal(expected.mailingListUrl, actual.MailingListUrl);
            Assert.Equal(true, actual.IsOrganic);
            Assert.Equal(expected.images.id, actual.Images.Id);
            Assert.Equal(expected.images.name, actual.Images.Name);
            Assert.Equal(expected.images.description, actual.Images.Description);
            Assert.Equal(expected.images.icon, actual.Images.Icon);
            Assert.Equal(expected.images.medium, actual.Images.Medium);
            Assert.Equal(expected.images.large, actual.Images.Large);
        }
    }
}
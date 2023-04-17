using ServiceLayer.DTO;
using ServiceLayer.I_R;

// Kan ikke teste de functioner som ligger på databasen 
// fordi in memory bruger sqlLite

namespace TestEshop
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestGetUserByGuid()
        {
            User user = new User()
            {
                UserId = Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"),
                FirstName = "Thomas",
                Lastname = "Damkjær",
                Email = "thomasdamkjaer@gmail.com",
                Address = "Alsgade 42 A",
                Disable = false,
                Fk_ZipCodeId = 6400
            };
            var context = EfCoreSetup.CreateContext();
            IUser userService = new RepositoryUser(context);

            User foundUser = await userService.GetUserByGuidAsync(Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"));

            Assert.Equal(user.FirstName, foundUser.FirstName);
            Assert.Equal(user.Lastname, foundUser.Lastname);
            Assert.Equal(user.Address, foundUser.Address);
            Assert.Equal(user.Disable, foundUser.Disable);
            Assert.Equal(user.Email, foundUser.Email);
        }
        [Fact]
        public async Task TestCreateUser()
        {
            var context = EfCoreSetup.CreateContext();
            IUser userService = new RepositoryUser(context);

            //await userService.CreateUserAsync("Brian", "Petersen", "b@mail.dk", "password", "Gade 420", 6400);
            User foundUser = context.User.Last();

            Assert.Equal(foundUser.FirstName, "Brian");
            Assert.Equal(foundUser.Lastname, "Petersen");
            Assert.Equal(foundUser.Email, "b@mail.dk");
            Assert.Equal(foundUser.Password, "password");
            Assert.Equal(foundUser.Address, "Gade 420");
            Assert.Equal(foundUser.Fk_ZipCodeId, 6400);
            Assert.Equal(foundUser.Disable, false);
            Assert.NotNull(foundUser.UserId);
        }
        [Fact]
        public async Task TestCreateOrdre()
        {
            var context = EfCoreSetup.CreateContext();
            IOrdre ordreService = new RepositoryOrdre(context);
            IProduct productService = new RepositoryProduct(context);
            
            ICollection<OrdreProduct> produces = new HashSet<OrdreProduct>() {
                new OrdreProduct() {
                Amount = 2,
                Fk_ProductId = 1
                },
                new OrdreProduct(){
                Amount = 5,
                Fk_ProductId = 2      
                }};
            Ordre newOrdre = new Ordre()
            {
                OrdreId = 2,
                Fk_DeliveryId = 1,
                Fk_PayementId = 1,
                Fk_UserId = Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"),
                Products = produces,
            };
            await ordreService.CreateOrdreAsync(newOrdre);
            Ordre foundOrdre = context.Ordre.Where(o => o.OrdreId == 2).FirstOrDefault();

            Assert.Equal(foundOrdre.Products.Count(), 2);
            Assert.Equal(foundOrdre.OrdreId, 2);
        }
        [Fact]
        public async Task TestGetOrdreById()
        {
            var context = EfCoreSetup.CreateContext();
            IOrdre ordreService = new RepositoryOrdre(context);

            Ordre foundOrdre = await ordreService.GetOrdreByIdAsync(1);

            Assert.Equal(foundOrdre.OrdreId, 1);
            Assert.Equal(foundOrdre.Fk_PayementId, 1);
            Assert.Equal(foundOrdre.Fk_DeliveryId, 1);
            Assert.Equal(foundOrdre.Fk_UserId, Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"));
            Assert.NotNull(foundOrdre.Created);
        }
        [Fact]
        public async Task TestUpdateUser()
        {
            var context = EfCoreSetup.CreateContext();
            IUser userService = new RepositoryUser(context);

            User foundUser = await userService.GetUserByGuidAsync(Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"));
            foundUser.FirstName = "Kevin";
            await userService.UpdateUserAsync(foundUser);
            User updateUser = await userService.GetUserByGuidAsync(Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"));

            Assert.Equal(updateUser.FirstName, "Kevin");
        }
        [Fact]
        public async Task TestSearchProductByNameText()
        {
            var context = EfCoreSetup.CreateContext();
            IProduct productService = new RepositoryProduct(context);

            //List<ProductDTO> foundProducts = await productService.SearchProductByProductTextAsync("%Boo%");

           // ProductDTO foundProduct = foundProducts.FirstOrDefault();

            Assert.Equal(foundProduct.Name, "Booster");
        }
    }
}
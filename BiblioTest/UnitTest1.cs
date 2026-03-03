using App.BiblioX.Domain.Interfaces;
using App.BiblioX.Domain.Models;
using App.BiblioX.ViewModels;
using Moq;

namespace BiblioTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task LoadBooks_Test()
        {
          
            var mockService = new Mock<IGenreService>();
            mockService.Setup(s => s.GetLivresByGenreAsync(1))
                       .ReturnsAsync(new List<Livre>
                       {
                       new Livre { Titre = "Test Livre 1" },
                       new Livre { Titre = "Test Livre 2" }
                       });

            var vm = new GenresViewModel(mockService.Object);

            await vm.LoadBooks(1);

           
            Assert.NotNull(vm.LivresItems);
            Assert.Equal(2, vm.LivresItems.Count);
            Assert.Contains(vm.LivresItems, l => l.Titre == "Test Livre 1");
        }

        [Fact]
        public async Task LoadBooks_Exception()
        {
            var mockService = new Mock<IGenreService>();
            mockService.Setup(s => s.GetLivresByGenreAsync(It.IsAny<int>()))
                       .ThrowsAsync(new Exception("Erreur API"));

            var vm = new GenresViewModel(mockService.Object);

            await vm.LoadBooks(1);

            Assert.Null(vm.LivresItems); 
        }
    }
}

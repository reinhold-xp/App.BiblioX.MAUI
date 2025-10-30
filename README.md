# Biblio.MAUI

![Tests](https://img.shields.io/badge/tests-xUnit%20%2B%20Moq-green)
![Aper�u de Biblio](https://github.com/reinhold-xp/App.BiblioX.MAUI/blob/master/App.BiblioX/Resources/Images/biblio.png)

Application multiplateforme con�ue pour interagir avec une API REST et structur�e dans une architecture inspir�e des principes **SOLID**

---

## Objectif technique

Ce projet est avant tout un terrain d�exp�rimentation structur� autour de :

- Un **D�couplage des responsabilit�s** (Services, ViewModels, DTOs)
- Une **impl�mentation idiomatique de MVVM** avec CommunityToolkit.Mvvm
- Des **services autonomes et testables**
- Une **gestion simple des d�pendances** avec Microsoft.Extensions.DependencyInjection

---

## Principes SOLID appliqu�s

| Principe | Mise en �uvre |
|----------|----------------|
| **S**ingle Responsibility | Chaque classe a une responsabilit� claire (ex. `RestApiService` ne g�re que les appels HTTP) |
| **O**pen/Closed           | Les services sont extensibles sans modification (ex. ajout de `PostAsync<T>()`) |
| **L**iskov Substitution   | Les m�thodes g�n�riques comme `GetAsync<T>()` respectent les contrats attendus |
| **I**nterface Segregation | Les ViewModels n�exposent que ce qui est n�cessaire � la vue |
| **D**ependency Inversion  | Les services sont injectables et testables sans d�pendance forte |

---

## Tests unitaires avec xUnit et Moq
Le projet inclut des tests unitaires cibl�s sur les ViewModels. 
Ces tests utilisent xUnit pour la structure et Moq pour simuler les services inject�s.

## Extrait de code (test de chargement r�ussi)
```csharp
[Fact]
public async Task LoadBooks_Test()
{
    var mockService = new Mock<IGenreService>();
    mockService.Setup(s => s.GetLivresByGenreAsync(1))
               .ReturnsAsync(new List<DtoLivre>
               {
                   new DtoLivre { Titre = "Test Livre 1" },
                   new DtoLivre { Titre = "Test Livre 2" }
               });

    var vm = new GenresViewModel(mockService.Object);

    await vm.LoadBooks(1);

    Assert.NotNull(vm.LivresItems);
    Assert.Equal(2, vm.LivresItems.Count);
    Assert.Contains(vm.LivresItems, l => l.Titre == "Test Livre 1");
}




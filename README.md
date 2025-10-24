# Biblio.MAUI

![Tests](https://img.shields.io/badge/tests-xUnit%20%2B%20Moq-green)
![Aperçu de Biblio](https://github.com/reinhold-xp/App.BiblioX.MAUI/blob/master/App.BiblioX/Resources/Images/biblio.png)

Application multiplateforme conçue pour interagir avec une API REST et structurée dans une architecture inspirée des principes **SOLID**

---

## Objectif technique

Ce projet est avant tout un terrain d’expérimentation structuré autour de :

- Un **Découplage des responsabilités** (Services, ViewModels, DTOs)
- Une **implémentation idiomatique de MVVM** avec CommunityToolkit.Mvvm
- Des **services autonomes et testables**
- Une **gestion simple des dépendances** avec Microsoft.Extensions.DependencyInjection

---

## Principes SOLID appliqués

| Principe | Mise en œuvre |
|----------|----------------|
| **S**ingle Responsibility | Chaque classe a une responsabilité claire (ex. `RestApiService` ne gère que les appels HTTP) |
| **O**pen/Closed           | Les services sont extensibles sans modification (ex. ajout de `PostAsync<T>()`) |
| **L**iskov Substitution   | Les méthodes génériques comme `GetAsync<T>()` respectent les contrats attendus |
| **I**nterface Segregation | Les ViewModels n’exposent que ce qui est nécessaire à la vue |
| **D**ependency Inversion  | Les services sont injectables et testables sans dépendance forte |

---

## Tests unitaires avec xUnit et Moq
Le projet inclut des tests unitaires ciblés sur les ViewModels. 
Ces tests utilisent xUnit pour la structure et Moq pour simuler les services injectés.

## Extrait de code (test de chargement réussi)
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




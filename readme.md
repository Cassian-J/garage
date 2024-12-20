# Gestionnaire de Garage

Ce projet est un programme en C# permettant de gérer un garage, notamment en ajoutant des voitures, des marques et des modèles, en listant les informations enregistrées, et en gérant la location de voitures.

## Prérequis

- .NET 9 SDK installé.

---

## Fonctionnalités

- Ajouter des marques et des modèles.
- Ajouter des voitures associées à des marques et des modèles.
- Louer ou rendre une voiture.
- Lister toutes les voitures, marques ou modèles disponibles.
- Sauvegarder et charger les données à partir d'un fichier.

---

## Structure du Projet

### Classes Principales

### `Parc`
Gère les voitures et les marques/modèles dans le garage. Voici ses principales fonctionnalités :

- **Ajout de marques**
  - Méthode : `AddBrand(string brandName)`
  - Ajoute une nouvelle marque si elle n'existe pas déjà.

- **Ajout de modèles**
  - Méthode : `AddModel(string modelName, string brandId)`
  - Ajoute un modèle à une marque existante.

- **Ajout de voitures**
  - Méthode : `AddCars(string brandName, string modelName, int manufactureYear, bool isRented)`
  - Ajoute une voiture au garage si la marque et le modèle existent.

- **Lister les informations**
  - `ListCars()` : Liste toutes les voitures triées par marque et modèle.
  - `ListBrands()` : Liste toutes les marques disponibles.
  - `ListModels()` : Liste tous les modèles par marque.

- **Gestion des locations**
  - `LouerVoiture(int carId)` : Marque une voiture comme louée.
  - `ArreterLocation(int carId)` : Marque une voiture comme rendue.

### `Menu`
Gère l'interaction utilisateur via un menu texte :
- Ajout de voitures, marques, modèles.
- Affichage des listes des voitures, marques, modèles.
- Gestion de la location et restitution des voitures.
- Sauvegarde et chargement des données via la classe `CarContainer`.

### `Car`
Représente une voiture avec les propriétés :
- `Brand` : Nom de la marque.
- `Model` : Nom du modèle.
- `Year` : Année de fabrication.
- `Id` : Identifiant unique de la voiture.
- `IsRented` : Statut de location.

### `CarContainer`
Gère la sauvegarde et le chargement des données dans un fichier texte.
- `SaveToFile(string filePath)` : Sauvegarde les données dans un fichier.
- `LoadFromFile(string filePath)` : Charge les données à partir d'un fichier existant.

---

## Utilisation

### Exécution du Programme
1. Compiler et exécuter le projet dans un environnement C#.
2. Un menu s'affichera avec les options suivantes :

```
=== GESTION DU GARAGE ===
[1] Ajouter une voiture
[2] Ajouter une marque
[3] Ajouter un modèle
[4] Louer une voiture
[5] Rendre une voiture
[6] Lister les voitures
[7] Lister les brands
[8] Lister les modèles
[9] Quitter
==========================
Veuillez choisir une option: 
```

3. Suivez les instructions à l'écran pour gérer votre garage.

### Sauvegarde des Données
Le programme sauvegarde automatiquement les données dans un fichier `save.txt` à chaque action. Si ce fichier existe, il est chargé au démarrage.

---

## Exemple de Données Sauvegardées

Voici un exemple de contenu du fichier `save.txt` :

```
[Cars]
Toyota,Corolla,2020,1,false
Toyota,Corolla,2021,2,true
Ford,Focus,2019,3,false

[Models]
Toyota:Corolla,Camry
Ford:Focus,Fiesta
```

---

## Auteur

Créé par Cassian et camille.
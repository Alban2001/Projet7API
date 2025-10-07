# Rendez votre back-end .NET plus flexible avec une API REST

**Date de création** : 07 octobre 2025
**Date de la dernière modification** : 07 octobre 2025
**Auteur** : Alban VOIRIOT
**Informations techniques** :

- **Technologies** : API REST, C#, .NET, SQL, SQLServer
- **Version de .NET ** : 6.0
- **Version de SQLServer** : 18.7.1

## Sommaire

- [Contexte](#contexte)
- [Installation](#installation)
  - [Télécharger le projet](#télécharger-le-projet)
  - [Configurer la base de données](#configurer-la-base-de-données)
  - [Compiler et lancer l'application](#compiler-et-lancer-lapplication)
  - [Compte Administrateur](#compte-administrateur)
- [Guide d'utilisation](#guide-dutilisation)
  - [Comptes](#comptes)

## Contexte

Ce projet a été conçu dans le cadre de ma formation de développeur d'applications Back-end .NET (OpenClassrooms) sur la création d'une API qui vise à simplifier la communication et l’utilisation des informations post-transaction entre le front et le back-office.


## Installation

### Télécharger le projet

=> Pour télécharger le dossier, veuillez effectuer la commande GIT ou directement dans le GIT de Visual Studio : `git clone https://github.com/Alban2001/Projet7API.git` dans un dossier vide puis ouvrir la solution du projet.

### Restaurer les dépendances

=> Veuillez effectuer la commande : `dotnet restore` afin de pouvoir avoir tous les packages Nuget et composants installés pour éviter toute erreur de librairie manquante.

### Configurer la base de données

=> Les entités et le schéma étant déja construit, vous n'avez plus qu'à effectuer la commande suivante : `Update-Database -Context ApplicationDbContext` afin de pouvoir la créer et l'avoir en local
=> Une fois la base crée, modifier la chaîne de connexion dans le fichier `appsettings.json` :

```
    "DefaultConnection": "Server=;Database=NOM_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true",
```

### Compiler et lancer l'application

=> Cliquez sur le bouton d'exécution et choisissez IIS Express comme option. Une fois l'application lancée, vous serez un simple visiteur et juste la possibilité de visualiser les routes de l'API et utiliser la route **/Login**. En effet, l'utilisation des autres routes est uniquement accessible aux utilisateurs disposant du rôle **ADMIN**.

### Compte Administrateur

=> Le compte administrateur sera créé automatiquement lors du lancement de l'application.

## Guide d'utilisation

### Comptes

=> Afin de pouvoir prendre la main pour utiliser l'API, vous devez utiliser le compte administrateur en vous connectant sur la route **/Login** avec les identifiants suivants :
- UserName : admin2
- Mot de passe : Admin126754?!

=> Ensuite, un jeton JWT vous sera donné, copiez le puis sur le bouton **Authorize** avec le petit cadenas tout en haut à droite. Celui-ci étant ouvert cela signifie que vous n'êtes pas encore connecté.

=> Veuillez cliquer dessus, coller votre jeton généré précédemment puis cliquez sur le bouton **Authorize** pour valider. Une fois validé, vous constaterez que tous les cadenas sur toutes les routes seront fermés, cela signifie que vous êtes connecté.

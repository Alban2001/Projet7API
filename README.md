# Rendez votre back-end .NET plus flexible avec une API REST

**Date de cr�ation** : 07 octobre 2025
**Date de la derni�re modification** : 07 octobre 2025
**Auteur** : Alban VOIRIOT
**Informations techniques** :

- **Technologies** : API REST, C#, .NET, SQL, SQLServer
- **Version de .NET ** : 6.0
- **Version de SQLServer** : 18.7.1

## Sommaire

- [Contexte](#contexte)
- [Installation](#installation)
  - [T�l�charger le projet](#t�l�charger-le-projet)
  - [Configurer la base de donn�es](#configurer-la-base-de-donn�es)
  - [Compiler et lancer l'application](#compiler-et-lancer-lapplication)
  - [Compte Administrateur](#compte-administrateur)
- [Guide d'utilisation](#guide-dutilisation)
  - [Comptes](#comptes)

## Contexte

Ce projet a �t� con�u dans le cadre de ma formation de d�veloppeur d'applications Back-end .NET (OpenClassrooms) sur la cr�ation d'une API qui vise � simplifier la communication et l�utilisation des informations post-transaction entre le front et le back-office.


## Installation

### T�l�charger le projet

=> Pour t�l�charger le dossier, veuillez effectuer la commande GIT ou directement dans le GIT de Visual Studio : `git clone https://github.com/Alban2001/Projet7API.git` dans un dossier vide puis ouvrir la solution du projet.

### Restaurer les d�pendances

=> Veuillez effectuer la commande : `dotnet restore` afin de pouvoir avoir tous les packages Nuget et composants install�s pour �viter toute erreur de librairie manquante.

### Configurer la base de donn�es

=> Les entit�s et le sch�ma �tant d�ja construit, vous n'avez plus qu'� effectuer la commande suivante : `Update-Database -Context ApplicationDbContext` afin de pouvoir la cr�er et l'avoir en local
=> Une fois la base cr�e, modifier la cha�ne de connexion dans le fichier `appsettings.json` :

```
    "DefaultConnection": "Server=;Database=NOM_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true",
```

### Compiler et lancer l'application

=> Cliquez sur le bouton d'ex�cution et choisissez IIS Express comme option. Une fois l'application lanc�e, vous serez un simple visiteur et juste la possibilit� de visualiser les routes de l'API et utiliser la route **/Login**. En effet, l'utilisation des autres routes est uniquement accessible aux utilisateurs disposant du r�le **ADMIN**.

### Compte Administrateur

=> Le compte administrateur sera cr�� automatiquement lors du lancement de l'application.

## Guide d'utilisation

### Comptes

=> Afin de pouvoir prendre la main pour utiliser l'API, vous devez utiliser le compte administrateur en vous connectant sur la route **/Login** avec les identifiants suivants :
- UserName : admin2
- Mot de passe : Admin126754?!

=> Ensuite, un jeton JWT vous sera donn�, copiez le puis sur le bouton **Authorize** avec le petit cadenas tout en haut � droite. Celui-ci �tant ouvert cela signifie que vous n'�tes pas encore connect�.

=> Veuillez cliquer dessus, coller votre jeton g�n�r� pr�c�demment puis cliquez sur le bouton **Authorize** pour valider. Une fois valid�, vous constaterez que tous les cadenas sur toutes les routes seront ferm�s, cela signifie que vous �tes connect�.

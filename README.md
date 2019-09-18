# CinémAR
CinémAR is a uni project for a data visualization course.

This is uploaded as a lightweight Unity Project. Inside the only scene, one 
should type their IMDB API key (one the DataFetcher instance). Such a key can
be acquired for free on http://www.omdbapi.com/.

It should also be noted that this app requires an AR marker to be used. Said
marker is included in this repo.

This project and this repo contain tools and resources that belong to Unity
Technologies and other third party corporations and people. Any use, commercial
or otherwise, of this project, should comply with their rules and guidelines.

## Démarche
L'objectif de ce projet est de coder une petite application pour téléphone mobile,
permettant de visualiser des données sur un film choisi par l'utilisateur, de façon interactive,
en réalité augmentée (AR). Bien que cette application ne soit pas une application de streaming
vidéo, permettant de visionner le film dans son entier, elle permet d'afficher pour n'importe
quel film contenu dans la base de donnée IMDB (Internet Movie Database) son titre, le nom de
son réalisateur, l'année sa sortie, le nom de ses acteurs principaux, un bref synopsis et l'affiche
du film. Le tout étant présenté comme dans une petite salle de cinéma miniature, visible en
AR, depuis un téléphone fonctionnant avec Android. Cette application s'appelle CinémAR.
Au plan technique, l'objectif était d'avoir recours à deux API différentes pour la collecte
de données et pour leur affichage (respectivement l'API permettant d'interroger IMDB, et
Vuforia). Le but était aussi de se servir de données de deux types différents (images et texte)
et de formats standardisés (.jpg, .png pour les images, et json pour le texte).

## Utilisation de l'application
Pour utiliser l'application, il faut naturellement commencer par installer le fichier .apk
associé. Une fois celui-ci installé, lors du premier lancement de l'application, il est plus que
probable qu'Android demande à l'utilisateur quelques autorisations (caméra et connexion à
internet, essentiellement).

Au dessus du marqueur AR, l'application fait apparaître une
« salle de cinéma miniature », avec un écran blanc en avant, et un projecteur en arrière. Audessus
du projecteur se trouve un petit champ de recherche, qui permet de saisir le titre d'un
film. Si ce film est répertorié dans IMDB, les informations correspondantes seront affichées
sur l'écran.

![Alt Text](images/ar_marker_001.png)

L'AR permet de visualiser des données qualitatives de manière relativement ludique,
comme dans une petite salle de cinéma. Néanmoins, CinémAR est avant tout pensé comme un
gadget, et n'est pas adapté à une utilisation intensive : l'application n'offre aucune
fonctionnalité qui ne soit déjà accessible depuis le site d'IMDB, et est fondamentalement une
démonstration des possibilités de visualisation de données en AR.

##Considérations techniques
L'application a été développée avec Unity, sur Windows. Une fois sur Android, elle
fonctionne en Java, mais a été codée nativement en C# (et en C++, pour le fonctionnement
interne de Unity). Le choix de Unity vient de ce que cet outil particulièrement bien conçu offre
la possibilité de créer facilement des petites applications AR, particulièrement avec son API
Vuforia, qui propose des licences gratuites aux utilisateurs particuliers et aux petites
entreprises.

Cinq classes ont été codées pour ce projet, en adoptant un pattern de design « humble
object », ce qui signifie que ce sont des classes aux objectifs très bien circonscrits. La plus
complexe de ces classes est certainement DataFetcher, dont la tâche est de récupérer les
données sur IMDB, en se connectant à son API. Malgré tout, elle reste une classe relativement
simple, avec seulement quatre attributs, trois méthodes et deux coroutines.
Les deux coroutines, justement, ont vocation à « aller chercher » les données sur
internet. Le fait d'en faire des coroutines permet une exécution fluide de l'application, pendant
qu'elles s'exécutent sur un thread séparé, sans perturber le reste du fonctionnement de
CinémAR.

Le choix d'IMDB est motivé par, d'une part, la qualité de leur API gratuitement
accessible (jusqu'à 1'000 requêtes par mois) et la possibilité d'obtenir, à travers elle et les URL
fournis en réponse à certaines requêtes, du texte et des images, ce qui permettait d'intégrer
différents types de données dans le projet.

L'API d'IMDB peut renvoyer des données en json ou en XML. Il se trouve que Unity
propose des outils de parsing du json extrêmement pratiques, raison pour laquelle ce format a
été utilisé dans le cas de CinémAR.

Updated on 20190918.
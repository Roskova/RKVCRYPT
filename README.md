![Logo](https://raw.githubusercontent.com/Roskova/RKV-CRYPT/main/logo.png)
# RKV-CRYPT
### Logiciel de cryptage modulaire par ROSKOVA
RKV-CRYPT est un logiciel de cryptage modulaire développé par ROSKOVA qui a pour but de permettre à n'importe qui sans expérience en informatique de crypter des messages de façon sécurisés. Le Cryptage (lorsque le projet sera final) offert par RKV-CRYPT est particulièrement efficace contre les attaques grâce à sa grande modularité permettant de combiner différentes méthodes de chiffrement tant symétrique qu'asymétrique rendant ainsi les attaques inefficaces. Le principe de RKV-CRYPT est de permettre à l'utilisateur de choisir lui-même comment il veut que le logiciel crypte le message (plusieurs couches de cryptage modulaire sont appliquées au message). Le logiciel est standalone ou peut-être utilisé conjointement avec le fichier config.txt permettant de personnaliser l'interface.

### Liste des fonctionnalités implantée:
- [x] Interface dynamique
- [x] Numérisation (En fonction des tables de caratères fourni dans le fichier table.txt)
- [ ] Block4+ (Dériver du Chiffre Affine)
- [ ] Hill 
- [ ] Binarisation
- [ ] Binarosk (ROSKOVA)
- [ ] Système de clé symétrique (Permet d'appliquer une ou plusieurs clé au message)
- [ ] Lecture du binaire
- [ ] Hexadécimal
- [ ] Sélecteur MK (Permet de sélectionner la Méthode de chiffrement)
- [ ] CESAR3 (Dérivé du chiffrement de césar)
- [ ] TDES
- [ ] AES256 à tour variable (Algorithme AES256 modifié)
- [ ] RSA

### Système d'exploitation prise en charge actuellement:
- [ ] Debian
- [X] Windows
- [ ] Fedora
- [ ] Arch
- [ ] MacOS

### Fonctionnement de RKV-CRYPT (1.0.3.0)
Actuellement RKV-CRYPT prends uniquement la numérisation du message en charge. Les Pre-Release 1.0.1.1 à 1.0.1.8 inclue les autres méthodes de chiffrement à titre expérimentale (La plupart étant non fonctionnel ou causant des erreurs de chiffrement)

### Arborescence du dossier de configuration 
> ./
>	Config/
>		Interface.txt+
>		Table.txt+
>		Config.txt+
>		Module.txt+
>	Module/
>		Numerisation/
>			Config.txt
>			Table.txt
>			Interface.txt
>		Block4plus/
>			Config.txt
>			Interface.txt
>		Numerisation.dll
>		Block4plus.dll
>	Docs/
>		RKVCRYPT_manual_cafr.pdf+
>		RKVCRYPT_manual_en.pdf*
> RKVCRYPT.exe
> README.txt*
>
>./
>	Module/
>		Exemple/
>			Config.txt
>			Interface.txt
>		Exemple.dll
>	Docs/
>		EXEMPLE_Manual_fr.pdf*
>README.txt*
______________________________________________________________________

Les fichiers marquer * sont optionnel et n’affecte pas la fonctionnalité de RKVCRYPT.
Les fichiers marquer + sont obligatoire et seront autogénéré lorsque manquant. Cela réinitialise les modifications apporter à ceux-ci.
Les dossiers souligner sont obligatoire et empêche l’exécution des modules de RKVCRYPT lorsque manquant. S’ils ne sont pas présents, les paramètres par défaut seront utilisé. 
Les fichiers en gras sont à titre d’exemple. Lorsque d’un module nécessite un fichier de configuration, il doit être mis dans un dossier portant le nom du module à l’intérieur du dossier modules de RKVCRYPT.


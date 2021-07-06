# Gestion des devises

Vous souhaitez créer un petit programme permettant de convertir automatiquement des montants dans une devise souhaitée.
Vous disposez des informations suivantes :
- Un montant dans une devise initiale
- Une devise cible
- Une liste incomplète de taux de change
En vous servant de la liste des taux de change, vous devez arriver à convertir le montant dans la devise cible.

Par exemple, si vous voulez 550 Euros (EUR) en Yens (JPY), et que vous avez cette liste de taux de change :

| Devise de départ        | Devise d'arrivée           | Taux de change  |
| ------------- |:-------------:| -----:|
| AUD      | CHF | 0.9661 |
| JPY      | KWU | 13.1151 |
| EUR      | CHF | 1.2053 |
| AUD      | JPY | 86.0305 |
| EUR      | USD | 1.2989 |
| JPY      | INR | 0.6571 |


Pour convertir les EUR en JPY, vous devez convertir le montant des dépenses en CHF, puis en AUD, puis en JPY, en utilisant les taux suivants :

| Devise de départ        | Devise d'arrivée           | Taux de change  |
| ------------- |:-------------:| -----:|
| EUR      | CHF | 1.2053 |
| AUD      | CHF | 0.9661 |
| AUD      | JPY | 86.0305|

Afin de faciliter le calcul, les taux de change sont arrondis à 4 décimales. Chaque étape intermédiaire de calcul doit être arrondie à 4 décimales, et vous devez restituer le montant final arrondi sous la forme d'un nombre entier positif.

Dans le cas de l'exemple le résultat est donc le suivant :

EUR --> CHF : 550 * 1.2053 = 662.9150 

CHF --> AUD : 662.9150 * (1/0.9661) = 686.1833 (Attention, ici nous inversons le taux car le taux fourni est AUD --> CHF et nous voulons CHF --> AUD. L'inversion doit également être arrondie à 4 décimales, donc 1/0.9661 = 1.0351 

AUD --> JPY : 686.1833 * 86.0305 = 59033 (arrondi à l'entier) Le résultat attendu est donc 59033.

Si plusieurs chemins de conversion vous permettent d'atteindre la devise cible, vous devez utiliser le chemin le plus court.

## Entrée du programme

Le programme doit pouvoir être exécuté avec la ligne de commande suivante :

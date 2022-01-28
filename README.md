Projet Architecture Logiciel : 
Le but du projet est de développer une API en .NET en utilisant le EntityFramework qui elle meme exploite une librairie qui doit etre développée aussi .

Explication d'utilisation : 

* Vous pouvez utiliser le logiciel postman pour requeter l'API.


* Tout d'abord l'authentification : 
        - pour commencer, l'utilisateur doit doit s'authentifier pour pouvoir utiliser l'API et ce, en passant des identifinats (email, password) qu'on a définis statiquement. 
          Pour cela, l'utilisateur doit passer cette URL "https://localhost:(Numéro de port)/api/v1/Authentication/login" en mode POST en spécifiant les identifiant suivant
          dans le body : {"Email" : "admin1@test.com", "Password" : "PwdAdmin1"} .
          
  
* La pagination : 
        - Pas défaut (en cas ou la pagination n'est pas spécifié), l'API retourne que trois enregistrement par page.
        - Et pour spécifier la pagination, on utilise les paramètre suivants :  per_page=(nombre d'enregistrement pas page) et current_page=(la page acctuelle)
        - EXEMPLE : "https://localhost:44368/api/v1/Products?per_page=5&current_page=1" 
        ATTENTION !!! : Nous avons définis un nombre maximal de 5 enregistrements par page C.A.D qu'un "per_page=6" retournera quand meme 5 enregistrements.
        
* Le trie : 
        - le trie se fait avec les deux paramètres suivant :  
          * asc : pour le trie ascendant.
          * desc : pour le trie descendant.
            et ce, en fonction de la propriété spécifié.
        - EXEMPLE : "https://localhost:44368/api/v1/Products?per_page=5&current_page=1&asc=name" OU "https://localhost:44368/api/v1/Products?per_page=5&current_page=1&desc=id"
        
* La réponse partièlle : 
        -L'API propose de  retourner des enregistrement réduits avec le minimum de champs en fonctions des besoins de l'utilisateur. et ce en utilisant le paramtre Fields
        - EXEMPLE: "https://localhost:44368/api/v1/Products?per_page=5&current_page=1&Fields=name,id"
        
*  Les Logs : Un dossier de logs (nommé Logs) dans la raçine de la solution contien un fichier .txt listant toutes actions exécutée.

using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Networking;
 
 public class APIClient : MonoBehaviour
 {
     const string url = "http://localhost:50003/API/Personagems/";
 
     // Use this for initialization
     void Start()
     {
         StartCoroutine(GetPersonagemsAPI());
     }
 
     IEnumerator GetPersonagemsAPI()
     {
         //UnityWebRequest request = UnityWebRequest.Get(url + "/1");
         UnityWebRequest request = UnityWebRequest.Get(url);
 
         yield return request.Send();
 
         if (request.isNetworkError || request.isHttpError)
         {
             Debug.Log(request.error);
         }
         else
         {
             string strRespostaServidor = request.downloadHandler.text;
             Debug.Log(strRespostaServidor);
 
             byte[] result = request.downloadHandler.data;

            //Item meuItem = JsonUtility.FromJson<Item>(strRespostaServidor);
            //ImprimirItem(meuItem);


            Personagem[] teste = JsonHelper.getJsonArray<Personagem>(strRespostaServidor);

            foreach (Personagem i in teste)
            {
                ImprimirPersonagem(i);
            }
        }
     }
 
     void ImprimirPersonagem(Personagem i)
     {
         Debug.Log("====== Dados objeto ======= ");
         Debug.Log("ID: " + i.PersonagemID);
         Debug.Log("Nome: " + i.Nome);
         Debug.Log("Descrição: " + i.Descricao);
 
     }
 }

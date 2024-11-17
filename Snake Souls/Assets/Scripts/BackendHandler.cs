using UnityEngine;
using TMPro;
using Assets.scripts;
using System.Collections;
using UnityEngine.Networking;

public class BackendHandler : MonoBehaviour 
{
    public TMP_Text highScoreTextArea;
    public TMP_InputField playernameInput;
    public TMP_InputField scoreInput;
    bool updateHighScoreTextArea = false;
    bool scoreInputCheckPassed = false;
    private int fetchCounter = 0;
    const string BackendURL = "https://niisku.lab.fi/~x116736/snakesouls/server/server.php";
    const string JSONTestContent = "";
    const int maxHighscoreResultsAmount = 3; //This needs to match the server or create a way to send this when querying for the results

    Highscores hs;

    void Start() 
    {
        hs = JsonUtility.FromJson<Highscores>(JSONTestContent);
        FetchHighScoresJSON(); //Let's load the highscores from the start for once
    }

    void Update() 
    {
        if(updateHighScoreTextArea) {
            // update list only if we've gotten an update from a request
            Debug.Log("Updating Highscores list");
            highScoreTextArea.text = CreateHighScoreList(); // Create new list string
            updateHighScoreTextArea = false; // Set update flag to false
            Debug.Log("Update done");
        }
    }

    /*
    * This function handles creating the string for the highscore list
    */
    string CreateHighScoreList() 
    {
        Debug.Log("Creating Highscores list");
        string highScoreList = ""; // Empty highscorelist string
        if(hs != null)
        {
            int len = (hs.scores.Length < maxHighscoreResultsAmount) ? hs.scores.Length : maxHighscoreResultsAmount; 
            for(int i = 0; i < len; i++) {
                highScoreList += string.Format("[ {0} ] | {1,-16} | {2}\n", i+1, hs.scores[i].playername, hs.scores[i].score);
            }
        }
        return highScoreList; // Return the ready made liststring
    }

    IEnumerator GetRequestForHighscores(string uri) 
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) 
        {
            Debug.Log("Starting data fetch from server " + uri);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            yield return webRequest.SendWebRequest();

            string resultString = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            if(webRequest.result == UnityWebRequest.Result.ConnectionError) {
                //Log an error to console
                Debug.Log("Error: " + webRequest.error);
            }
            else {
                // Create a row to highscores textbox
                Debug.Log("Got data updating Highscores");
                hs = JsonUtility.FromJson<Highscores>(resultString);
                Debug.Log("Data: "+resultString);
                updateHighScoreTextArea = true;
                Debug.Log("Triggering table update");
            }
        }
    }

    /*
    * This function starts the list update process from Backend
    */
    public void FetchHighScoresJSON()
    {
        fetchCounter++; // This is currently not utilized anywhere, may be deprecated from code
        StartCoroutine(GetRequestForHighscores(BackendURL));
    }

    IEnumerator PostRequestForHighscores(string uri, Highscore hsItem)
    {
        using(UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(uri, JsonUtility.ToJson(hsItem)))
        {
            Debug.Log("Sending new highscore of " + hsItem.playername + " " + hsItem.score + " to " + uri);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            string resultString = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
            if(webRequest.result == UnityWebRequest.Result.ConnectionError) {
                //Log an error to console
                Debug.Log("Error: " + webRequest.error);
            }
            else {
                // Create a row to highscores textbox
                Debug.Log("New highscore sent successfully");
                Debug.Log("Data: "+resultString);
                // Empty the input fields
                playernameInput.text = "";
                scoreInput.text = "";
                FetchHighScoresJSON(); // Since we got new data, let's update the highscore board incase the new score should be on it
                Debug.Log("Triggering data refetch");
            }
        }
    }

    /*
    * This function starts the sending process
    * Currently this is triggered only from the send button
    */
    public void SendHighscore()
    {
        checkInputs();
        if(!scoreInputCheckPassed) return;

        Highscore hsItem = new Highscore();
        hsItem.playername = playernameInput.text;
        hsItem.score = int.Parse(scoreInput.text);

        StartCoroutine(PostRequestForHighscores(BackendURL, hsItem));
    }

    /*
    * This function verifies the inputs are ok so we don't send bad data to server
    * Score needs to be an Integer
    * Playername must not be empty
    */
    public void checkInputs()
    {
        Debug.Log("Checking inputs...");
        if(int.TryParse(scoreInput.text, out _) && playernameInput.text.Trim().Length > 0)
        {
            Debug.Log("Inputs OK");
            scoreInputCheckPassed = true;
        }
        else {
            Debug.Log("Score as not INT or playername missing");
            scoreInputCheckPassed = false;
        }
    }
}

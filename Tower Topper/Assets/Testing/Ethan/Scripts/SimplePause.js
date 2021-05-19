#pragma strict

private var pauseGame : boolean = false;
private var showGUI : boolean = false;
var player : GameObject;
var pauseImage : GameObject;
var pauseAbortMission : GameObject;


function Update()
{
	if(Input.GetKeyDown("escape"))
	{
		pauseGame = !pauseGame;
	  	
    	if(pauseGame == true)
    	{
    		Time.timeScale = 0;
    		pauseGame = true;
    		
    		//GameObject.Find("Main Camera").getComponent.enabled = false;
    		//GameObject.Find("First Person Controller").GetComponent("MouseLook").enabled = false;
    		//showGUI = true;
    		//player.SetActive(false);
    		pauseImage.SetActive(true);
    		pauseAbortMission.SetActive(true);
    		
    		
    		
    		
    	}
    }
    
    if(pauseGame == false)
    {
    	Time.timeScale = 1;
    	pauseGame = false;
    	//GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = true;
    	//GameObject.Find("First Person Controller").GetComponent("MouseLook").enabled = true;
    	//showGUI = false;
    	//player.SetActive(true);
    	pauseImage.SetActive(false);
    	pauseAbortMission.SetActive(false);
    	
    
    	
    }
 /*
    if(showGUI == true)
    {
    	  gameObject.Find("pause sign").guiTexture.enabled = true;  
    }
    
    else
    {
    	gameObject.Find("pause sign").guiTexture.enabled = false;  
    }*/
}
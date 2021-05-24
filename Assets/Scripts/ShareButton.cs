using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;
public class ShareButton : MonoBehaviour
{
    public void ClickShare(){
        StartCoroutine(LoadImageAndShare());
    }
    public void OpenFacebook(){
         Debug.Log("FACEBOOK");
        #if !UNITY_EDITOR
        openWindow("https://www.facebook.com/RayoGameStudio");
        #endif
    }
    public void OpenTwitter(){
        Debug.Log("twitter");
        #if !UNITY_EDITOR
        openWindow("https://twitter.com/StudioRayo");
        #endif
    }
    [DllImport("_Internal")]
    private static extern void openWindow(string url);

private IEnumerator TakeScreenshotAndShare(){
	yield return new WaitForEndOfFrame();

	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
	File.WriteAllBytes( filePath, ss.EncodeToPNG() );

	// To avoid memory leaks
	Destroy( ss );

	new NativeShare().AddFile( filePath ).SetSubject( "The Lights" ).SetText("Hola! Estoy jugando The Lights y quiero invitarte, es un juego de plataformas de acción 2D donde deberás ayudar a un dios a encontrar sus partes para recuperar su poder y derrotar por fin  el reinado de la oscuridad a cambio promete darte algo que has anhelado Luz en tu vida. Únete a la aventura y viaja por 4 mundos, donde deberás luchar contra diferentes enemigos y jefes. En serio, no sabes lo que te espera. ¿Eres lo suficientemente bueno para lograr tu objetivo?" ).Share();
  }

  private IEnumerator LoadImageAndShare(){
      Texture2D image = Resources.Load("logo",typeof(Texture2D)) as Texture2D;
      yield return null;
      string filePath = Path.Combine( Application.temporaryCachePath, "shared logo.png" );
	  File.WriteAllBytes( filePath, image.EncodeToPNG() );
      new NativeShare().AddFile( filePath ).SetSubject( "Mi juego" ).SetText( "hola" ).Share();
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour
{
    //material for shader graphics
    [SerializeField]
    private Material renderMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //source is the fully rendered scene that you would normally send directly to the moniter
        //we are intercepting this so we can do a bit more work before passing it on

        Graphics.Blit(source, destination, renderMaterial);
    }
}

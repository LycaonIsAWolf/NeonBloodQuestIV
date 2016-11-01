using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Pixeltron")]
public class Pixeltron : MonoBehaviour
{
    public bool DefineByWidth = false;
    public int w = 780;
    int h;
    public float divisor = 1;
    public bool UseRamp = false;
    public Texture2D ramp;
    private Material material;


    // This Image Effect is a customized and improved combination of Miguelito's PixelBoy and Rouge Noodle's GBCamera Scripts.

    protected void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }

        material = new Material( Shader.Find("Metkis/PaletteMod") );

    }

    void Awake ()
    {
    }

    void Update() {
        float wFloat;
        float wScreen;
        wScreen = Screen.width; 
        if(DefineByWidth == false){
        if (divisor >= 1){
        wFloat = wScreen / divisor;}
        else{
            wFloat = Screen.width;
            divisor = 1;}} 

            else{
            wFloat = w;

            }


        float pixelationratio = wFloat / Screen.width;

        h = Mathf.RoundToInt( Screen.height * pixelationratio);
        w = Mathf.RoundToInt(wFloat);

    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);
        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);

        if(UseRamp == true && ramp != null){
        material.SetTexture("_Palette", ramp);
        Graphics.Blit (buffer, destination, material);}
                RenderTexture.ReleaseTemporary(buffer);
    }


}
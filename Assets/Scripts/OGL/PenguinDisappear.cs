using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PenguinDisappear : MonoBehaviour
{
    [SerializeField] private  GameObject penguinShadow;
    [SerializeField] private  GameObject penguinBodyModel;
    [SerializeField] private  GameObject penguinLeftHandModel;
    [SerializeField] private  GameObject penguinRightHandModel;
    [SerializeField] private  GameObject penguinLeftFootModel;
    [SerializeField] private  GameObject penguinRightFootModel;

    private MeshRenderer penguinBodyRenderer;
    private MeshRenderer penguinLeftHandRenderer;
    private MeshRenderer penguinRightHandRenderer;
    private MeshRenderer penguinLeftFootRenderer;
    private MeshRenderer penguinRightFootRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        penguinBodyRenderer = penguinBodyModel.GetComponent<MeshRenderer>();
        penguinLeftHandRenderer = penguinLeftHandModel.GetComponent<MeshRenderer>();
        penguinRightHandRenderer = penguinRightHandModel.GetComponent<MeshRenderer>();
        penguinLeftFootRenderer = penguinLeftFootModel.GetComponent<MeshRenderer>();
        penguinRightFootRenderer = penguinRightFootModel.GetComponent<MeshRenderer>();

           
        penguinBodyRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Opaque);
        penguinLeftHandRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Opaque);
        penguinRightHandRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Opaque);
        penguinLeftFootRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Opaque);
        penguinRightFootRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Opaque);

        BaseShaderGUI.SetupMaterialBlendMode(penguinBodyRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinLeftHandRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinRightHandRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinLeftFootRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinRightFootRenderer.material);
    }

    public void Disappear(float alpha)
    {
        penguinShadow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        for (int i = 0; i < 3; i++)
        {
            penguinBodyRenderer.materials[i].SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
            BaseShaderGUI.SetupMaterialBlendMode(penguinBodyRenderer.materials[i]);
            penguinBodyRenderer.materials[i].color = new Color(0,0,0,alpha);
        }
        penguinLeftHandRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
        penguinRightHandRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
        penguinLeftFootRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
        penguinRightFootRenderer.material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
        
        BaseShaderGUI.SetupMaterialBlendMode(penguinLeftHandRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinRightHandRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinLeftFootRenderer.material);
        BaseShaderGUI.SetupMaterialBlendMode(penguinRightFootRenderer.material);
        
        penguinLeftHandRenderer.material.color = new Color(0,0,0,alpha);
        penguinRightHandRenderer.material.color = new Color(0,0,0,alpha);
        penguinLeftFootRenderer.material.color = new Color(0,0,0,alpha);
        penguinRightFootRenderer.material.color = new Color(0,0,0,alpha);

    }
}

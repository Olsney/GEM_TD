using UnityEngine;

namespace Visuals.Enchants
{
  public class EnchantVisuals : MonoBehaviour, IEnchantVisuals
  {
    private static readonly int s_colorProperty = Shader.PropertyToID("_Color");
    private static readonly int s_colorIntensityProperty = Shader.PropertyToID("_Intensity");
    private static readonly int s_outlineSizeProperty = Shader.PropertyToID("_OutlineSize");
    private static readonly int s_outlineColorProperty = Shader.PropertyToID("_OutlineColor");
    private static readonly int s_outlineSmoothnessProperty = Shader.PropertyToID("_OutlineSmoothness");
   
    public Renderer Renderer;
    
    [Header("Freeze")]
    public Color FreezeColor = new Color32(56, 163, 190, 255);
    public float FreezeOutlineSize = 3;
    public float FreezeOutlineSmoothness = 8;
    
    [Header("Poison")]
    public Color PoisonColor = new Color32(56, 163, 190, 255);
    public float PoisonColorIntensity = 0.6f;
    
    public void ApplyFreeze()
    {
      Renderer.material.SetColor(s_outlineColorProperty, FreezeColor);
      Renderer.material.SetFloat(s_outlineSizeProperty, FreezeOutlineSize);
      Renderer.material.SetFloat(s_outlineSmoothnessProperty, FreezeOutlineSmoothness);
    }
    
    public void UnapplyFreeze()
    {
      Renderer.material.SetColor(s_outlineColorProperty, Color.white);
      Renderer.material.SetFloat(s_outlineSizeProperty, 0f);
      Renderer.material.SetFloat(s_outlineSmoothnessProperty, 0f);
    }

    public void ApplyPoison()
    {
      Renderer.material.SetColor(s_colorProperty, PoisonColor);
      Renderer.material.SetFloat(s_colorIntensityProperty, PoisonColorIntensity);
    }
    
    public void UnapplyPoison()
    {
      Renderer.material.SetColor(s_colorProperty, Color.white);
      Renderer.material.SetFloat(s_colorIntensityProperty, 0f);
    }
  }
}
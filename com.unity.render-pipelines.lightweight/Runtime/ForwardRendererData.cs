using System;

namespace UnityEngine.Rendering.LWRP
{
    [CreateAssetMenu(fileName = "Custom Forward Renderer", menuName = "Rendering/Lightweight Render Pipeline/Forward Renderer", order = CoreUtils.assetCreateMenuPriority1)]
    public class ForwardRendererData : ScriptableRendererData
    {
        [Serializable, ReloadGroup]
        public sealed class ShaderResources
        {
            [SerializeField, Reload("Shaders/Utils/Blit.shader")]
            public Shader blitPS;

            [SerializeField, Reload("Shaders/Utils/CopyDepth.shader")]
            public Shader copyDepthPS;

            [SerializeField, Reload("Shaders/Utils/ScreenSpaceShadows.shader")]
            public Shader screenSpaceShadowPS;

            [SerializeField, Reload("Shaders/Utils/Sampling.shader")]
            public Shader samplingPS;
        }

        public ShaderResources shaders;

        [SerializeField] LayerMask m_OpaqueLayerMask = -1;
        [SerializeField] LayerMask m_TransparentLayerMask = -1;

        [SerializeField] StencilStateData m_DefaultStencilState = null;

        protected override void OnEnable()
        {
            ResourceReloader.ReloadAllNullIn(this, LightweightRenderPipelineAsset.packagePath);
        }

        protected override ScriptableRenderer Create() => new ForwardRenderer(this);

        internal LayerMask opaqueLayerMask => m_OpaqueLayerMask;

        public LayerMask transparentLayerMask => m_TransparentLayerMask;

        public StencilStateData defaultStencilState => m_DefaultStencilState;
    }
}

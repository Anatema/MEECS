using ME.ECS;

namespace Project.Features.Duck.Views {
    
    using ME.ECS.Views.Providers;
    
    public class DuckView : MonoBehaviourView {
        
        public override bool applyStateJob => true;

        public override void OnInitialize() {
            transform.localScale = entity.GetLocalScale();
            
        }
        
        public override void OnDeInitialize() {
            
        }
        
        public override void ApplyStateJob(UnityEngine.Jobs.TransformAccess transform, float deltaTime, bool immediately) 
        {
            transform.position = entity.GetLocalPosition();
            transform.rotation = entity.GetLocalRotation();
            
        }
        
        public override void ApplyState(float deltaTime, bool immediately) {
            
        }
        
    }
    
}
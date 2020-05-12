using BBX.Actor.Interfaces;
using BBX.Actor.Model;

namespace BBX.Actor.Handlers
{
    public class ResetHandler : IResetable
    {
        private ActorModel _model;
        
        public ResetHandler(ActorModel model)
        {
            _model = model;
        }
        
        public void Reset()
        {
            _model.Position = _model.StartPosition;
        }
    }
}
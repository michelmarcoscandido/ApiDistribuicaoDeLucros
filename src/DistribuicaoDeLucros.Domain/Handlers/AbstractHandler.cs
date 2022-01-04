using System;
using System.Runtime.CompilerServices;
using DistribuicaoDeLucros.Domain.Interfaces.Handlers;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Domain.Handlers
{
    internal abstract class AbstractHandler : IHandler
    {
        private IHandler nextHandler;
        
        public IHandler SetNext(IHandler handler)
        {
            this.nextHandler = handler;

            return handler;
        }

        public  virtual Participacao Handle(Participacao participacao)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.Handle(participacao);
            }

            return null;
        }
    }
}

using System.Collections.Generic;
using Fornecedores.Business.Notificacoes;

namespace Fornecedores.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
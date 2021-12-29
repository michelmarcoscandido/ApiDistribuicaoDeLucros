using DistribuicaoDeLucros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoDeLucros.Infra.Context
{
    public static class AreaExtension
    {
        public static void Initialize(this IServiceProvider serviceProvider) {
            
             var context = serviceProvider.GetService<SqlContext>();
            // Look for any board games.
            if (context.Area.Any())
            {
                return;   // Data was already seeded
            }

            context.Area.AddRange(
                new Area(){ Descricao = "Diretoria"},
                new Area(){ Descricao = "Contabilidade"},
                new Area(){ Descricao = "Financeiro"},
                new Area(){ Descricao = "Tecnologia"},
                new Area(){ Descricao = "Serviços Gerais"},
                new Area(){ Descricao = "Relacionamento com o Cliente"}
            );

            context.SaveChanges();
        }
    }
}
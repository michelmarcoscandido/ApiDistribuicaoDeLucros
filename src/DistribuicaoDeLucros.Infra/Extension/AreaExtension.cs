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
                new Area(){ Descricao = "Diretoria", Peso = 1},
                new Area(){ Descricao = "Contabilidade", Peso = 2},
                new Area(){ Descricao = "Financeiro", Peso = 2},
                new Area(){ Descricao = "Tecnologia", Peso = 2},
                new Area(){ Descricao = "Serviços Gerais", Peso = 3},
                new Area(){ Descricao = "Relacionamento com o Cliente", Peso = 5}
            );

            context.SaveChanges();
        }
    }
}
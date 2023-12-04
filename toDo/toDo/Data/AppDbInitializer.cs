using toDo.Models;

namespace toDo.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicesScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                if (!context.Tarefas.Any())
                {
                    context.Tarefas.AddRange(new List<Tarefa>()
                    {
                        new Tarefa()
                        {
                            name = "Trabalho Asp .Net Core",
                            EndDate = DateTime.Now.AddDays(7),
                            Status = false,
                        },
                        new Tarefa()
                        {
                            name = "Fazer backup do DB",
                            EndDate = DateTime.Now.AddDays(10),
                            Status = false,
                        }, 
                        new Tarefa()
                        {
                            name = "Teste tarefa",
                            EndDate = DateTime.Now.AddDays(10),
                            Status = false,
                        },
                        new Tarefa()
                        {
                            name = "Teste tarefa 2",
                            EndDate = DateTime.Now.AddDays(10),
                            Status = false,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

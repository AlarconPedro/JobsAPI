using Hangfire;

namespace ApiJob.Servicos;

public class Jobs
{
    public string JobDisparoUnico(string nomeJob, dynamic processo)
    {
        var job = BackgroundJob.Enqueue(processo);
        return $"Job {nomeJob}: Executado com Sucesso !";
    }

    public string JobAgendado(string nomeJob, dynamic processo, TimeSpan agendamento)
    {
        var job = BackgroundJob.Schedule(processo, agendamento);
        return $"Job {nomeJob}: Agendado com Sucesso !";
    }

    //public string JobRepeticao(string nomeJob, string processo, string tipoRepeticao)
    //{
    //    var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
    //                from t in assembly.GetTypes()
    //                where t.Name == processo
    //                select t).FirstOrDefault();
    //    if (type == null)
    //        throw new InvalidOperationException($"Tipo {processo} não encontrado.");

    //    Type nomeClasse = type;
    //    switch (tipoRepeticao)
    //    {
    //        case "M":
    //            RecurringJob.AddOrUpdate(nomeJob ,(nomeClasse) => nomeClasse, Cron.Minutely);
    //            break;
    //        case "H":
    //            RecurringJob.AddOrUpdate(nomeJob, processo, Cron.Hourly);
    //            break;
    //        case "D":
    //            RecurringJob.AddOrUpdate(nomeJob, processo, Cron.Daily);
    //            break;
    //        case "S":
    //            RecurringJob.AddOrUpdate(nomeJob, processo, Cron.Weekly);
    //            break;
    //        case "Mes":
    //            RecurringJob.AddOrUpdate(nomeJob, processo, Cron.Monthly);
    //            break;
    //        case "A":
    //            RecurringJob.AddOrUpdate(nomeJob, processo, Cron.Yearly);
    //            break;
    //    }

    //    Console.WriteLine($"Job {nomeJob}: {job}");
    //}
}

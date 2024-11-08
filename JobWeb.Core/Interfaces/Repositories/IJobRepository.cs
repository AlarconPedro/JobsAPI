using JobWeb.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services;

public interface IJobRepository : ICongelamentoRespository<TbCongelamento>
{
}

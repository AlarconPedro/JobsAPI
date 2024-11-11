using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services.Entities;

public interface IProdutoService<T> : IGenericService<T> where T : class
{
}

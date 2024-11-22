using OmegaCloudAPI.Models.OmegaCloud.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services.Data;

public interface ILoginService
{
    Task<LoginDados> Login(string codigoFirebase);
}

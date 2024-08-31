using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Interfaces.Token
{
    public interface ITokenHandler
    {
        EComPayApp.Application.DTOs.Token.Token CreateAccessToken(int minute);
    }
}

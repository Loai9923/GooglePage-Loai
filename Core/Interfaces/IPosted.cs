using Core.Dtos;
using Core.Entites;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPosted
    {
       OpStatus Add (Posted posted);

        OpStatus Update (Posted posted);

        OpStatus Delete (Posted posted);

        List<Posted> GetPosts (PostedDto title);


    }
}

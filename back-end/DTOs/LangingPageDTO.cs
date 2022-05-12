using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class LangingPageDTO
    {

        public List<PeliculasDTO> EnCines { get; set; }
        public List<PeliculasDTO> ProximosEstrenos { get; set; }

    }
}

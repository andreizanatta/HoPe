using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.InputModels
{
    public class UpdatePetInputModel
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}

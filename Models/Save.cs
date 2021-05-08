using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJdr.Models
{
    public class Save
    {
        public Story CurrentStory { get; set; }
        public Character CurrentCharacter { get; set; }
        public int CurrentSequence { get; set; }
    }
}
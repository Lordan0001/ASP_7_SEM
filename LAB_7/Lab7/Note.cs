using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Note
    {
        public string Subj { get; set; }
        public int Note1 { get; set; }
    }

    class NoteResponse
    {
        public Note[] Value { get; set; }
    }
}

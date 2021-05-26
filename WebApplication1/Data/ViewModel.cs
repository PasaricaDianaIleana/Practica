using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class ViewModel
    {
        public bool forceOverwrite { get; set; }
        public IFormFile File { get; set; }

    }
}

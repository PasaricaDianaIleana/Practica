using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domains
{
    public sealed class ProductFormModel : Product
    {
        public IFormFile File { get; set; }
    }
}

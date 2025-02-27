﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;

namespace WebApplication1.Models
{
    public class CategoriesRepresentation
    {
        public CategoriesRepresentation(List<Category> categories)
        {
            this.Categories = categories.Select(x => new CategoryRepresentation(x.CategoryId, x.Name,x.Description)).ToList();
        }

        [JsonProperty(PropertyName = "categories")]
        public List<CategoryRepresentation> Categories { get; set; }
    }
}


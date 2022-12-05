using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{

    public class FootbollerDto
    {
        [Key]
        public int Id { get; set; }
    }
}

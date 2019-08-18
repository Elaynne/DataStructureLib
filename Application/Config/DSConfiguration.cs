using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Config
{
    public class DSConfiguration
    {
        public IConfiguration _configuration { get; set; }

        public DSConfiguration()
        {

           // IConfiguration conf = new ConfigurationBuilder().AddJsonFile
        }
        public void ConfigureSergvices()
        {
        }
    }
}

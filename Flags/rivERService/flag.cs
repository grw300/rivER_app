using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace rivERService
{
    [DataContract]
    public class flags
    {

        public flags()
        {
           
            State = false;
        }

        [DataMember]
        public bool State { get; set; }

    }
}
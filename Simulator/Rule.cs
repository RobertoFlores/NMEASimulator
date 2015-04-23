using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TargetSubLayers;

namespace IntegratorRules
{
    public class Rule
    {
        private int id;

        private string dcescription;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Dcescription
        {
            get { return dcescription; }
            set { dcescription = value; }
        }

        //method for aplying children classes algorithms 
        virtual public void Apply()
        {
        
        }
    }

    public class AsociationRule
    {
        private int id;

        private string dcescription;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Dcescription
        {
            get { return dcescription; }
            set { dcescription = value; }
        }
        
        virtual public bool isAsociated(NMEATarget target)
        {
            return false;
        }        
    }
}

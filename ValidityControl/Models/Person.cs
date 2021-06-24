using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityControl.Models
{
    class Person
    {


        private string fName;
        private string lName;
        private string personalNumber;

        public string FName
        {
            get => fName;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException (nameof(value) ,"Null Exception");
                }
                else
                {
                    fName = value;
                }

            }
        }
        public string LName
        {
            get => lName;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Null Exception");
                }
                else
                {
                    lName = value;
                }

            }
        }
        public string PersonalNumber
        {
            get => personalNumber;
            set
            {
                
                if (value.Length != 13 || value.Substring(8,1) != "-")
                {
                    throw new ArgumentException(nameof(value), "Not a correct personal number");
                }
                else
                {
                    personalNumber = value;
                }
            }


        }
    }
}

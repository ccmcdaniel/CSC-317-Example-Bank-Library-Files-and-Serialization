using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_317_Example_Bank_Library_Files_and_Serialization
{
    public class Record
    {
        public int Account { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        //Empty contstructor
        public Record() : this(0, string.Empty, string.Empty, 0M) { }
        
        //Paramater Constructor
        public Record(int account, string firstname, string lastname, decimal balance)
        {
            Account = account; 
            FirstName = firstname; 
            LastName = lastname;
            Balance = balance;
        }
    }
}

using Skiverleih3.Model;

namespace Skiverleih3
{
    public class CustomerItems
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ItemID { get; set; }
        public string Title { get; set; }
        public State State { get; set; }
    }
}

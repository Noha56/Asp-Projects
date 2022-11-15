namespace ModelApplication.Models
{
    public class Student
    {
        //private data-->filds-->so we need set & get-->start with small letter
        //public data-->propertary--?strt with capital letter-->لحاله بضيف set & get

        //public String StudentId;//لحاله بضيف
        public String? Name { get; set; } //get is required

        // public string name { get; } = "Noha";//-->as constant //value cannot change 
        public String? Id { get; set; }

        public String? Dept { get; set; }

    }
}

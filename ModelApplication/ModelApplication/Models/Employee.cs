namespace ModelApplication.Models
{
    public class Employee
    {
        //String s =emp?.name
        //String s =emp?.name??"student"-->? mean if the objects is null-->?? mean else 

        //مابحتاجها عشان اخزن ,بحتاجها عشان اشيك 
        public String? Name { get; set; }
        public int Id { get; set; }
        //int? x=null;       

        private float _salary;
        public float Salary {
            set
            {
                if(value>=500)
                {
                   _salary = value;
                }
                else
                {
                    _salary = 500;
                }
            }
            get
            {
                return _salary;
            }
        }

    }
}

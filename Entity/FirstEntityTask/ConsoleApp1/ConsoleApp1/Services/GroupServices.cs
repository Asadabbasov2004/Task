
namespace EntityFirstTask
{
    internal class GroupServices
    {
        AppDbContext context;

        public GroupServices()
        {
            context=new AppDbContext();
        }
        public void Add(Group group)
        {
            if (group != null)
            {
            context.Add(group);
            context.SaveChanges();

            }
            else
            {
                Console.WriteLine("Values are null");
            }
        }
        public void Remove(int id)
        {
            Group beforegroup = context.Groups.FirstOrDefault(x=>x.Id == id);
           if(beforegroup != null)
            {
                context.Groups.Remove(beforegroup);
                context.SaveChanges();
            }
        }
        public void GetAll()
        {
        List<Group> Groups = context.Groups.ToList() ;
       foreach (Group group in Groups )
            {
                Console.WriteLine(group.Name);
            }
        }
        public void Update(int id)
        {
            Group beforegroup = context.Groups.FirstOrDefault(x => x.Id == id);
            if (beforegroup != null)
            {
                Console.WriteLine("please enter name");
                beforegroup.Name = Console.ReadLine();
                context.SaveChanges();
            }
        }

        public void Get(int id) {
        var group = context.Groups.FirstOrDefault(x => x.Id == id);
          if (group != null)
            {
                Console.WriteLine("name is found");
            }
          else { Console.WriteLine("name not found"); }
        }


    }
}

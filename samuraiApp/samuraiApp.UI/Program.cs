using samuraiApp.Domain;
using samuraiApp.Data;
using Microsoft.EntityFrameworkCore;

namespace samuraiApp.UI 
{ 
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        private static void Main(string[] args)
        {
           // _context.Database.EnsureCreated();
            //GetSamurais("before add:");
            AddSamuraisByName("julie","sampson");
            GetSamurais("after add:");
            RetrieveAndDeleteSamurai();
            Console.ReadKey();
        }
        private static void AddSamuraisByName(params string[] names)
        {
            foreach(string name in names)
            {
                _context.Samurais.Add(new Samurai { Name=name});

            }
            _context.SaveChanges();

        }
        private static void GetSamurais(string text)
        {
            /* var samurais=_context.Samurais.ToList();
             Console.WriteLine($"{text}:Samurai count is {samurais.Count}");
             foreach(var samurai in samurais)
             {
                 Console.WriteLine(samurai.Name);
             }*/
            var samurais = _context.Samurais
                .TagWith("ConsoleApp.Program.GetSamurais method").ToList();
            
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach(var samurai in samurais)
            {

            }
        }
        private static void QueryFilter()
        {
            var samurais = _context.Samurais
                .Where(s => EF.Functions.Like(s.Name,"J%")).ToList();
        }
        private static void QueryAggregates()
        {
            var name = "Sampson";
            /*var samurai = _context.Samurais
                .Where(s => s.Name==name).FirstOrDefault();*/
           /* var samurai = _context.Samurais
                .FirstOrDefault(s => s.Name == name);*/
            var samurai = _context.Samurais
                .Find(2);
        }
        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurai = _context.Samurais.Skip(1).Take(3).ToList();
            samurai.ForEach(s => s.Name += "san");//update add san to there name
            _context.SaveChanges();
        }
        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "san";
            _context.Samurais.Add(new Samurai { Name = "shino" });
            _context.SaveChanges();

        }
        private static void RetrieveAndDeleteSamurai()
        {
            var samurai = _context.Samurais.Find(1);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();

        }

        private static void QueryAndUpdateBattles_Disconnected()
        {
            List<Battle> disconnectedBattles;
            using (var context1 = new SamuraiContext())
            {
                disconnectedBattles = _context.Battles.ToList();

            }//context1 is diposed
            disconnectedBattles.ForEach(b =>
            {
                b.StartDate =new DateTime(1570,01,01);
                b.EndDate=new DateTime(1570, 12, 01); ;
            });//contex2  to push the changes to database
            using(var context2 = new SamuraiContext())
            {
                context2.UpdateRange(disconnectedBattles);//teel EF core to marke the obj as modified
                context2.SaveChanges();
            }
        }

    }//end of Program
}
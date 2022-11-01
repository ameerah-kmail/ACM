using samuraiApp.Domain;
using samuraiApp.Data;
using Microsoft.EntityFrameworkCore;

namespace samuraiApp.UI 
{ 
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        private static SamuraiContextNoTracking _contextNT = new SamuraiContextNoTracking();
        private static void Main(string[] args)
        {
            // _context.Database.EnsureCreated();
            //GetSamurais("before add:");
            // AddSamuraisByName("julie","sampson");
            // GetSamurais("after add:");
            // RetrieveAndDeleteSamurai();
            FilterinWithRelatedDate();
            Console.ReadKey();
        }
        private static void AddSamuraisByName(params string[] names)
        {
            foreach(string name in names)
            {
                 _context.Samurais.Add(new Samurai { Name=name});
                //_contextNT.Samurais.Add(new Samurai { Name = name });

            }
            _context.SaveChanges();
            //_contextNT.SaveChanges();

        }
        private static void GetSamurais(string text)
        {
            /* var samurais=_context.Samurais.ToList();
             Console.WriteLine($"{text}:Samurai count is {samurais.Count}");
             foreach(var samurai in samurais)
             {
                 Console.WriteLine(samurai.Name);
             }*/
            //var samurais = _contextNT.Samurais
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
        private static void InsertNewSamuraiWithQuote()
        {
            var samurai = new Samurai
            {
                Name = "kambei shimada"
                ,
                Quotes = new List<Quote>
                {
                    new Quote{Text ="I've come to save you"}
                    }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
            
        }
        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote
            {
                Text = "add new quote to Existing Samurai"
            }
                ) ;
            _context.SaveChanges() ;

        }
        private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "add new quote to Existing Samurai"
            }
                );
            using(var newContext =new SamuraiContext())
            {
                //newContext.Samurais.Update(samurai);
                newContext.Samurais.Attach(samurai);
                newContext.SaveChanges();
            }
            

        }
        private static void Simpler_AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var quote = new Quote { Text = "any thing", SamuraiId = samuraiId };

            using var newContext = new SamuraiContext();
                newContext.Quotes.Attach(quote);
                newContext.SaveChanges();
        }
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
        }
        private static void EagerLoadSamuraiWithQuotesWithAsSplitQuery()
        {
            var samuraiWithQuotes = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();
        }
        private static void EagerLoadSamuraiWithQuotesWithFilteredInclude()
        {
            var filteredInclude = _context.Samurais
                .Include(s => s.Quotes.Where(q=>q.Text.Contains("Thanks"))).ToList();
        }
        private static void EagerLoadSamuraiWithQuotesWithfilteredPrimaryEntityInclude()
        {
            var filteredPrimaryEntityInclude =
                _context.Samurais.Where(s => s.Name.Contains("Sampson"))
               .Include(s => s.Quotes).FirstOrDefault();
                
                
        }
        private static void ProjectSomeProprties()
        {
            var someProprties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
            var idAndName = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
        public struct IdAndName
        {
           public IdAndName(int id,string name)
            {
                Id = id;
                Name = name;
            }
            public int Id;
            public string   Name;
        }
        private static void ProjectSamuraisWithQuotes()
        {
            var somePropsWithQuotes=_context.Samurais
                .Select(s => new { s.Id, s.Name ,s.Quotes, NumberofQuotes= s.Quotes.Count })
                .ToList();
        }
        private static void ProjectSamuraisWithQuotesWithFilter()
        {
            var somePropsWithQuotes = _context.Samurais
                .Select(s => new { s.Id, s.Name, s.Quotes, 
                    HappyQuotes = s.Quotes.Where(q=>q.Text.Contains("Happy")) })
                .ToList();
        }
        private static void ExplicitLoadQuotes()
        {
            _context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Mr. Ed" });
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            var samurai = _context.Samurais.Find(1);
            _context.Entry(samurai).Collection(s => s.Quotes).Load();
            _context.Entry(samurai).Reference(s => s.Horse).Load();
        }
        private static void lazyLoadQuotes()
        {
            var samurai = _context.Samurais.Find(2);
            var quoteCount=samurai.Quotes.Count();
            /*
            var happyQuotes = _context.Entry(samurai)
                .Collection(b => b.Quotes)
                .Query()
                .Where(q => q.Text.Contains("Happy"))
                .ToList();*/
        }
        private static void FilterinWithRelatedDate()
        {
            var samurai = _context.Samurais
                .Where(s => s.Quotes.Any(q => q.Text.Contains("Happy")))
                .ToList();
        }
        private static void ModifyingRelatedDataWhenTracked()
        {
            var samurai =_context.Samurais.Include(s=>s.Quotes).
                FirstOrDefault(s=>s.Id == 2);
            samurai.Quotes[0].Text = "did ---";
            _context.Quotes.Remove(samurai.Quotes[2]);
            _context.SaveChanges();

        }
        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).
                FirstOrDefault(s => s.Id == 2);
            var quote = samurai.Quotes[0];
            quote.Text += "did ---";

            using var newContext = new SamuraiContext();
            //newContext.Quotes.Update(quote);
            newContext.Entry(quote).State=EntityState.Modified;
            newContext.SaveChanges();

        }
        private static void AddingNewSamuraiToAnExisitingBattle()
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.Samurais.Add(new Samurai { Name="Takada"});
            _context.SaveChanges();
        }
        private static void ReturnBattleWithSamurai()
        {
            var battle = _context.Battles.Include(b=>b.Samurais).FirstOrDefault();
        }
        private static void ReturnAllBattlesWithSamurais()
        {
            var battle = _context.Battles.Include(b => b.Samurais).ToList();
        }
        private static void AddAllSamuraisToAllBattles()
        {
            var allBattles= _context.Battles.ToList();
            var allSamurais = _context.Samurais.ToList();
            foreach (var battle in allBattles)
            {
                battle.Samurais.AddRange(allSamurais);
            }
            _context.SaveChanges();
        }
        private static void RemoveSamuraiFromBattle()
        {
            var battleWithSamurai = _context.Battles.
                Include(b => b.Samurais.Where(s => s.Id == 12))
                .Single(s => s.BattleId == 1);
            var samurai = battleWithSamurai.Samurais[1];
            battleWithSamurai.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        private static void RemoveSamuraiFromBattleExplicit()
        {
            var battleSamurai = _context.Set<BattleSamurai>()
                .SingleOrDefault(s => s.BattleId == 1 && s.SamuraiId==12);
            if(battleSamurai != null)
            {
                _context.Remove(battleSamurai);
                _context.SaveChanges();
            }

        }
    }//end of Program
}
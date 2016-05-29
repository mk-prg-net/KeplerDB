using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace KeplerBI.Parser.RPN.Test
{
    [TestClass]
    public class FilterSortRPNTerms
    {

        //Dictionary<string, mko.RPN.IEval> Evaluators = new Dictionary<string, mko.RPN.IEval>{
        //    {"AU", new AUEval()},
        //    {"EM", new EMEval()},
        //    {"DiameterRng", new Planets.DiameterRngEval()},
        //    {"MassRng", new Planets.MassRngEval()},            
        //    {"SemiMajorAxisLengthRng", new Planets.SemiMajorAxisLengthRngEval()},
        //    {"OrderByMass", new Planets.OrderByMassEval()},
        //    {"OrderBySemiMajorAxisLength", new Planets.OrderBySemiMajorAxisLengthEval()}            
        //};
        
        mko.RPN.Parser Parser;

        public FilterSortRPNTerms()
        {
            Parser = new mko.RPN.Parser();
            mko.Newton.Init.Do();
        }

        [TestMethod]
        public void KeplerBI_Parser_RPN_Filter_SemiMajorAxisLength()
        {            
            using (var Universum = new KeplerBI.DB.AstroCatalog())
            {

                var tokenizer  = new Tokenizer("2 AU 10 AU " + Tokenizer.SemiMajorAxisLengthRng);

                Parser.Parse(tokenizer, Tokenizer.EvalFunctions);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(1, Parser.Stack.Count);
                Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(Planets.SemiMajorAxisLengthRngConfigCmd));

                var fltBld = Universum.Planets.createFiltertedSortedSetBuilder();
                (Parser.Stack.Peek() as Planets.ConfigCmdToken).ConfigBld(fltBld);

                var fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());
                

                tokenizer = new Tokenizer("2 AU 10 AU " + Tokenizer.SemiMajorAxisLengthRng + " desc " + Tokenizer.OrderBySemiMajorAxisLength);

                Parser.Parse(tokenizer, Tokenizer.EvalFunctions);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(2, Parser.Stack.Count);
                

                // Konfigurieren des FilteredSortedSetBuilders mittels der geparsten Konfigurationskommandos
                fltBld = Universum.Planets.createFiltertedSortedSetBuilder();

                var configurator = new KeplerBI.Parser.RPN.Planets.FltBldConfigurator(Parser.Stack);
                configurator.Apply(fltBld);
                
                fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());
            }
        }

        [TestMethod]
        public void KeplerBI_Parser_RPN_Filter_Mass()
        {
            using (var Universum = new KeplerBI.DB.AstroCatalog())
            {

                var tokenizer = new Tokenizer("2 EM 20 EM " + Tokenizer.MassRng);

                Parser.Parse(tokenizer, Tokenizer.EvalFunctions);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(1, Parser.Stack.Count);
                Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(Planets.MassRngConfigCmd));

                var fltBld = Universum.Planets.createFiltertedSortedSetBuilder();
                (Parser.Stack.Peek() as Planets.ConfigCmdToken).ConfigBld(fltBld);

                var fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());


                tokenizer = new Tokenizer("2 EM 20 EM " + Tokenizer.MassRng + " desc " + Tokenizer.OrderByMass);

                Parser.Parse(tokenizer, Tokenizer.EvalFunctions);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(2, Parser.Stack.Count);

                fltBld = Universum.Planets.createFiltertedSortedSetBuilder();

                // Umkopieren, um richtige Ausführungsreihenfolge zu erhalten
                var stack2 = new Stack<Planets.ConfigCmdToken>();
                while (Parser.Stack.Any())
                {
                    stack2.Push((Planets.ConfigCmdToken)Parser.Stack.Pop());
                }

                // FilteredSortedSetBuilder über Kommandos konfigurieren

                while (stack2.Any())
                {
                    var configCmd = stack2.Pop();
                    configCmd.ConfigBld(fltBld);
                }

                fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());


            }

        }

    }
}

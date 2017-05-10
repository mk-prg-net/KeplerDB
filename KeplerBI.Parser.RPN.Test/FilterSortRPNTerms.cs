using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using mko.RPN;

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
        IFunctionNames fn = new BasicFunctionNames();
        Composer cpsr; 

        public FilterSortRPNTerms()
        {
            cpsr = new Composer(fn);
            var fnameEvalTab = new FnameEvalTab(fn);
            Parser = new mko.RPN.Parser(fnameEvalTab.FuncEvaluators);
            mko.Newton.Init.Do();
        }

        [TestMethod]
        public void KeplerBI_Parser_RPN_Filter_SemiMajorAxisLength()
        {            
            using (var Universum = new KeplerBI.DB.AstroCatalog())
            {

                var rpn = cpsr.rSemiMajorAxisLengthRng(cpsr.rAU(cpsr.Dbl(2)), cpsr.rAU(cpsr.Dbl(10)));
                Parser.Parse(rpn);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(1, Parser.Stack.Count);
                Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(SemiMajorAxisLengthRngData));

                var Tokens = Parser.TokenBuffer.Tokens.Copy();

                var pCount = Tokens.FunctionParameterCount(fn.SemiMajorAxisLengthRng);
                Assert.AreEqual(2, pCount);

                var p1 = Tokens.GetParameterSubtree(1);
                Assert.IsTrue(p1.IsFunctionSubtree(fn.semMin));

                var p1Val = p1.GetParameterSubtree(1);
                Assert.IsTrue(p1Val.IsFunctionSubtree(fn.AU));

                var p1ValVal = p1Val.GetParameterSubtree(1);
                Assert.AreEqual(1, p1ValVal.Count());
                Assert.IsTrue(p1ValVal[0].IsInteger);
                Assert.AreEqual(2, ((IntToken)p1ValVal[0]).ValueAsInt);

                var p2 = Tokens.GetParameterSubtree(2);
                Assert.IsTrue(p2.IsFunctionSubtree(fn.semMax));

                var p2Val = p2.GetParameterSubtree(1);
                Assert.IsTrue(p2Val.IsFunctionSubtree(fn.AU));

                var p2ValVal = p2Val.GetParameterSubtree(1);
                Assert.AreEqual(1, p2ValVal.Count());
                Assert.IsTrue(p2ValVal[0].IsInteger);
                Assert.AreEqual(10, ((IntToken)p2ValVal[0]).ValueAsInt);



                var fltBld = Universum.Planets.createFiltertedSortedSetBuilder();
                var fltBldConfig1 = new Planets.FltBldConfigurator(Parser.Stack);
                fltBldConfig1.Apply(fltBld);                

                var fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());


                rpn += cpsr.rOrderBySemiMajorAxisLength("desc");
                Parser.Parse(rpn);
                //Parser.TokenBuffer.Reset();                
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(2, Parser.Stack.Count);
                

                // Konfigurieren des FilteredSortedSetBuilders mittels der geparsten Konfigurationskommandos
                fltBld = Universum.Planets.createFiltertedSortedSetBuilder();

                var fltBldConfig2 = new Planets.FltBldConfigurator(Parser.Stack);
                fltBldConfig2.Apply(fltBld);
                
                fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());
            }
        }

        [TestMethod]
        public void KeplerBI_Parser_RPN_Filter_Mass()
        {
            using (var Universum = new KeplerBI.DB.AstroCatalog())
            {
                var rpn = cpsr.rMassRng(cpsr.rEM(cpsr.Dbl(2)), cpsr.rEM(cpsr.Dbl(20)));

                Parser.Parse(rpn);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(1, Parser.Stack.Count);
                Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(MassRngData));

                var fltBld = Universum.Planets.createFiltertedSortedSetBuilder();
                var fltBldConfig1 = new Planets.FltBldConfigurator(Parser.Stack);
                fltBldConfig1.Apply(fltBld);                

                var fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());

                rpn += cpsr.rOrderByMass("desc");
                Parser.Parse(rpn);
                Assert.IsTrue(Parser.Succsessful);
                Assert.AreEqual(2, Parser.Stack.Count);

                fltBld = Universum.Planets.createFiltertedSortedSetBuilder();
                var fltBldConfig2 = new Planets.FltBldConfigurator(Parser.Stack);
                fltBldConfig2.Apply(fltBld);                

                fltSet = fltBld.GetSet();
                Assert.IsTrue(fltSet.Any());
            }
        }
    }
}

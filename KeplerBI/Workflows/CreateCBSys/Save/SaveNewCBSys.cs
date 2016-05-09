using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys.Save
{
    public class SaveNewCBSys : FSM.State
    {
        public SaveNewCBSys() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new Fin(), new Cancel(), new Error() }; }
        }
    }

    public abstract class SaveNewCBSysContext : SaveNewCBSys
    {
        ICelesticalBodySystem _CBSys;
        public ICelesticalBodySystem CBsys
        {
            get
            {
                return _CBSys;
            }
        }

        public SaveNewCBSysContext(ICelesticalBodySystem CBSys)
        {
            _CBSys = CBSys;
        }

        // Medium, in dem das neue System gespeichert wird
        public abstract void Save(string Name, ICelesticalBodySystem CBSys);

    }


    public class SaveNewCBSysSTF : FSM.IStateTransistion<SaveNewCBSysContext, Input>
    {
        public FSM.State Transition(SaveNewCBSysContext ActiveState, Input input)
        {
            switch (input.Tag)
            {
                case Input.Tags.Cancel:
                    return new Cancel();
                case Input.Tags.Save:
                    {
                        try
                        {
                            ActiveState.Save(((InputSave)input).Name, ActiveState.CBsys);
                            return new FinContext(ActiveState.CBsys);
                        }
                        catch (Exception ex)
                        {
                            return new ErrorContext() { FaultyState = ActiveState, Exception = ex, ErrorDescription = "Ausnahme beim Sichern des neuen Himmelskörpersystems: " + ex.Message };
                        }
                    }
                default:
                    {
                        return new ErrorContext() { FaultyState = ActiveState, ErrorDescription = "Unbekannte Eingabe im Zustand SaveNewCBSys" };
                    }

            }

        }
    }
}

using System.Reactive.Subjects;
using ObservableStateStore.States;
using ObservableStateStore.Actions;

namespace ObservableStateStore.StateStores;

public class CounterStateStore :
  StateStoreBase<CounterState>, ICounterStateStoreActions
{
    public CounterStateStore() : base()
    {
        CounterState initialState = new CounterState(0);
        this.state = new BehaviorSubject<CounterState>(initialState);
    }
    public void Increment()
    {
        var nextState =  this.state.Value with { counter =  this.state.Value.counter +1}; 
        this.state.OnNext(nextState);  
    }
}
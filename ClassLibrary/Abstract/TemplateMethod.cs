using System;

namespace ClassLibrary.Abstract
{
    public abstract class TemplateMethod
    {
        protected bool _byeHook, _firstTime;

        public TemplateMethod()
        {
            _byeHook = false;
            _firstTime = true;
        }

        protected virtual void Welcome()
        {
            Console.WriteLine("Kalkulator");
            Console.WriteLine("Aby skorzystać z funkcji kalkulatora");
            Console.WriteLine("Wpisz najpierw symbol równania, następnie dwie liczby \nna których ma zostać wykonane działanie");
            Console.WriteLine("Np.  + 2 3");
            Console.WriteLine("Wynik można zapisać do pamięci wpisując 'm' po wyświetleniu rezultatu");
            Console.WriteLine("Można potem skożystać z zapamiętanego wyniku używając 'm' w poleceniu\nnp. + m 2");
            Console.WriteLine("W kalkulatorze można obliczyć całkę oznaczoną na 5 zdefiniowanych \nwcześniej funkcjach wybierając 'c' jako komęde");
            Console.WriteLine("q - kończy działanie kalkulatora");
        }

        protected abstract void GetCommand();

        protected abstract void FollowCommand();

        protected virtual void ByeBye()
        {
            Console.WriteLine("Dziękujemy za skorzystanei z aplikacji");
        }

        public void Run()
        {
            if (_firstTime)
            {
                Welcome();
                _firstTime = false;
            }
            GetCommand();
            FollowCommand();

            if (_byeHook)
            {
                ByeBye();
            }
            else
            {
                Run();
            }
        }
    }
}

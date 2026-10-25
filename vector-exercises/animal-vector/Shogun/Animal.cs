namespace Shogun
{
    public class Animal : TestClassVector
    {
        private int _age;
        private string _color;

        public string Color => _color;
        public int Age => _age;

        public Animal(int x, int y, int age, string color):base(x, y)
        {
            _age = age;
            _color = color;
        }
        
    }
}
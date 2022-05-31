using System;
using System.Collections.Generic;
using System.Text;

namespace LevelEditor
{
    class Controller
    {
        Editor lv;            
        private void Init()
        {
            lv= new Editor(0, 0);
            SetUp();
        }

        public void Update()
        {
            Init();

            do
            {
                lv.Input();
                lv.Draw();

            } while (lv.endEdit);

        }

        private void SetUp()
        {
            Console.WriteLine("Ingrese a continuacion el nombre del archivo para editar el nivel");
            lv._fileName = Console.ReadLine();             

            Console.WriteLine("Ingrese a continuacion el ancho del escenario");
            lv.width= Int32.Parse( Console.ReadLine());
            Console.WriteLine("Ingrese a continuacion el alto del escenario");
            lv.heigh= Int32.Parse(Console.ReadLine());

            Console.SetWindowSize(lv.width,lv.heigh);
            Console.Clear();
        }
    }
}

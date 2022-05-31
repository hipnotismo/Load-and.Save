using System;
using System.IO;
using System.Collections.Generic;


namespace LevelEditor
{
    class Editor
    {
        private struct Pos
        {
            public int x ;
            public int y ;
        }

        private int _x;
        private int _y;
        private char model;
        public bool endEdit = true;
        
        public string _fileName;
        private List<Pos> positions = new List<Pos>();

        public int heigh;
        public int width;

        public Editor(int x, int y)
        {
            _x = x;
            _y = y;                       
        }
        public void Input()
        {
            model = new char();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.A:
                        _x -= 1;
                        break;
                    case ConsoleKey.D:
                        _x += 1;
                        break;
                    case ConsoleKey.W:
                        _y -= 1;
                        break;
                    case ConsoleKey.S:
                        _y += 1;
                        break;
                    case ConsoleKey.Spacebar:
                        model = 'X';
                        Pos consolePos = new Pos();
                        consolePos.x = _x;
                        consolePos.y = _y;
                        positions.Add(consolePos);                       
                        break;
                    case ConsoleKey.Escape:
                        SaveLevel();
                        endEdit = false;
                        break;
                }
                Limit();
            }
        }

        private void Limit()
        {
            if (_x < 0) _x = 0;
            if (_x > width-1) _x = width-1;
            if (_y < 0) _y = 0;
            if (_y > heigh-1) _y = heigh-1;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(model);
        }       
        private void SaveLevel()
        {            
            FileStream fs = File.OpenWrite("C:/Users/Oxz/Documents/Repos/TestReadWrite/Assets/Data/"+_fileName+".dat");
            BinaryWriter bw = new BinaryWriter(fs);

            foreach (Pos p in positions)
            {
                bw.Write(p.x);
                bw.Write(p.y);
            }

            bw.Close();
            fs.Close();
        }
    }
}

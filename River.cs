using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWorkLinq2
{
    //река – название, длина, максимальная ширина, число притоков, шифр реки
    class River
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public int NumbOfConfluent { get; set; }

        public string Ciper { get; set; }

    }
}
